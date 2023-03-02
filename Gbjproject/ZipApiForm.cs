using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gbjproject
{
    public partial class ZipApiForm : Form
    {
        public ZipApiForm()
        {
            InitializeComponent();
        }

        private void ZipApiForm_Load(object sender, EventArgs e)
        {
            /*string uri = "http://www.juso.go.kr/openIndexPage.do";*/
            
            /*webBrowser1.ScrollBarsEnabled = true;
            webBrowser1.Url = new Uri(uri);*/

            /*panel1.Controls.Add(webBrowser1);*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchKeyword = textBox1.Text;
            string key = "devU01TX0FVVEgyMDIzMDIyNDE1NDMzMjExMzU0Nzk=";
            string apiUrl = @"https://www.juso.go.kr/addrlink/addrLinkApi.do?currentPage=1&countPerPage=10&keyword={"+searchKeyword+"}&confmKey="+key;

            webBrowser1.Navigate(apiUrl);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
