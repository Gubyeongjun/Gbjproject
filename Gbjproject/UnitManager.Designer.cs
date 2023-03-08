
namespace Gbjproject
{
    partial class UnitManager
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.src_unit_grpcd = new System.Windows.Forms.ComboBox();
            this.src_unit_nm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tb_unit_use = new System.Windows.Forms.CheckBox();
            this.tb_unit_cd = new System.Windows.Forms.TextBox();
            this.tb_unit_seq = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_unit_nm2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_unit_nm1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_grpcd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_nm1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_nm2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_use = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(828, 426);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.src_unit_grpcd);
            this.panel1.Controls.Add(this.src_unit_nm);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 70);
            this.panel1.TabIndex = 0;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(632, 26);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(100, 20);
            this.comboBox3.TabIndex = 2;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(420, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(526, 26);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 20);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // src_unit_grpcd
            // 
            this.src_unit_grpcd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.src_unit_grpcd.FormattingEnabled = true;
            this.src_unit_grpcd.Location = new System.Drawing.Point(94, 26);
            this.src_unit_grpcd.Name = "src_unit_grpcd";
            this.src_unit_grpcd.Size = new System.Drawing.Size(100, 20);
            this.src_unit_grpcd.TabIndex = 2;
            this.src_unit_grpcd.SelectedIndexChanged += new System.EventHandler(this.src_unit_grpcd_SelectedIndexChanged);
            // 
            // src_unit_nm
            // 
            this.src_unit_nm.Location = new System.Drawing.Point(262, 26);
            this.src_unit_nm.Name = "src_unit_nm";
            this.src_unit_nm.Size = new System.Drawing.Size(100, 21);
            this.src_unit_nm.TabIndex = 1;
            this.src_unit_nm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.src_unit_nm_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "그룹코드";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "코드명";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(519, 347);
            this.panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.unit_grpcd,
            this.unit_cd,
            this.unit_nm1,
            this.unit_nm2,
            this.unit_seq,
            this.unit_use});
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
            // panel3
            // 
            this.panel3.Controls.Add(this.tb_unit_use);
            this.panel3.Controls.Add(this.tb_unit_cd);
            this.panel3.Controls.Add(this.tb_unit_seq);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.tb_unit_nm2);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.tb_unit_nm1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(530, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 347);
            this.panel3.TabIndex = 0;
            // 
            // tb_unit_use
            // 
            this.tb_unit_use.AutoSize = true;
            this.tb_unit_use.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tb_unit_use.Location = new System.Drawing.Point(133, 188);
            this.tb_unit_use.Name = "tb_unit_use";
            this.tb_unit_use.Size = new System.Drawing.Size(15, 14);
            this.tb_unit_use.TabIndex = 36;
            this.tb_unit_use.UseVisualStyleBackColor = true;
            this.tb_unit_use.CheckedChanged += new System.EventHandler(this.tb_unit_use_CheckedChanged);
            // 
            // tb_unit_cd
            // 
            this.tb_unit_cd.Location = new System.Drawing.Point(133, 37);
            this.tb_unit_cd.Name = "tb_unit_cd";
            this.tb_unit_cd.Size = new System.Drawing.Size(100, 21);
            this.tb_unit_cd.TabIndex = 27;
            this.tb_unit_cd.TextChanged += new System.EventHandler(this.tb_unit_cd_TextChanged);
            this.tb_unit_cd.Enter += new System.EventHandler(this.tb_unit_cd_Enter);
            // 
            // tb_unit_seq
            // 
            this.tb_unit_seq.Location = new System.Drawing.Point(133, 148);
            this.tb_unit_seq.Name = "tb_unit_seq";
            this.tb_unit_seq.Size = new System.Drawing.Size(100, 21);
            this.tb_unit_seq.TabIndex = 35;
            this.tb_unit_seq.TextChanged += new System.EventHandler(this.tb_unit_cd_TextChanged);
            this.tb_unit_seq.Enter += new System.EventHandler(this.tb_unit_cd_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "단위코드";
            // 
            // tb_unit_nm2
            // 
            this.tb_unit_nm2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tb_unit_nm2.Location = new System.Drawing.Point(133, 112);
            this.tb_unit_nm2.Name = "tb_unit_nm2";
            this.tb_unit_nm2.Size = new System.Drawing.Size(100, 21);
            this.tb_unit_nm2.TabIndex = 29;
            this.tb_unit_nm2.TextChanged += new System.EventHandler(this.tb_unit_cd_TextChanged);
            this.tb_unit_nm2.Enter += new System.EventHandler(this.tb_unit_cd_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 12);
            this.label6.TabIndex = 33;
            this.label6.Text = "코드명(원형)";
            // 
            // tb_unit_nm1
            // 
            this.tb_unit_nm1.Location = new System.Drawing.Point(133, 74);
            this.tb_unit_nm1.Name = "tb_unit_nm1";
            this.tb_unit_nm1.Size = new System.Drawing.Size(100, 21);
            this.tb_unit_nm1.TabIndex = 28;
            this.tb_unit_nm1.TextChanged += new System.EventHandler(this.tb_unit_cd_TextChanged);
            this.tb_unit_nm1.Enter += new System.EventHandler(this.tb_unit_cd_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "코드명(축약)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "SEQ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "사용여부";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // status
            // 
            this.status.HeaderText = "상태";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            // 
            // unit_grpcd
            // 
            this.unit_grpcd.DataPropertyName = "unit_grpcd";
            this.unit_grpcd.FillWeight = 95F;
            this.unit_grpcd.HeaderText = "그룹코드";
            this.unit_grpcd.Name = "unit_grpcd";
            this.unit_grpcd.ReadOnly = true;
            // 
            // unit_cd
            // 
            this.unit_cd.DataPropertyName = "unit_cd";
            this.unit_cd.FillWeight = 85F;
            this.unit_cd.HeaderText = "단위코드";
            this.unit_cd.Name = "unit_cd";
            this.unit_cd.ReadOnly = true;
            // 
            // unit_nm1
            // 
            this.unit_nm1.DataPropertyName = "unit_nm1";
            this.unit_nm1.HeaderText = "코드명(원형)";
            this.unit_nm1.Name = "unit_nm1";
            this.unit_nm1.ReadOnly = true;
            // 
            // unit_nm2
            // 
            this.unit_nm2.DataPropertyName = "unit_nm2";
            this.unit_nm2.HeaderText = "코드명(축약)";
            this.unit_nm2.Name = "unit_nm2";
            this.unit_nm2.ReadOnly = true;
            // 
            // unit_seq
            // 
            this.unit_seq.DataPropertyName = "unit_seq";
            this.unit_seq.FillWeight = 45F;
            this.unit_seq.HeaderText = "SEQ";
            this.unit_seq.Name = "unit_seq";
            this.unit_seq.ReadOnly = true;
            // 
            // unit_use
            // 
            this.unit_use.DataPropertyName = "unit_use";
            this.unit_use.FillWeight = 85F;
            this.unit_use.HeaderText = "사용여부";
            this.unit_use.Name = "unit_use";
            this.unit_use.ReadOnly = true;
            this.unit_use.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.unit_use.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // UnitManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 426);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UnitManager";
            this.Text = "UnitManager";
            this.Load += new System.EventHandler(this.UnitManager_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox src_unit_nm;
        private System.Windows.Forms.ComboBox src_unit_grpcd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox tb_unit_use;
        private System.Windows.Forms.TextBox tb_unit_cd;
        private System.Windows.Forms.TextBox tb_unit_seq;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_unit_nm2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_unit_nm1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_grpcd;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_nm1;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_nm2;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_seq;
        private System.Windows.Forms.DataGridViewCheckBoxColumn unit_use;
    }
}