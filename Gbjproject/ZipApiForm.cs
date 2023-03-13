using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

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
            this.Location = new Point(640, 180);

            /*string uri = "http://www.juso.go.kr/openIndexPage.do";*/

            /*webBrowser1.ScrollBarsEnabled = true;
            webBrowser1.Url = new Uri(uri);*/

            /*panel1.Controls.Add(webBrowser1);*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;//검색
            string apiKey = "devU01TX0FVVEgyMDIzMDIyNDE1NDMzMjExMzU0Nzk=";//apikey

            
           
            string apiUrl = "http://www.juso.go.kr/addrlink/addrLinkApi.do";
            /*@"https://www.juso.go.kr/addrlink/addrLinkApi.do?currentPage=1&countPerPage=10&keyword={"+searchText+"}&confmKey="+apiKey;*/
            

            /*webBrowser1.Navigate(apiUrl);*/
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
