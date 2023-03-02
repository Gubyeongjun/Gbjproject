using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Oracle.ManagedDataAccess.Client;

namespace Gbjproject
{
    public partial class empMgr1 : Form
    {
        TextBox[] textBox;
        
        public empMgr1()
        {
            InitializeComponent();
        }

        private void empMgr1_Load(object sender, EventArgs e)
        {
            panel3.Enabled = false;
        }

        private string show_dept_search_func(out string result)
        {
            /*string btn_tag = (sender as Button).Tag as string;

            if (!btn_tag.Equals("Dept_Search")) return;

            btn_tag = btn_tag.Replace("_", "");

            Type formType = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.BaseType == typeof(Form) && t.Name == btn_tag)
                .FirstOrDefault();

            if (formType == null)
            {
                MessageBox.Show(btn_tag + " 수행 프로그램이 존재하지 않습니다.");
                return;
            }

            // 동적으로 formType instance를 생성
            // instance 생성하려면 System.Activator 클래스를 사용해야 한다.
            Form form = (Form)Activator.CreateInstance(formType);
            if (form == null)
            {
                MessageBox.Show(btn_tag + " 수행 프로그램이 존재하지 않습니다.");
                return;
            }

            form.ShowDialog();*/

            // 새로운 form을 열되 값을 다시 전달해줘야 하므로 참조 변수를 사용하기

            var dp_src_form = new DeptSearch();
            dp_src_form.ShowDialog();
            result = dp_src_form.GetResult;
            dp_src_form.Dispose();

            return result;
        }

        private void btn_src_dept1_Click(object sender, EventArgs e)
        {
            string btn_tag = (sender as Button).Tag as string;
            textBox = new TextBox[2] { src_dept, tb_dept };

            for (int i = 0; i < textBox.Length; i++)
            {
                if (btn_tag.Equals(textBox[i].Tag))
                {
                    textBox[i].Text = show_dept_search_func(out string result);
                    break;
                }   
            }
        }

        public void btnSearch_Click()
        {

        }
    }
}
