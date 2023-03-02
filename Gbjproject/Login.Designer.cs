
namespace Gbjproject
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.check_saveid = new System.Windows.Forms.CheckBox();
            this.exit_btn = new System.Windows.Forms.Button();
            this.login_btn = new System.Windows.Forms.Button();
            this.pwd_tb = new System.Windows.Forms.TextBox();
            this.id_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.check_saveid);
            this.panel1.Controls.Add(this.exit_btn);
            this.panel1.Controls.Add(this.login_btn);
            this.panel1.Controls.Add(this.pwd_tb);
            this.panel1.Controls.Add(this.id_tb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 285);
            this.panel1.TabIndex = 0;
            // 
            // check_saveid
            // 
            this.check_saveid.AutoSize = true;
            this.check_saveid.Location = new System.Drawing.Point(302, 69);
            this.check_saveid.Name = "check_saveid";
            this.check_saveid.Size = new System.Drawing.Size(63, 16);
            this.check_saveid.TabIndex = 7;
            this.check_saveid.Text = "ID 저장";
            this.check_saveid.UseVisualStyleBackColor = true;
            // 
            // exit_btn
            // 
            this.exit_btn.Location = new System.Drawing.Point(302, 172);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(63, 41);
            this.exit_btn.TabIndex = 3;
            this.exit_btn.Text = "종료";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(175, 172);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(113, 41);
            this.login_btn.TabIndex = 2;
            this.login_btn.Text = "로그인";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // pwd_tb
            // 
            this.pwd_tb.Location = new System.Drawing.Point(175, 123);
            this.pwd_tb.Name = "pwd_tb";
            this.pwd_tb.Size = new System.Drawing.Size(113, 21);
            this.pwd_tb.TabIndex = 1;
            this.pwd_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.id_tb_KeyDown);
            // 
            // id_tb
            // 
            this.id_tb.Location = new System.Drawing.Point(175, 67);
            this.id_tb.Name = "id_tb";
            this.id_tb.Size = new System.Drawing.Size(113, 21);
            this.id_tb.TabIndex = 0;
            this.id_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.id_tb_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15F);
            this.label2.Location = new System.Drawing.Point(57, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "비밀번호";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(57, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "아이디";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 285);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.TextBox pwd_tb;
        private System.Windows.Forms.TextBox id_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox check_saveid;
    }
}