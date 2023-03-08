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
using Gbjproject;

namespace Gbjproject
{
    class utility
    {
        private string dir;
        private string ucName;

        public utility(string dir, string ucName)
        {
            this.dir = dir;
            this.ucName = ucName;
        }

        #region UserControl_정보_불러오기
        public UserControl UC()
        {
            UserControl uc = TryLoad_UserControl_ByName(dir, ucName);

            if (uc == null) return null;
            else return uc;
        }
        #endregion

        #region UserControl_정보_찾기
        private UserControl TryLoad_UserControl_ByName(string dir, string ucName)
        {
            Assembly ass;
            try
            {
                ass = Assembly.LoadFile(dir + ucName + ".dll");
            }
            catch
            {
                MessageBox.Show("해당 단위업무 파일이 존재하지 않습니다.");
                return null;
            }
            Type vType = ass.GetType(ucName + "." + ucName);
            if (vType == null)
            {
                //this.Hide();
                MessageBox.Show("해당업무 화면명이 올바르게 지정되지 않았습니다.");
                //this.Close();
                return null;
            }

            return Activator.CreateInstance(vType) as UserControl;
        }
        #endregion

        #region Button_Control1
        static public void BtnControl_func(Button[] btn, string func)
        {
            if (btn.Length == 0) return;
            /*
             *  0 : 조회, 1 : 입력, 2 : 수정, 3 : 삭제, 4 : 저장, 5 : 취소, 6 : 인쇄, 7 : 종료
             */
            string btn_func = "00000000";

            // 종료는 항상 true
            if (func.Equals("0")) btn_func = "10000001";    // 조회 true -- 조회만 가능한 곳에 사용
            if (func.Equals("1")) btn_func = "11110001";    // 조회, 입력, 수정, 삭제 true -- 입력, 수정, 삭제가 가능한 곳에 초기 상태
            if (func.Equals("2")) btn_func = "01111101";    // 입력, 수정, 삭제, 저장, 취소 true -- 입력 또는 수정 버튼 누른 후
            if (func.Equals("2")) btn_func = "01110001";    // 입력, 수정, 삭제 true -- 확인 또는 취소 버튼 누른 후

            SetFuncBtn2(btn, btn_func);
        }
        #endregion

        #region Button_control2
        static private string SetFuncBtn2(Button[] btn, string func)
        {
            if (btn.Length == 0) return "";
            if (string.IsNullOrEmpty(func)) return "";
            if (func.Length != 8) return "";
            
            //아스키코드값을 바이트로 변환 
            //ASCII string to byte!

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(func);

            //버튼0번째에 bytes[0]번째가 1이면 true 아니면 false
            for (int i = 0; i < bytes.Length; i++)
            {
                btn[i].Enabled = bytes[i] == '1' ? true : false;
            }
            return func;
        }
        #endregion

        #region button_reflection
        static public void btn_ref_func(String btn_tag, Form form)
        {
            if (btn_tag == null)
            {
                MessageBox.Show("버튼 태그 값을 받아오지 못했습니다.");
                return;
            }

            if (form == null)
            {
                MessageBox.Show("Form 정보를 받아오지 못했습니다.");
                return;
            }

            Type type = form.GetType();

            //btn_tag의 이름으로 메소드 생성
            MethodInfo mtd = type.GetMethod(btn_tag);

            if (mtd == null)
            {
                MessageBox.Show(btn_tag + " 메소드가 없습니다.");
                return;
            }

            //SelectedTab의 Form에서 mtd 메소드를 실행
            mtd.Invoke(form, null);
        }
        #endregion

        #region Oracle_Connection
        static public OracleConnection SetOracleConnection()
        {
            OracleConnection con = null;
            try
            {
                string connectString = "Data Source = 222.237.134.74:1522/ora7;User Id = edu;Password=edu1234";
                con = new OracleConnection(connectString);
                con.Open();
                return con;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return null;
            }
        }
        #endregion

        #region control에_있는_col_name의_이름을_가진_컨트롤_찾기
        static public Control GetControlByName(Control control, String col_name)
        {
            // dataGridView의 column Name 앞에 tb_를 붙여 panel2에 있는 TextBox들 Name과 일치 시키기
            string ctrl_name = "tb_" + col_name;

            // control 안에 있는 ctrl_name의 이름을 가진 컨트롤을 배열에 넣고
            Control[] ctrl = control.Controls.Find(ctrl_name, true);

            // ctrl의 길이가 0이면(없다) null, 그렇지 않으면 그 컨트롤을 반환
            return ctrl.Length == 0 ? null : ctrl[0];
        }
        #endregion

        #region errorProvider_사용
        static public void error_use_func(TextBox[] tb, ErrorProvider error)
        {
            for (int i = 0; i < tb.Length; i++)
            {
                if (String.IsNullOrEmpty(tb[i].Text))
                {
                    error.SetError(tb[i], "값이 비어있습니다.");
                    tb[i].BackColor = Color.White;
                }
            }
        }
        #endregion

        #region errorProvider_해제
        static public void error_clear_func(TextBox[] tb, ErrorProvider error, object sender)
        {
            TextBox text = (TextBox)sender;

            for (int i = 0; i < tb.Length; i++)
            {
                if (text.Name.Equals(tb[i].Name))
                {
                    error.SetError(tb[i], "");
                    tb[i].BackColor = Color.White;
                }
                else { continue; }
            }
        }
        #endregion

        #region 알림메세지
        static public string message_func(string msg)
        {
            string message="";

            if (msg.Equals("조회"))
            {   
                message = "자료가 조회되었습니다.";
            }

            if (msg.Equals("저장"))
            {
                message = "자료가 저장되었습니다.";
            }

            if (msg.Equals("X"))
            {
                message = "자료가 없습니다.";
            }

            return message;
        }
        #endregion

        #region Text.split(한글찾기)
        static public string split_func(ComboBox combo)
        {
            String[] combos = combo.Text.Split(':');
            byte[] vs;
            int value;
            int i = 0;

            for (i = 0; i < combos.Length; i++)
            {
                // combos[i]의 값을 아스키코드 값으로 변환해 한글인지 아닌지 판단하기 위해 byte 배열에 값 할당
                vs = Encoding.Default.GetBytes(combos[i]);

                // vs[i] 값을 Int형으로 변환하여 아스키 코드의 값으로 된다.
                value = Convert.ToInt32(vs[i].ToString());

                if (value <= 127) break;
                else continue;
            }

            return combos[i];
        }
        #endregion

        #region Panel_Control에_있는_TextBox.Text=empty,CheckBox.Checked=false
        static public void text_empty_func(Panel panel)
        {
            // Control타입 ctrl에 panel에 있는 Conrtols를 하나씩 할당 
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is TextBox)
                {
                    // Control속성인 ctrl을 TextBox로 변경 후 그에 대한 정보를 TextBox속성인 txt에게 할당 후 text=""처리
                    TextBox txt = (ctrl as TextBox);
                    txt.Text = String.Empty;
                }

                if (ctrl is CheckBox)
                {
                    CheckBox chk = (ctrl as CheckBox);
                    chk.Checked = false;
                }
            }
        }
        #endregion

        #region panel_enabled
        static public void panel_enable_func(Panel panel, DataGridViewRow row)
        {
            string sts = row.Cells["status"].Value?.ToString();
            bool status = sts == "U" || sts == "A" ? true : false;

            panel.Enabled = status;
        }
        #endregion
    }
}
