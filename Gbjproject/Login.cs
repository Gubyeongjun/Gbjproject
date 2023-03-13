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
using System.Configuration;
using UCLogin;

namespace Gbjproject
{
    public partial class Login : Form
    {
        UCLogin.UCLogin ucl = new UCLogin.UCLogin();

        private bool save_check;    //form Load 시 ID저장 체크 유무 판단
        private string user_id;     

        private string dir = null;
        private string subdir = @"\";

        public Login()
        {
            InitializeComponent();
        }

        #region Form_Load_시(dll_파일_접근_및_ID저장_유무_판단)
        private void Login_Load(object sender, EventArgs e)
        {
            this.Location = new Point(640, 300);

            //exe파일이 위치한 경로
            dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            dir += subdir;

            var ucc = new utility(dir, "UCLogin");

            UserControl uc = ucc.UC();

            //*-------------------------------------------------------------------------
            //* 단위업무 DLL Check 및 프로그램 로드
            //*-------------------------------------------------------------------------
            /*UserControl uc = TryLoad_UserControl_ByName(dir + subdir, "UCMain");

            if (uc == null) return;*/

            //*-------------------------------------------------------------------------
            //* Loading UserControl에 초기값 전달
            //*-------------------------------------------------------------------------

            panel1.Controls.Add(uc);

            uc.Tag = "UCLogin";

            //Properties.Settings에 적어놓은 변수 값을 할당
            string userid_save = Properties.Settings.Default.userid_save;

            //userid_save == 1 이면 ID저장 check == true
            if (userid_save.Equals("1"))
            {
                check_saveid.Checked = true;
                id_tb.Text = Properties.Settings.Default.userid;
                user_id = id_tb.Text;
                save_check = true;
                pwd_tb.Focus();
            }
            else
            {
                check_saveid.Checked = false;
                save_check = false;
            }
        }
        #endregion

        #region 로그인_버튼_클릭_시
        private void login_btn_Click(object sender, EventArgs e)
        {
            //사용자가 입력한 id, pwd 검사
            int login_chk = ucl.checkLogin_Func(id_tb.Text, pwd_tb.Text);
            
            if (login_chk == 0)
            {
                MessageBox.Show("사용자 ID와 비밀번호를 입력하세요.", "로그인확인", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else if (login_chk == -1)
            {
                MessageBox.Show("사용자 ID 또는 비밀번호가 맞지 않습니다.", "로그인확인", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            bool change_check = false;

            //현재 체크 상태와 Properties.Settings에 있는 userid_save의 값이 다를 때
            if (check_saveid.Checked != save_check)
            {
                change_check = true;
            }
            //현재 체크 상태가 true면서 Properties.Settings에 있는 userid값과 id_tb.Text 값이 다를 때
            else if ((check_saveid.Checked == true) & (id_tb.Text != user_id))
            {
                change_check = true;
            }

            //사용자ID 및 저장 여부 변경 true일 때
            if (change_check == true)
            {
                try
                {
                    //Properties.Settings에 있는 userid, userid_save 값을 새로 할당 후 저장
                    Properties.Settings.Default.userid = id_tb.Text;
                    Properties.Settings.Default.userid_save = check_saveid.Checked == true ? "1" : "0";
                    Properties.Settings.Default.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            this.Hide();
            Main main = new Main(id_tb.Text, pwd_tb.Text);
            main.ShowDialog();
            this.Close();
        }
        #endregion

        #region 종료_버튼_클릭_시
        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        public void btnSearch_Click()
        {
            MessageBox.Show(this.Name + "btnSearch_Click");
        }

        private void id_tb_KeyDown(object sender, KeyEventArgs e)
        {
            press_Enter_func(e);
        }

        private void press_Enter_func(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                login_btn_Click(null, null);
            }
        }
    }
}
