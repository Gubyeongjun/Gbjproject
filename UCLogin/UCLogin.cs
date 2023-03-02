using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UCLogin
{
    public partial class UCLogin : UserControl
    {
        private string id = "aaa";
        private string pwd = "bbb";

        public UCLogin()
        {
            InitializeComponent();
        }

        private void UCLogin_Load(object sender, EventArgs e)
        {

        }

        public int checkLogin_Func(string id, string pwd)
        {
            if (this.id == id && this.pwd == pwd)
                return 1;
            else if (id == "" || pwd == "")
                return 0;
            else
                return -1;
        }
    }
}
