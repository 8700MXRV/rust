using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";//要执行的程序名称 
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;//可能接受来自调用程序的输入信息 
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息 
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口 
            p.Start();//启动程序 
            //向CMD窗口发送输入信息： 
            p.StandardInput.WriteLine("netsh ipsec static add policy name=qianye");
            p.StandardInput.WriteLine("netsh ipsec static add filterlist name=KICK"); //10秒后重启（C#中可不好做哦）
            p.StandardInput.WriteLine("netsh ipsec static add filter filterlist=KICK srcaddr=" + "127.0.0.6" + " dstaddr=Me dstport=any protocol=UDP");
            p.StandardInput.WriteLine("netsh ipsec static add filteraction name=FilteraAtion1 action=block");
            p.StandardInput.WriteLine("netsh ipsec static add rule name=可访问的终端策略规则 policy=qianye filterlist=KICK filteraction=FilteraAtion1");
            p.StandardInput.WriteLine("netsh ipsec static set policy name=qianye assign=y");
            p.StandardInput.WriteLine("exit");
        }
    }
}
