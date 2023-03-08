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
        private bool status_src = false;    // 조회 시 status가 U로 바뀌는 것을 방지
        private bool sts_readonly = false;  // 추가 입력 시 tb_dept_cd가 readOnly로 바뀌는 것을 방지

        TextBox[] tb;
        public Button[] btn { get; set; }
        public string btn_status { get; set; }  // 현재 form의 버튼 상태 저장 후에 다시 현재 form으로 돌아왔을 때 버튼 상태 불러오기

        public empMgr1()
        {
            InitializeComponent();
        }

        private void empMgr1_Load(object sender, EventArgs e)
        {
            utility.BtnControl_func(btn,"0");
            /*panel3.Enabled = false;*/
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
            tb = new TextBox[2] { src_dept, tb_bas_dept };

            for (int i = 0; i < tb.Length; i++)
            {
                if (btn_tag.Equals(tb[i].Tag))
                {
                    tb[i].Text = show_dept_search_func(out string result);
                    break;
                }   
            }
        }

        #region 조회버튼
        public void btnSearch_Click()
        {
            status_src = true;  //selectionchanged event 발생 회피
            dataGridView1.Rows.Clear();


            OracleConnection con = null;

            int rowIdx = 0;
            DataGridViewRow row;

            try
            {
                // oracle 접속
                con = utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();

                // Oracle에서 쿼리 실행 시 오류 방지하기
                cmd.BindByName = true;

                // OracleDB gbj_bas select
                cmd.CommandText = SQL.SQL_bas.bas_select;
                cmd.Parameters.Add("empno", OracleDbType.Varchar2).Value = "%" + tb_bas_empno.Text + "%";
                cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = "%" + tb_bas_name.Text + "%";
                /*if(odr["grp"].ToString().IndexOf(':') != -1) { combos[1].Items.Add(odr["grp"].ToString().Substring(0, odr["grp"].ToString().IndexOf(':'))); }*/
                if (tb_bas_dept.Text.IndexOf(':') != -1) { cmd.Parameters.Add("dept", OracleDbType.Varchar2).Value = "%" + tb_bas_dept.Text.Substring(0, tb_bas_dept.Text.IndexOf(':')) + "%"; }
                else { cmd.Parameters.Add("dept", OracleDbType.Varchar2).Value = "%"+String.Empty+"%"; }
                cmd.Parameters.Add("pos", OracleDbType.Varchar2).Value = "%" + cb_bas_pos.Text + "%";
                cmd.ExecuteNonQuery();

                OracleDataReader odr = cmd.ExecuteReader();

                while (odr.Read())
                {
                    rowIdx = dataGridView1.Rows.Add();
                    row = dataGridView1.Rows[rowIdx];

                    row.Cells["bas_empno"].Value = (String)odr["bas_empno"];

                    /*row.Cells["dept_seq"].Value = odr["dept_seq"] == null ? 0 : (Decimal)odr["dept_seq"];*/
                }
                odr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                status_src = false;
                if (con != null) con.Close();
            }

            btn_status = utility.BtnControl_func(btn, "1");
        }
        #endregion

        #region 추가버튼
        public void btnInsert_Click()
        {
            status_src = false;

            // 선택되어있는 행이 null이면 0을 할당, 있으면 그 행의 Index 값을 할당
            var rowIdx = dataGridView1.CurrentRow == null ? 0 : dataGridView1.CurrentRow.Index;


            if (dataGridView1.Rows.Count == 0)
            {
                rowIdx = dataGridView1.Rows.Add();
            }
            else
            {
                // Index 값에 + 1 한 후에 그 위치에 Row 추가하기
                rowIdx++;
                dataGridView1.Rows.Insert(rowIdx);
            }

            // 행의 상태를 추가 상태 = "A" 로 변경
            dataGridView1.Rows[rowIdx].Cells["status"].Value = "A";


            // 추가한 행으로 컨트롤 활성화
            dataGridView1.CurrentCell = dataGridView1.Rows[rowIdx].Cells[1];
            tb_bas_empno.Focus();
            btn_status = utility.BtnControl_func(btn, "2");
        }
        #endregion

        #region 수정버튼
        public void btnUpdate_Click()
        {
            if (dataGridView1.RowCount <= 0) return;

            // 수정버튼 클릭 시 저장, 취소 버튼 활성화
            // 수정 버튼 클릭 전 까지 textbox readonly true, checkbox enabled false; <- 이 말이 의미는 수정 버튼을 눌렀을 때 2줄 밑 panel_enable_func실행 하겠단 뜻
            dataGridView1.SelectedRows[0].Cells["status"].Value = "U";

            utility.panel_enable_func(panel2, dataGridView1.SelectedRows[0]);
            btn_status = utility.BtnControl_func(btn, "2");
        }
        #endregion

        #region 삭제버튼
        public void btnDelete_Click()
        {

        }
        #endregion

        #region 저장버튼
        public void btnSave_Click()
        {

        }
        #endregion

        #region 취소버튼
        public void btnCancel_Click()
        {

        }
        #endregion

        #region Oracle_data_CUD(create,update,delete)
        private void ora_cud_func(OracleConnection con, DataGridViewRow row, string kind)
        {
            try
            {
                if (kind.Equals("A"))
                {
                    // oracle 접속
                    con = utility.SetOracleConnection();
                    OracleCommand cmd = con.CreateCommand();

                    // Oracle에서 쿼리 실행 시 오류 방지하기
                    cmd.BindByName = true;

                    // oracleDB에 선택된 행의 값 insert하기
                    cmd.CommandText = SQL.SQL_bas.bas_insert;
                    cmd.Parameters.Add("", OracleDbType.Varchar2).Value = row.Cells[""].Value;

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();  //*----반드시 포함
                }
                else if (kind.Equals("U"))
                {
                    // oracle 접속
                    con = utility.SetOracleConnection();
                    OracleCommand cmd = con.CreateCommand();

                    // Oracle에서 쿼리 실행 시 오류 방지하기
                    cmd.BindByName = true;

                    // oracleDB에 선택된 행의 값 insert하기
                    cmd.CommandText = SQL.SQL_bas.bas_update;
                    cmd.Parameters.Add("", OracleDbType.Varchar2).Value = row.Cells[""].Value;

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();  //*----반드시 포함
                }
                else if (kind.Equals("D"))
                {
                    // oracle 접속
                    con = utility.SetOracleConnection();
                    OracleCommand cmd = con.CreateCommand();

                    // Oracle에서 쿼리 실행 시 오류 방지하기
                    cmd.BindByName = true;

                    // oracleDB에 선택된 행의 값 insert하기
                    cmd.CommandText = SQL.SQL_bas.bas_delete;
                    cmd.Parameters.Add("", OracleDbType.Varchar2).Value = row.Cells[""].Value;

                    cmd.ExecuteNonQuery();
                }
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
        #endregion
    }
}
