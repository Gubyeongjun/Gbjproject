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
    public partial class empBas : Form
    {
        private bool status_src = false;    // 조회 시 status가 U로 바뀌는 것을 방지
        private bool sts_readonly = false;  // 추가 입력 시 tb_dept_cd가 readOnly로 바뀌는 것을 방지

        string[] str { get; set; }

        TextBox[] tb;
        ComboBox[] combos { get; set; }
        public Button[] btn { get; set; }
        public string btn_status { get; set; }  // 현재 form의 버튼 상태 저장 후에 다시 현재 form으로 돌아왔을 때 버튼 상태 불러오기

        public empBas()
        {
            InitializeComponent();
        }

        #region FormLoad
        private void empMgr1_Load(object sender, EventArgs e)
        {
            combos = new ComboBox[5] { tb_bas_acc_bank, tb_bas_dut, tb_bas_mil_mil, tb_bas_pos, tb_bas_mil_rnk };

            OracleConnection con = null;

            // 값을 넣어줄 ComboBox의 Item이 있을 수 있으므로 Clear 후 Add
            for (int i = 0; i < combos.Length; i++)
            {
                combos[i].Items.Clear();
                combos[i].Items.Add("");
            }

            try
            {
                con = utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandText = SQL.SQL_bas.bas_load;
                cmd.ExecuteNonQuery();

                OracleDataReader odr = cmd.ExecuteReader();

                while (odr.Read())
                {
                    for (int i = 0; i < combos.Length; i++)
                    {
                        // combos[i].Name에서 마지막 '_'의 index값
                        int lastindex = combos[i].Name.LastIndexOf('_');
                        // 마지막 '_' 뒤 문자열을 대문자로 치환
                        string upcom = combos[i].Name.Substring(lastindex + 1).ToUpper();

                        // BANK일 경우 DB에 있는 이름과 동일 시 하기 위해 BNK로 변경
                        if (combos[i].Name.Substring(lastindex + 1).ToUpper() == "BANK") 
                            upcom = "BNK";
                        
                        // 각 ComboBox의 맞는 값을 전달하기 위해 이름이 같은지 비교 후 Item 추가
                        if ((String)odr["unit_grpcd"] == upcom)
                        {
                            // unit == unit_cd|| ':' ||unit_nm2  
                            combos[i].Items.Add((String)odr["unit"]);
                        }
                        else continue;
                    }
                }
                odr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null) con.Close();
            }

            utility.BtnControl_func(btn,"0");
            /*panel3.Enabled = false;*/
        }
        #endregion

        #region 부서검색화면_띄우고_선택한_값_참조변수_result로_넘겨주기
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
        #endregion

        #region 부서검색버튼
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
        #endregion

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
                cmd.Parameters.Add("pos", OracleDbType.Varchar2).Value = "%" + tb_bas_pos.Text + "%";
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

            utility.panel_enable_func(panel5, dataGridView1.SelectedRows[0]);
            utility.panel_enable_func(panel6, dataGridView1.SelectedRows[0]);
            btn_status = utility.BtnControl_func(btn, "2");
        }
        #endregion

        #region 삭제버튼
        public void btnDelete_Click()
        {
            if (dataGridView1.RowCount <= 0)
            {
                MessageBox.Show("삭제할 자료가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.CurrentRow;

            if (row == null) return;

            if (row.Cells["status"].Value?.ToString() == "A")
            {
                dataGridView1.Rows.RemoveAt(row.Index);
            }
            else if (MessageBox.Show("사원번호 : " + row.Cells["bas_empno"].Value.ToString() + 
                                     "\n성명 : " + row.Cells["bas_name"].Value.ToString() + 
                                     "\n부서 : " + row.Cells["bas_dept"].Value.ToString() + 
                                     "\n직급 : " + row.Cells["bas_pos"].Value.ToString() + 
                                     "\n해당 자료를 삭제하시겠습니까?"
                                     , "삭제알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                OracleConnection con = null;
                ora_cud_func(con, row, "D");
                dataGridView1.Rows.RemoveAt(row.Index);
            }
            else { return; }
        }
        #endregion

        #region 저장버튼
        public void btnSave_Click()
        {
            OracleConnection con = null;

            str = new string[] { tb_bas_empno.Name, tb_bas_name.Name, tb_bas_resno.Name };

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[1];

                if (String.IsNullOrEmpty(dataGridView1.Rows[i].Cells["status"].Value?.ToString()))
                    continue;

                for (int j = 0; j < str.Length; j++)
                {
                    if (String.IsNullOrEmpty(dataGridView1.Rows[i].Cells[str[j].Substring(3)].Value?.ToString()))
                    {
                        // tb자리에 사원번호, 주민등록번호, 성명(한글)이 있는 값 넣기 - db not null
                        utility.error_use_func(str, panel4, errorProvider1);
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[str[j].Substring(3)];
                        MessageBox.Show("빈칸에 값을 입력해주세요.");
                        return;
                    }
                }

                DataGridViewRow row = dataGridView1.Rows[i];
                string sts = row.Cells["status"].Value.ToString();

                if (sts == null) continue;
                else ora_cud_func(con, row, sts);
            }

            int k = 0;
            while (k < dataGridView1.RowCount)
            {
                if (!(String.IsNullOrEmpty(dataGridView1.Rows[k].Cells["status"].Value?.ToString())))
                    dataGridView1.Rows[k].Cells["status"].Value = String.Empty;
                k++;
            }

            MessageBox.Show("저장되었습니다.");
            /*utility.panel_enable_func(tableLayoutPanel2, dataGridView1.SelectedRows[0]);//index < 0 error*/
            btn_status = utility.BtnControl_func(btn, "1");
        }
        #endregion

        #region 취소버튼
        public void btnCancel_Click()
        {
            int a = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells["status"].Value?.ToString() != null) a++;
                else continue;
            }

            string msg = "현재 " + a + "건의 작업이 완료되지 않았습니다.\n완료되지 않은 작업을 취소하시겠습니까?";

            if (MessageBox.Show(msg, "작업 취소 알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                status_src = true;
                dataGridView1.Rows.Clear();
                status_src = false;
                btn_status = utility.BtnControl_func(btn, "0");
            }
            else return;

            /*for (int i = 0; i < tb.Length; i++)
                utility.error_clear_func(tb, errorProvider1, tb[i]);*/
        }
        #endregion

        #region Oracle_data_CUD(create,update,delete)
        private void ora_cud_func(OracleConnection con, DataGridViewRow row, string kind)
        {
            OracleTransaction tran = null;

            try
            {
                // oracle 접속
                con = utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();
                tran = con.BeginTransaction(IsolationLevel.ReadCommitted);

                // Oracle에서 쿼리 실행 시 오류 방지하기
                cmd.BindByName = true;

                if (kind.Equals("A"))
                {
                    // oracleDB에 선택된 행의 값 insert하기
                    cmd.CommandText = SQL.SQL_bas.bas_insert;
                    cmd.Parameters.Add("empno", OracleDbType.Varchar2).Value = row.Cells["bas_empno"].Value;
                    cmd.Parameters.Add("resno", OracleDbType.Varchar2).Value = row.Cells["bas_resno"].Value;
                    cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = row.Cells["bas_name"].Value;
                    cmd.Parameters.Add("cname", OracleDbType.Varchar2).Value = row.Cells["bas_cname"].Value;
                    cmd.Parameters.Add("ename", OracleDbType.Varchar2).Value = row.Cells["bas_ename"].Value;
                    cmd.Parameters.Add("fix", OracleDbType.Varchar2).Value = row.Cells["bas_fix"].Value;
                    cmd.Parameters.Add("zip", OracleDbType.Varchar2).Value = row.Cells["bas_zip"].Value;
                    cmd.Parameters.Add("addr", OracleDbType.Varchar2).Value = row.Cells["bas_addr"].Value;
                    cmd.Parameters.Add("hdpno", OracleDbType.Varchar2).Value = row.Cells["bas_hdpno"].Value;
                    cmd.Parameters.Add("telno", OracleDbType.Varchar2).Value = row.Cells["bas_telno"].Value;
                    cmd.Parameters.Add("email", OracleDbType.Varchar2).Value = row.Cells["bas_email"].Value;
                    cmd.Parameters.Add("mil_sta", OracleDbType.Varchar2).Value = row.Cells["bas_mil_sta"].Value;
                    cmd.Parameters.Add("mil_mil", OracleDbType.Varchar2).Value = row.Cells["bas_mil_mil"].Value;
                    cmd.Parameters.Add("mil_rnk", OracleDbType.Varchar2).Value = row.Cells["bas_mil_rnk"].Value;
                    cmd.Parameters.Add("mar", OracleDbType.Varchar2).Value = row.Cells["bas_mar"].Value;
                    cmd.Parameters.Add("acc_bank", OracleDbType.Varchar2).Value = row.Cells["bas_acc_bank"].Value;
                    cmd.Parameters.Add("acc_name", OracleDbType.Varchar2).Value = row.Cells["bas_acc_name"].Value;
                    cmd.Parameters.Add("acc_no", OracleDbType.Varchar2).Value = row.Cells["bas_acc_no"].Value;
                    cmd.Parameters.Add("cont", OracleDbType.Varchar2).Value = row.Cells["bas_cont"].Value;
                    cmd.Parameters.Add("emp_sdate", OracleDbType.Varchar2).Value = row.Cells["bas_emp_sdate"].Value;
                    cmd.Parameters.Add("emp_edate", OracleDbType.Varchar2).Value = row.Cells["bas_emp_edate"].Value;
                    cmd.Parameters.Add("entdate", OracleDbType.Varchar2).Value = row.Cells["bas_entdate"].Value;
                    cmd.Parameters.Add("resdate", OracleDbType.Varchar2).Value = row.Cells["bas_resdate"].Value;
                    cmd.Parameters.Add("levdate", OracleDbType.Varchar2).Value = row.Cells["bas_levdate"].Value;
                    cmd.Parameters.Add("reidate", OracleDbType.Varchar2).Value = row.Cells["bas_reidate"].Value;
                    cmd.Parameters.Add("dptdate", OracleDbType.Varchar2).Value = row.Cells["bas_dptdate"].Value;
                    cmd.Parameters.Add("jkpdate", OracleDbType.Varchar2).Value = row.Cells["bas_jkpdate"].Value;
                    cmd.Parameters.Add("posdate", OracleDbType.Varchar2).Value = row.Cells["bas_posdate"].Value;
                    cmd.Parameters.Add("wsta", OracleDbType.Varchar2).Value = row.Cells["bas_wsta"].Value;
                    cmd.Parameters.Add("pos", OracleDbType.Varchar2).Value = row.Cells["bas_pos"].Value;
                    cmd.Parameters.Add("dut", OracleDbType.Varchar2).Value = row.Cells["bas_dut"].Value;
                    cmd.Parameters.Add("dept", OracleDbType.Varchar2).Value = row.Cells["bas_dept"].Value;
                    cmd.Parameters.Add("rmk", OracleDbType.Varchar2).Value = row.Cells["bas_rmk"].Value;

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();  //*----반드시 포함
                }
                else if (kind.Equals("U"))
                {
                    // oracleDB에 선택된 행의 값 insert하기
                    cmd.CommandText = SQL.SQL_bas.bas_update;
                    cmd.Parameters.Add("", OracleDbType.Varchar2).Value = row.Cells[""].Value;

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();  //*----반드시 포함
                }
                else if (kind.Equals("D"))
                {
                    // oracleDB에 선택된 행의 값 insert하기
                    cmd.CommandText = SQL.SQL_bas.bas_delete;
                    cmd.Parameters.Add("", OracleDbType.Varchar2).Value = row.Cells[""].Value;

                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (con != null) con.Close();
                tran.Dispose();
            }
        }
        #endregion

        private void tb_bas_empno_TextChanged(object sender, EventArgs e)
        {
            if (status_src == true) return;
            if (sts_readonly == true) return;

            DataGridViewRow row = dataGridView1.CurrentRow;

            if (row == null) return;

            // event가 실행된 object control
            Control control = sender as Control;

            // event가 실행된 object control의 Type을 할당
            Type type = control.GetType();

            // type변수의 Type에서 Text의 속성을 info에 할당
            PropertyInfo info = type.GetProperty("Text");

            if (info == null) return;

            // 후에 각각 맞는 column에 control object의 값을 전달하기 위해
            // control object의 이름을 substring하여 dataGridView column 이름과 같게 만든다.
            string col_name = control.Name.Substring(3);

            // control의 Text 속성에 있는 값을 txt 변수에 할당
            string txt = info.GetValue(control).ToString();

            // 현재 선택되어 있는 행의 셀 이름이 col_name인 곳에 txt 값을 할당
            row.Cells[col_name].Value = txt.Replace("-","");

            if (String.IsNullOrEmpty((String)row.Cells["status"].Value))
            {
                row.Cells["status"].Value = "U";
            }
        }
    }
}
