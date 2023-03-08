using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Gbjproject
{
    public partial class DeptSearch : Form
    {   
        string result;

        public string GetResult
        {
            get { return result; }
        }

        public DeptSearch()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeptSearch_Load(object sender, EventArgs e)
        {
            this.Location = new Point(640, 180);

            dataGridView1.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;

            result = (String)dataGridView1.SelectedRows[0].Cells[0].Value + ":" +
                     (String)dataGridView1.SelectedRows[0].Cells[1].Value;

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection con = null;

            try
            {
                // oracleDB gbj_dept select 하기
                string search_dept_sql = @" select dept_cd, dept_nm1 from gbj_dept 
                                            where dept_nm1 like :dept_nm1 ";

                // oracle 접속
                con = utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();

                cmd.CommandText = search_dept_sql;
                cmd.Parameters.Add("dept_nm1", OracleDbType.Varchar2).Value = "%" + src_dept.Text + "%";

                // OracleDataAdapter로 메모리에 전체 값을 받아온다
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                
                // sql문에서 select한 column중 dataGridView Column의 DataPropertyName과 같은 곳에 값을 할당한다.
                // 이름이 맞는 곳이 없으면 column을 알아서 생성하여 그곳의 값을 넣게 된다.
                da.Fill(ds, "TAB");
                dataGridView1.DataSource = ds.Tables["TAB"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null) con.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;

            result = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value + ":" +
                     (String)dataGridView1.Rows[e.RowIndex].Cells[1].Value;

            this.Close();
        }
    }
}
