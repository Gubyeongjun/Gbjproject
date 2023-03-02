
namespace Gbjproject
{
    partial class PartManager
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_src = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_dept_use = new System.Windows.Forms.CheckBox();
            this.tb_dept_seq = new System.Windows.Forms.TextBox();
            this.tb_dept_nm2 = new System.Windows.Forms.TextBox();
            this.tb_dept_nm1 = new System.Windows.Forms.TextBox();
            this.tb_dept_cd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dept_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dept_nm1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dept_nm2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dept_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dept_use = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "부서명";
            // 
            // tb_src
            // 
            this.tb_src.Location = new System.Drawing.Point(94, 26);
            this.tb_src.Name = "tb_src";
            this.tb_src.Size = new System.Drawing.Size(100, 21);
            this.tb_src.TabIndex = 1;
            this.tb_src.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_src_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 347);
            this.panel1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.dept_cd,
            this.dept_nm1,
            this.dept_nm2,
            this.dept_seq,
            this.dept_use});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(519, 347);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tb_dept_use);
            this.panel2.Controls.Add(this.tb_dept_seq);
            this.panel2.Controls.Add(this.tb_dept_nm2);
            this.panel2.Controls.Add(this.tb_dept_nm1);
            this.panel2.Controls.Add(this.tb_dept_cd);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(530, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 347);
            this.panel2.TabIndex = 3;
            // 
            // tb_dept_use
            // 
            this.tb_dept_use.AutoSize = true;
            this.tb_dept_use.Location = new System.Drawing.Point(146, 223);
            this.tb_dept_use.Name = "tb_dept_use";
            this.tb_dept_use.Size = new System.Drawing.Size(15, 14);
            this.tb_dept_use.TabIndex = 6;
            this.tb_dept_use.UseVisualStyleBackColor = true;
            this.tb_dept_use.CheckedChanged += new System.EventHandler(this.tb_dept_use_CheckedChanged);
            // 
            // tb_dept_seq
            // 
            this.tb_dept_seq.Location = new System.Drawing.Point(146, 175);
            this.tb_dept_seq.Name = "tb_dept_seq";
            this.tb_dept_seq.Size = new System.Drawing.Size(100, 21);
            this.tb_dept_seq.TabIndex = 5;
            this.tb_dept_seq.TextChanged += new System.EventHandler(this.tb_deptcd_TextChanged);
            this.tb_dept_seq.Enter += new System.EventHandler(this.tb_dept_cd_Enter);
            // 
            // tb_dept_nm2
            // 
            this.tb_dept_nm2.Location = new System.Drawing.Point(146, 129);
            this.tb_dept_nm2.Name = "tb_dept_nm2";
            this.tb_dept_nm2.Size = new System.Drawing.Size(100, 21);
            this.tb_dept_nm2.TabIndex = 5;
            this.tb_dept_nm2.TextChanged += new System.EventHandler(this.tb_deptcd_TextChanged);
            this.tb_dept_nm2.Enter += new System.EventHandler(this.tb_dept_cd_Enter);
            // 
            // tb_dept_nm1
            // 
            this.tb_dept_nm1.Location = new System.Drawing.Point(146, 83);
            this.tb_dept_nm1.Name = "tb_dept_nm1";
            this.tb_dept_nm1.Size = new System.Drawing.Size(100, 21);
            this.tb_dept_nm1.TabIndex = 5;
            this.tb_dept_nm1.TextChanged += new System.EventHandler(this.tb_deptcd_TextChanged);
            this.tb_dept_nm1.Enter += new System.EventHandler(this.tb_dept_cd_Enter);
            // 
            // tb_dept_cd
            // 
            this.tb_dept_cd.Location = new System.Drawing.Point(146, 37);
            this.tb_dept_cd.Name = "tb_dept_cd";
            this.tb_dept_cd.Size = new System.Drawing.Size(100, 21);
            this.tb_dept_cd.TabIndex = 5;
            this.tb_dept_cd.TextChanged += new System.EventHandler(this.tb_deptcd_TextChanged);
            this.tb_dept_cd.Enter += new System.EventHandler(this.tb_dept_cd_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "부서코드";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "사용여부";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "코드SEQ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "코드명(축약)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "코드명(원형)";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(828, 426);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.tb_src);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(826, 70);
            this.panel3.TabIndex = 4;
            // 
            // status
            // 
            this.status.FillWeight = 40F;
            this.status.HeaderText = "상태";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            // 
            // dept_cd
            // 
            this.dept_cd.DataPropertyName = "dept_cd";
            this.dept_cd.FillWeight = 80F;
            this.dept_cd.HeaderText = "부서코드";
            this.dept_cd.Name = "dept_cd";
            this.dept_cd.ReadOnly = true;
            // 
            // dept_nm1
            // 
            this.dept_nm1.DataPropertyName = "dept_nm1";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dept_nm1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dept_nm1.HeaderText = "부서명(원형)";
            this.dept_nm1.Name = "dept_nm1";
            this.dept_nm1.ReadOnly = true;
            // 
            // dept_nm2
            // 
            this.dept_nm2.DataPropertyName = "dept_nm2";
            this.dept_nm2.HeaderText = "부서명(축약)";
            this.dept_nm2.Name = "dept_nm2";
            this.dept_nm2.ReadOnly = true;
            // 
            // dept_seq
            // 
            this.dept_seq.DataPropertyName = "dept_seq";
            this.dept_seq.FillWeight = 50F;
            this.dept_seq.HeaderText = "SEQ";
            this.dept_seq.Name = "dept_seq";
            this.dept_seq.ReadOnly = true;
            // 
            // dept_use
            // 
            this.dept_use.DataPropertyName = "dept_use";
            this.dept_use.FillWeight = 70F;
            this.dept_use.HeaderText = "사용여부";
            this.dept_use.Name = "dept_use";
            this.dept_use.ReadOnly = true;
            this.dept_use.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dept_use.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PartManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 426);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PartManager";
            this.Text = "PartManager";
            this.Load += new System.EventHandler(this.PartManager_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_src;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_dept_seq;
        private System.Windows.Forms.TextBox tb_dept_nm2;
        private System.Windows.Forms.TextBox tb_dept_nm1;
        private System.Windows.Forms.TextBox tb_dept_cd;
        private System.Windows.Forms.CheckBox tb_dept_use;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_nm1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_nm2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_seq;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dept_use;
    }
}