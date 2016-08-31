using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            var client = new ServiceReferenceA.ServiceAClient();
            client.ClientCredentials.Windows.ClientCredential.Domain = "yuray2";
            client.ClientCredentials.Windows.ClientCredential.UserName = "adamus";
            client.ClientCredentials.Windows.ClientCredential.Password = "Internet=01!";
            client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;

            this.richTextBox1.Text += "=====================\n";
            this.richTextBox1.Text += client.GetData(10).ToString();
            this.richTextBox1.Text += "=====================\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var client = new ServiceReferenceC.Service1Client();
            client.ClientCredentials.Windows.ClientCredential.Domain = "yuray2";
            client.ClientCredentials.Windows.ClientCredential.UserName = "adamus";
            client.ClientCredentials.Windows.ClientCredential.Password = "Internet=01!";
            client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;

            this.richTextBox1.Text += "=====================\n";
            this.richTextBox1.Text += client.GetData(10).ToString();
            this.richTextBox1.Text += "\n=====================\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = new ServiceReferenceB.ServiceBClient();
            client.ClientCredentials.Windows.ClientCredential.Domain = tbDomain.Text;
            client.ClientCredentials.Windows.ClientCredential.UserName = tbUsername.Text;
            client.ClientCredentials.Windows.ClientCredential.Password = tbPassword.Text;
            client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;

            this.richTextBox1.Text += "=====================\n";
            this.richTextBox1.Text += client.GetData(10).ToString();
            this.richTextBox1.Text += "=====================\n";

        }
    }
}
