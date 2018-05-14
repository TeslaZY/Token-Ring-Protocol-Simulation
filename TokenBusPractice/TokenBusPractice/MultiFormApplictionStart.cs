using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TokenBusPractice
{
    class MultiFormApplictionStart : ApplicationContext
    {
        private void OnFormClosed(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                ExitThread();
            }
        }
        public MultiFormApplictionStart()
        {
            /*
             *里面添加启动的窗口
             * 并且为每个主机赋予主机号、令牌状态，默认1号主机
             * 为起始拥有令牌的主机
             */
            var FormList = new List<Form>(){
            new HostForm(1,true),
            new HostForm(2,false),
            new HostForm(3,false),
            new HostForm(4,false),
            new HostForm(5,false),
            new HostForm(6,false),
            new HostForm(7,false),
            new HostForm(8,false)       
        };
            foreach (var item in FormList)
            {
                item.FormClosed += OnFormClosed;
            }
            //让每个窗口排列显示，密铺排开
            int x = 100,y = 100,i=0;
            for(i=0;i<FormList.Count;i++)
            {
                FormList[i].Location = new System.Drawing.Point(x,y);
                FormList[i].StartPosition = FormStartPosition.Manual;
                FormList[i].Show();
                x = x + 320;
                if (i == 3)
                {
                    x = 100;
                    y = y + 400;
                }
                    
            }
        }
    }
}
