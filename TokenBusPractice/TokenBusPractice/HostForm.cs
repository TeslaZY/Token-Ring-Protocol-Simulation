using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TokenBusPractice
{
    /*
     * HostForm类主要实现了建立监听、发送消息、转发令牌的功能
     * 采用了Socket技术和多线程编程，在多线程访问临界资源控制
     * 中使用了Peterson算法     
     */

    public partial class HostForm : Form
    {
        private int host_count = 8;
        private int Host_NO=0;//本主机号       
        private int aim_host_num = 0;//发送目标主机号
        private int con_host = 0;//下一个主机号
        private Boolean Token = false;//令牌拥有标志
        private Boolean sendflag = false;
        private IPEndPoint point = null;//本机监听节点       
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //记录通信用的Socket
        //private Dictionary<string, Socket> dic = new Dictionary<string, Socket>();

        //构造函数
        public HostForm()
        {
            InitializeComponent();
        }

        //带参数构造函数，实现重要参数初始化并开启监听
        public HostForm(int Host_Num,Boolean token)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            Token_State.ForeColor = System.Drawing.Color.Red;
            Token_State.Text = "未拥有";
            Host_NO = Host_Num;
            Token = token;
            aim_host_num = Host_Num;
            con_host = Host_Num + 1;
            if (Host_NO == host_count)
            con_host = con_host% host_count;
            Listen();//开启监听
        }

        //更新令牌信息
        private void UpdateToken(String token)
        {

            if (token == "TokenFalse")
            {
                Token = false;
                Token_State.Text = "未拥有";
                Token_State.Visible = false;
            }

            else if (token == "TokenTrue")
            {
                Token = true;
                Token_State.Text = "已拥有";
                Token_State.Visible = true;
            }
        }


        private void HostForm_Load(object sender, EventArgs e)
        {
            Aim_Libel.Text = "";
            Host_Num_Box.Text = Host_NO.ToString();
            UpdateToken("Token"+Token.ToString());
            //发起连接
            Connect();
            //初始化类为1号主机产生令牌，1号主机转发令牌
            if (Host_NO == 1 && Token == true)
            {
                SendToken();
            }
            // Send_Button_Click(sender, e);
            Send_Button.Visible = true;
        }

        private void Listen()//监听函数
        {
            //ip地址
            string ipaddress = "127.0.0.1";
            IPAddress ip = IPAddress.Parse(ipaddress);
            //端口号
            int port = 6000 + Host_NO;
            this.point = new IPEndPoint(ip, port);
            //创建监听用的Socket


            //使用IPv4地址，流式socket方式，tcp协议传递数据

            try

            {
                //创建好socket后，必须告诉socket绑定的IP地址和端口号。

                //socket监听哪个端口

                server.Bind(this.point);

                //同一个时间点过来10个客户端，排队

                server.Listen(10);

                ShowMsg("主机"+Host_NO.ToString()+"开始监听");
                
                Thread thread = new Thread(AcceptInfo);

                thread.IsBackground = true;

                thread.Start(server);


            }

            catch (Exception ex)

            {
                ShowMsg(ex.Message);

            }

        }

        //请求连接函数
        private void Connect()

        {
            //连接到的目标IP

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 6000 + con_host;
            IPEndPoint temppoint = new IPEndPoint(ip, port);

            //IPAddress ip = IPAddress.Any;

            //连接到目标IP的哪个应用(端口号！)随机产生主机号且与本主机号不同
            
            try

            {

                //连接到服务器

                client.Connect(temppoint);


                ShowMsg("连接主机" + con_host.ToString() +"    ip:"+ client.RemoteEndPoint.ToString()+"成功");

                //连接成功后，就可以接收发送信息了
                /*
                Thread th = new Thread(CReceiveMsg);

                th.IsBackground = true;

                th.Start();
                */
            }

            catch (Exception ex)

            {

                ShowMsg(ex.Message);

            }

        }

        void AcceptInfo(object o)

        {

            Socket socket = o as Socket;//socket==server

            while (true)

            {

                //通信用socket

                try

                {

                    Socket tSocket = socket.Accept();//tsocket==other host client

                    //接收消息

                    Thread th = new Thread(SReceiveMsg);

                    th.IsBackground = true;

                    th.Start(tSocket);

                }

                catch (Exception ex)

                {

                    ShowMsg(ex.Message);

                    break;

                }

            }

        }


        void SReceiveMsg(object o)

        {
            string words = "";
            Socket socket = o as Socket;

            while (true)

            {
                //接收客户端发送过来的数据

                try

                {

                    //定义byte数组存放从客户端接收过来的数据

                    byte[] buffer = new byte[1024 * 1024];

                    //将接收过来的数据放到buffer中，并返回实际接受数据的长度

                    int n = socket.Receive(buffer);

                    //将字节转换成字符串

                    words = Encoding.UTF8.GetString(buffer, 0, n);
                    string []aim=Recieve_Translate_Information(words);

                    if (aim[1] == Host_NO.ToString())
                    {
                        ShowMsg("收到"+aim[0]+"号主机的消息" + ":    " + words);
                        //Thread.Sleep(2000);
                        Send(words);
                    }
                    else if (aim[0] == "0" && aim[1] == "0")//收到令牌
                    {
                        UpdateToken("TokenTrue");
                        //有消息要发送的时候
                        while (sendflag == true && Token == true) { }                        
                        Thread.Sleep(1000);
                        Send(words);
                        UpdateToken("TokenFalse");
                    }
                    else if (aim[0] == Host_NO.ToString())
                    {
                        //Send(words);
                      //ShowMsg("消息回来了："+ words);
                        UpdateToken("TokenFalse");
                    }
                    else if (aim[0] != "0" && aim[1] != "0"&&aim[1] != Host_NO.ToString())
                    {
                        //Thread.Sleep(2000);
                        Send(words);
                     // ShowMsg("转发来自" + aim[0] + "号主机的消息" + ":    " + words);
                    }

                }

                catch (Exception ex)

                {

                    ShowMsg(ex.Message);

                    break;

                }

            }

        }

        //点击发送按钮以后的执行函数
        private void Send_Button_Click(object sender, EventArgs e)
        {
            try

            {
                sendflag = true;

                Thread thread = new Thread(SendMsg);

                thread.IsBackground = true;

                thread.Start();

            }

            catch (Exception ex)

            {

                ShowMsg(ex.Message);

            }


        }

        //源主机具体的消息发送过程
        void SendMsg()
        {
            while (true)
            {
                Random aim = new Random();
                //产生随机的发送目标主机的主机号
                while (aim_host_num == Host_NO)
                {
                    aim_host_num = aim.Next(1, host_count);
                }
                Aim_Libel.Text = aim_host_num.ToString();

                String infomation = Host_NO.ToString() + ":" + aim_host_num.ToString() + ":Hello Baby";

                HistoryBox.AppendText("【尝试发送给" + Aim_Libel.Text + "号主机】" + infomation + "\n");
                //当不拥有令牌的时候，不进行消息的发送
                while (Token != true) { }
                Thread.Sleep(2000);
                Send(infomation);
                aim_host_num = Host_NO;//恢复主机号
                sendflag = false;
                Thread.Sleep(6000);                
            }                   
        }

        //消息转发过程函数
        void Send(object o)
        {
            String info = o as string;
            try
            {
               
                byte[] buffer = Encoding.UTF8.GetBytes(info);

                client.Send(buffer);

            }
            catch (Exception ex)
                {
                ShowMsg(ex.Message);
            }
        }

 
        //发送令牌函数
        private void SendToken()
        {
            String info = "0:0:Token"+Token.ToString();
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(info);
                client.Send(buffer);
                UpdateToken("TokenFalse");
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        //对接收到的字节流进行分割，返回字符串数组方便判断
        private String [] Recieve_Translate_Information(String info)
        {
            string[] s = info.Split(new char[] { ':' });
            return s;
        }

        //消息接收栏显示消息的API
        void ShowMsg(string msg)
        {
            HistoryBox.AppendText(DateTime.Now.ToString() + "    " + msg + "\r\n");
        }
    }
}
