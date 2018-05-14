namespace TokenBusPractice
{
    partial class HostForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HistoryBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Send_Button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Host_Num_Box = new System.Windows.Forms.TextBox();
            this.Aim_Libel = new System.Windows.Forms.Label();
            this.Token_State = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "主机号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "令牌状态：";
            // 
            // HistoryBox
            // 
            this.HistoryBox.Location = new System.Drawing.Point(15, 79);
            this.HistoryBox.Name = "HistoryBox";
            this.HistoryBox.Size = new System.Drawing.Size(370, 204);
            this.HistoryBox.TabIndex = 4;
            this.HistoryBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "接受消息：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "发送消息：Hello Babby";
            // 
            // Send_Button
            // 
            this.Send_Button.Location = new System.Drawing.Point(301, 322);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(84, 28);
            this.Send_Button.TabIndex = 8;
            this.Send_Button.Text = "发送";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Visible = false;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "目的主机号：";
            // 
            // Host_Num_Box
            // 
            this.Host_Num_Box.Location = new System.Drawing.Point(78, 16);
            this.Host_Num_Box.Name = "Host_Num_Box";
            this.Host_Num_Box.Size = new System.Drawing.Size(77, 25);
            this.Host_Num_Box.TabIndex = 11;
            this.Host_Num_Box.Text = "0";
            // 
            // Aim_Libel
            // 
            this.Aim_Libel.AutoSize = true;
            this.Aim_Libel.Location = new System.Drawing.Point(106, 329);
            this.Aim_Libel.Name = "Aim_Libel";
            this.Aim_Libel.Size = new System.Drawing.Size(55, 15);
            this.Aim_Libel.TabIndex = 12;
            this.Aim_Libel.Text = "label6";
            // 
            // Token_State
            // 
            this.Token_State.AutoSize = true;
            this.Token_State.ForeColor = System.Drawing.Color.Red;
            this.Token_State.Location = new System.Drawing.Point(253, 19);
            this.Token_State.Name = "Token_State";
            this.Token_State.Size = new System.Drawing.Size(0, 15);
            this.Token_State.TabIndex = 13;
            // 
            // HostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 367);
            this.Controls.Add(this.Token_State);
            this.Controls.Add(this.Aim_Libel);
            this.Controls.Add(this.Host_Num_Box);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Send_Button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HistoryBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HostForm";
            this.Text = "Host";
            this.Load += new System.EventHandler(this.HostForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox HistoryBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Send_Button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Host_Num_Box;
        private System.Windows.Forms.Label Aim_Libel;
        private System.Windows.Forms.Label Token_State;
    }
}

