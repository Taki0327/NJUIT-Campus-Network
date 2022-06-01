using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学校网
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string HttpPost(string msg)
        {
            try
            {
                byte[] postD = Encoding.UTF8.GetBytes(msg);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.255.200.11/api/portal/v1/login");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postD, 0, postD.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return sr.ReadToEnd();
            }
            catch
            {
                MessageBox.Show("服务器连接失败");
                return "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            lw();
        }
        public void lw()
        {
            Class1 rb = new Class1();
            rb.Domain = "cmcc"; //运营商
            rb.Username = "请输入你的学号"; //学号
            rb.Password = "请输入你的密码"; //密码
            string type = JsonConvert.SerializeObject(rb);
            type = HttpPost(type);
            MessageBox.Show(type);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lw();
        }
    }
}
