using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsWebClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSinc_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string line = "";
            StringBuilder builder = new StringBuilder();
            using(Stream stream=client.OpenRead(txtUrl.Text) )
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while ((line = reader.ReadLine()) != null)
                        builder.AppendLine(line);
                }
               
            }
            txtRequerst.Text = builder.ToString();
        }
        private async Task GetTask()
        {WebClient client = new WebClient();
            string line = "";
            StringBuilder builder = new StringBuilder();
            Uri uri = new Uri(txtUrl.Text);
            using (Stream stream = await client.OpenReadTaskAsync(uri))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while ((line = reader.ReadLine()) != null)
                        builder.AppendLine(line);
                }

            }
            txtRequerst.Text = builder.ToString();

        }
        private async void  btnAsync_Click(object sender, EventArgs e)
        {
            await GetTask();
        }
    }
}
