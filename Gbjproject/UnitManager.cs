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
    public partial class UnitManager : Form
    {
        private bool status_src = false;    // 조회 시 status가 U로 바뀌는 것을 방지
        private bool sts_readonly = false;  // 추가 입력 시 tb_dept_cd가 readOnly로 바뀌는 것을 방지

        TextBox[] tb { get; set; }
        ComboBox[] combos { get; set; }

        public Button[] btn { get; set; }
        public string btn_status { get; set; }
        public UnitManager()
        {
            InitializeComponent();
        }

        #region Form_Load
        private void UnitManager_Load(object sender, EventArgs e)
        {
            tb = new TextBox[4] { tb_unit_cd, tb_unit_nm1, tb_unit_nm2, tb_unit_seq };
            combos = new ComboBox[4] { src_unit_grpcd, comboBox1, comboBox2, comboBox3 };

            panel3.Enabled = false;

            if (combos[1].Visible == true || combos[2].Visible == true || combos[3].Visible == true)
            {
                combos[1].Visible = false;
                combos[2].Visible = false;
                combos[3].Visible = false;
            }

            OracleConnection con = null;

            try
            {
                con = utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandText = SQL.SQL_Select.unit_grp;
                cmd.ExecuteNonQuery();

                OracleDataReader odr = cmd.ExecuteReader();

                combos[0].Items.Add("");
                combos[1].Items.Add("");
                combos[2].Items.Add("");
                combos[3].Items.Add("");

                while (odr.Read())
                {
                    combos[0].Items.Add((String)odr["grp"]);
                    if(odr["grp"].ToString().IndexOf(':') != -1) { combos[1].Items.Add(odr["grp"].ToString().Substring(0, odr["grp"].ToString().IndexOf(':'))); }
                    combos[2].Items.Add(odr["cdg_length"]);
                    combos[3].Items.Add(odr["cdg_nmleng"]);
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

            combos[0].SelectedIndex = 0;

            btn_status = utility.BtnControl_func(btn, "0");
        }
        #endregion

        #region 조회버튼
        public void btnSearch_Click()
        {
            status_src = true;  //selectionchanged event 발생 회피
            dataGridView1.Rows.Clear();
            panel3.Enabled = true;
            OracleConnection con = null;

            int rowIdx = 0;
            DataGridViewRow row;

            try
            {
                con = utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();

                // Oracle에서 쿼리 실행 시 오류 방지하기
                cmd.BindByName = true;

                // SQL 파일에서 cdg Table 정보를 select 하는 쿼리문 가져오기
                cmd.CommandText = SQL.SQL_Select.unit_all;
                cmd.Parameters.Add("grpcd", OracleDbType.Varchar2).Value = "%" + combo_item_func(combos[0]) + "%";
                cmd.Parameters.Add("unit_nm", OracleDbType.Varchar2).Value = "%" + src_unit_nm.Text + "%";
                cmd.ExecuteNonQuery();

                OracleDataReader odr = cmd.ExecuteReader();

                while (odr.Read())
                {
                    rowIdx = dataGridView1.Rows.Add();
                    row = dataGridView1.Rows[rowIdx];
                    row.Cells["unit_grpcd"].Value = (String)odr["unit_grpcd"];
                    row.Cells["unit_cd"].Value = (String)odr["unit_cd"];
                    row.Cells["unit_nm1"].Value = (String)odr["unit_nm1"];
                    row.Cells["unit_nm2"].Value = (String)odr["unit_nm2"];
                    row.Cells["unit_seq"].Value = odr["unit_seq"];
                    row.Cells["unit_use"].Value = (String)odr["unit_use"] == "Y" ? true : false;
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

            this.dataGridView1_SelectionChanged(null, null);

            /*if (src_unit_grpcd.SelectedIndex == 0)
                btn_status = utility.BtnControl_func(btn, "0");
            else
                btn_status = utility.BtnControl_func(btn, "1");*/
            btn_status = utility.BtnControl_func(btn, "1");
        }
        #endregion

        #region 추가버튼
        public void btnInsert_Click()
        {
            if (combos[0].SelectedIndex == 0)
            {
                errorProvider1.SetError(combos[0], "그룹을 선택해주세요.");
                return;
            }

            status_src = false;

            // 선택되어있는 행이 null이면 0을 할당, 있으면 그 행의 Index 값을 할당
            var rowIdx = dataGridView1.CurrentRow == null ? 0 : dataGridView1.CurrentRow.Index;
            panel2.Enabled = true;

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
            dataGridView1.Rows[rowIdx].Cells["unit_grpcd"].Value = utility.split_func(combos[0]);
            dataGridView1.Rows[rowIdx].Cells["unit_use"].Value = false;

            // 추가한 행으로 컨트롤 활성화
            dataGridView1.CurrentCell = dataGridView1.Rows[rowIdx].Cells[1];
            tb_unit_cd.Focus();
            btn_status = utility.BtnControl_func(btn, "2");
        }
        #endregion

        #region 수정버튼
        public void btnUpdate_Click()
        {
            if (dataGridView1.RowCount <= 0) return;

            // 수정버튼 클릭 시 저장, 취소 버튼 활성화
            // 수정 버튼 클릭 전 까지 textbox readonly true, checkbox enabled false;
            dataGridView1.SelectedRows[0].Cells["status"].Value = "U";

            utility.panel_enable_func(panel3, dataGridView1.SelectedRows[0]);
            btn_status = utility.BtnControl_func(btn, "2");
        }
        #endregion

        #region 삭제버튼
        public void btnDelete_Click()
        {
            if (dataGridView1.RowCount <= 0)
            {
                MessageBox.Show("삭제할 행이 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.CurrentRow;

            if (row == null) return;

            if (row.Cells["status"].Value?.ToString() == "A")
            {
                dataGridView1.Rows.RemoveAt(row.Index);
            }
            else if (MessageBox.Show("단위코드 : " + row.Cells["unit_cd"].Value.ToString() + "\n코드명 : " +
                                row.Cells["unit_nm1"].Value.ToString() + "\n자료를 삭제하시겠습니까?"
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

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[1];

                if (String.IsNullOrEmpty(dataGridView1.Rows[i].Cells["status"].Value?.ToString()))
                    continue;

                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (String.IsNullOrEmpty(dataGridView1.Rows[i].Cells[j].Value?.ToString()))
                    {
                        utility.error_use_func(tb, errorProvider1);
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[j];
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
            utility.panel_enable_func(panel3, dataGridView1.SelectedRows[0]);
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

            for (int i = 0; i < tb.Length; i++)
                utility.error_clear_func(tb, errorProvider1, tb[i]);
        }
        #endregion

        #region panel3_controls_중_TextBox_TextChanged
        private void tb_unit_cd_TextChanged(object sender, EventArgs e)
        {
            if (status_src == true) return;
            if (sts_readonly == true) return;

            if (dataGridView1.SelectedRows.Count <= 0 && (sender as TextBox).Text != "")
            {
                MessageBox.Show("값을 전달한 행이 없습니다.");

                (sender as TextBox).Text = "";
                return;
            }

            DataGridViewRow row = dataGridView1.CurrentRow;

            if (row == null) return;

            // event가 실행된 object control
            Control control = sender as Control;

            // event가 실행된 object control의 Type을 할당
            Type type = control.GetType();

            // event가 실행된 object control의 type == TextBox일 것이다.
            // type변수의 Type(TextBox)에서 Text의 속성을 info에 할당
            PropertyInfo info = type.GetProperty("Text");

            if (info == null) return;

            // 후에 각각 맞는 column에 control object의 값을 전달하기 위해
            // control object의 이름을 substring하여 dataGridView column 이름과 같게 만든다.
            string col_name = control.Name.Substring(3);

            // control의 Text 속성에 있는 값을 txt 변수에 할당
            string txt = info.GetValue(control).ToString();

            // 현재 선택되어 있는 행의 셀 이름이 col_name인 곳에 txt 값을 할당
            row.Cells[col_name].Value = txt;

            if (String.IsNullOrEmpty((String)row.Cells["status"].Value))
            {
                row.Cells["status"].Value = "U";
            }
        }
        #endregion

        #region CheckBox_CheckedChanged_될_때
        private void tb_unit_use_CheckedChanged(object sender, EventArgs e)
        {
            if (status_src == true) return;
            if (sts_readonly == true) return;

            if (dataGridView1.SelectedRows.Count <= 0) return;

            DataGridViewRow row = dataGridView1.CurrentRow;

            if (row == null) return;

            CheckBox chk = (sender as CheckBox);

            dataGridView1.Rows[row.Index].Cells[chk.Name.Substring(3)].Value = chk.Checked == true ? true : false;

            if (String.IsNullOrEmpty((String)row.Cells["status"].Value))
            {
                row.Cells["status"].Value = "U";
            }
        }
        #endregion

        #region dataGridView_SelectionChanged
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (status_src == true) return; //조회 버튼 클릭 시 수행하지 않기 위해 return
            if (dataGridView1.RowCount <= 0) return;

            for (int i = 0; i < tb.Length; i++)
            {
                errorProvider1.SetError(tb[i], "");
                tb[i].BackColor = Color.White;
            }

            Type type;
            PropertyInfo info;
            Control control;
            sts_readonly = true;
            for (int col = 0; col < dataGridView1.ColumnCount; col++)
            {
                // select 된 행의 column[0]의 값이 "A"일 경우 tb_dept_cd.ReadOnly = false; 시키기
                /*tb_dept_cd.ReadOnly = (dataGridView1.SelectedRows[0].Cells["status"].Value?.ToString()) != "A" ? true : false;*/

                // panel2에 column이름을 가진 컨트롤이 있는지 검색
                control = utility.GetControlByName(panel3, dataGridView1.Columns[col].Name);

                // 찾지 못했으면 null이라 다음 column 검색하도록 continue;
                if (control == null) { continue; }

                // 찾았으면 그 컨트롤의 Type을 할당
                type = control.GetType();
                info = null;
                if (control is TextBox)
                {
                    // 컨트롤 Type의 속성 중 Text 속성을 할당
                    info = type.GetProperty("Text");

                    // Text 속성이 있다면 control의 Text에 선택된 행의 검색한 column의 값을 할당
                    if (info != null)
                    {
                        //Value?를 사용한 이유 >> 값이 null이면 null 반환, 값이 null이 아니면 value 값을 String으로 변환해서 반환
                        
                        info.SetValue(control, dataGridView1.SelectedRows[0].Cells[col].Value?.ToString());
                    }
                }
                else if (control is CheckBox)
                {
                    info = type.GetProperty("Checked");
                    if (info != null)
                    {
                        bool result = false;

                        if (dataGridView1.SelectedRows[0].Cells[col].Value == null) { result = false; }
                        else { result = (Boolean)dataGridView1.SelectedRows[0].Cells[col].Value; }

                        info.SetValue(control, result);
                    }
                    continue;
                }
            }
            sts_readonly = false;

            if (dataGridView1.SelectedRows[0].Cells["unit_grpcd"].Value?.ToString() == null) return;
            else combos[1].SelectedIndex = combos[1].Items.IndexOf(dataGridView1.SelectedRows[0].Cells["unit_grpcd"].Value);
        }
        #endregion

        #region TextBox_컨트롤이_활성화_되었을_때(errorProvider)
        private void tb_unit_cd_Enter(object sender, EventArgs e)
        {
            utility.error_clear_func(tb, errorProvider1, sender);
        }
        #endregion

        #region 검색창에서_Enter키_눌렀을_때
        private void src_unit_nm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click();
            }
        }
        #endregion

        #region dataGridView_RowsRemoved_됐을_때(RowCount<=0)
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView1.RowCount <= 0) utility.text_empty_func(panel3);
        }
        #endregion

        #region comboBox_SelectedIndexChanged
        private void src_unit_grpcd_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(combos[0], "");

            combos[1].SelectedIndex = combos[0].SelectedIndex;
            
            /*combos[2].SelectedIndex = combos[0].SelectedIndex;
            combos[3].SelectedIndex = combos[0].SelectedIndex;*/

            // 버튼 컨트롤하기(src_unit_grpcd.index 변경 시 조회만 가능하도록 하고 조회 후 추가, 수정, 삭제 버튼 열기)
            // 버튼 컨트롤하기(src_unit_grpcd.index가 0일때는 조회만 가능하도록 하기)
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            combos[2].SelectedIndex = combos[1].SelectedIndex;
            combos[3].SelectedIndex = combos[1].SelectedIndex;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {   
            ComboBox combo = (sender as ComboBox);
            if (combo.SelectedIndex <= 0) return;
            if (combo.Name.Equals("comboBox2"))
            {
                tb_unit_cd.MaxLength = int.Parse(combo.SelectedItem.ToString());
            }

            if (combo.Name.Equals("comboBox3"))
            {
                tb_unit_nm1.MaxLength = int.Parse(combo.SelectedItem.ToString());
                tb_unit_nm2.MaxLength = int.Parse(combo.SelectedItem.ToString());
            }
        }
        #endregion

        #region comboBox1_SelectedIndex.Value(Row_추가기입_시_cell["status"].value)
        private string combo_item_func(ComboBox combo)
        {
            string cmb;

            return cmb = combo.SelectedIndex == 0 ? String.Empty : utility.split_func(combo);
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
                    cmd.CommandText = SQL.SQL_insert.unit_insert;
                    cmd.Parameters.Add("grpcd", OracleDbType.Varchar2).Value = row.Cells["unit_grpcd"].Value;
                    cmd.Parameters.Add("cd", OracleDbType.Varchar2).Value = row.Cells["unit_cd"].Value;
                    cmd.Parameters.Add("nm1", OracleDbType.Varchar2).Value = row.Cells["unit_nm1"].Value;
                    cmd.Parameters.Add("nm2", OracleDbType.Varchar2).Value = row.Cells["unit_nm2"].Value;
                    cmd.Parameters.Add("seq", OracleDbType.Int32).Value = row.Cells["unit_seq"].Value;
                    cmd.Parameters.Add("use", OracleDbType.Varchar2).Value = (Boolean)row.Cells["unit_use"].Value == true ? "Y" : "N";

                    // sql 구문 실행
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();  //*----반드시 포함
                 }
                 else if (kind.Equals("U"))
                 {
                    con = utility.SetOracleConnection();
                    OracleCommand cmd = con.CreateCommand();

                    // Oracle에서 쿼리 실행 시 오류 방지하기
                    cmd.BindByName = true;

                    // oracleDB에 선택된 행의 값 update하기
                    cmd.CommandText = SQL.SQL_update.unit_update;
                    cmd.Parameters.Add("nm1", OracleDbType.Varchar2).Value = row.Cells["unit_nm1"].Value;
                    cmd.Parameters.Add("nm2", OracleDbType.Varchar2).Value = row.Cells["unit_nm2"].Value;
                    cmd.Parameters.Add("seq", OracleDbType.Int32).Value = row.Cells["unit_seq"].Value;
                    cmd.Parameters.Add("use", OracleDbType.Varchar2).Value = (Boolean)row.Cells["unit_use"].Value == true ? "Y" : "N";
                    cmd.Parameters.Add("grpcd", OracleDbType.Varchar2).Value = row.Cells["unit_grpcd"].Value;
                    cmd.Parameters.Add("cd", OracleDbType.Varchar2).Value = row.Cells["unit_cd"].Value;

                    // save_sql 구문 실행
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();  //*----반드시 포함
                 }
                 else if (kind.Equals("D"))
                 {
                     con = utility.SetOracleConnection();
                     OracleCommand cmd = con.CreateCommand();
                     cmd.BindByName = true;
                     cmd.CommandText = SQL.SQL_delete.unit_delete;
                     cmd.Parameters.Add("grpcd", OracleDbType.Varchar2).Value = row.Cells["unit_grpcd"].Value;
                     cmd.Parameters.Add("cd", OracleDbType.Varchar2).Value = row.Cells["unit_cd"].Value;
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
