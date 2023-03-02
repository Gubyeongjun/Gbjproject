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
    public partial class ButtonForm : Form
    {   
        public Button[] btn { get; set; }
        public TabControl tabControl;

        public ButtonForm()
        {
            InitializeComponent();
        }

        private void ButtonForm_Load(object sender, EventArgs e)
        {
            btn = new Button[8] { btn_search, btn_insert, btn_update, btn_delete, btn_save, btn_cancel, btn_print, btn_exit};
        }

        #region button_Click_시
        private void btn_func(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == null) return;
            Button btn = sender as Button;

            if (btn.Tag.Equals("btn_exit"))
            {
                Application.Exit();
                return;
            }

            string btn_tag = (String)btn.Tag;
            Form form = (Form)tabControl.SelectedTab.Controls[0];

            if (btn_tag == null || form == null) return;

            utility.btn_ref_func(btn_tag, form);
        }
        #endregion
    }
}
