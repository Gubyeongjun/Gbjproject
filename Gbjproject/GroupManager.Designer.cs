
namespace Gbjproject
{
    partial class GroupManager
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
            this.src_grpnm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tb_cdg_use = new System.Windows.Forms.CheckBox();
            this.tb_cdg_nmleng = new System.Windows.Forms.TextBox();
            this.tb_cdg_length = new System.Windows.Forms.TextBox();
            this.tb_cdg_grpnm = new System.Windows.Forms.TextBox();
            this.tb_cdg_grpcd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdg_grpcd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdg_grpnm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdg_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdg_nmleng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdg_use = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.panel1.Controls.Add(this.src_grpnm);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 70);
            this.panel1.TabIndex = 1;
            // 
            // src_grpnm
            // 
            this.src_grpnm.Location = new System.Drawing.Point(94, 26);
            this.src_grpnm.Name = "src_grpnm";
            this.src_grpnm.Size = new System.Drawing.Size(100, 21);
            this.src_grpnm.TabIndex = 18;
            this.src_grpnm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.src_grpnm_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "그룹코드명";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(519, 347);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.cdg_grpcd,
            this.cdg_grpnm,
            this.cdg_length,
            this.cdg_nmleng,
            this.cdg_use});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(519, 347);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tb_cdg_use);
            this.panel3.Controls.Add(this.tb_cdg_nmleng);
            this.panel3.Controls.Add(this.tb_cdg_length);
            this.panel3.Controls.Add(this.tb_cdg_grpnm);
            this.panel3.Controls.Add(this.tb_cdg_grpcd);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(530, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 347);
            this.panel3.TabIndex = 1;
            // 
            // tb_cdg_use
            // 
            this.tb_cdg_use.AutoSize = true;
            this.tb_cdg_use.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tb_cdg_use.Location = new System.Drawing.Point(133, 188);
            this.tb_cdg_use.Name = "tb_cdg_use";
            this.tb_cdg_use.Size = new System.Drawing.Size(15, 14);
            this.tb_cdg_use.TabIndex = 26;
            this.tb_cdg_use.UseVisualStyleBackColor = true;
            this.tb_cdg_use.CheckedChanged += new System.EventHandler(this.tb_use_CheckedChanged);
            // 
            // tb_cdg_nmleng
            // 
            this.tb_cdg_nmleng.Location = new System.Drawing.Point(133, 148);
            this.tb_cdg_nmleng.Name = "tb_cdg_nmleng";
            this.tb_cdg_nmleng.Size = new System.Drawing.Size(100, 21);
            this.tb_cdg_nmleng.TabIndex = 25;
            this.tb_cdg_nmleng.TextChanged += new System.EventHandler(this.tb_grpcd_TextChanged);
            this.tb_cdg_nmleng.Enter += new System.EventHandler(this.tb_grpcd_Enter);
            // 
            // tb_cdg_length
            // 
            this.tb_cdg_length.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tb_cdg_length.Location = new System.Drawing.Point(133, 112);
            this.tb_cdg_length.Name = "tb_cdg_length";
            this.tb_cdg_length.Size = new System.Drawing.Size(100, 21);
            this.tb_cdg_length.TabIndex = 19;
            this.tb_cdg_length.TextChanged += new System.EventHandler(this.tb_grpcd_TextChanged);
            this.tb_cdg_length.Enter += new System.EventHandler(this.tb_grpcd_Enter);
            // 
            // tb_cdg_grpnm
            // 
            this.tb_cdg_grpnm.Location = new System.Drawing.Point(133, 74);
            this.tb_cdg_grpnm.Name = "tb_cdg_grpnm";
            this.tb_cdg_grpnm.Size = new System.Drawing.Size(100, 21);
            this.tb_cdg_grpnm.TabIndex = 18;
            this.tb_cdg_grpnm.TextChanged += new System.EventHandler(this.tb_grpcd_TextChanged);
            this.tb_cdg_grpnm.Enter += new System.EventHandler(this.tb_grpcd_Enter);
            // 
            // tb_cdg_grpcd
            // 
            this.tb_cdg_grpcd.Location = new System.Drawing.Point(133, 37);
            this.tb_cdg_grpcd.Name = "tb_cdg_grpcd";
            this.tb_cdg_grpcd.Size = new System.Drawing.Size(100, 21);
            this.tb_cdg_grpcd.TabIndex = 17;
            this.tb_cdg_grpcd.TextChanged += new System.EventHandler(this.tb_grpcd_TextChanged);
            this.tb_cdg_grpcd.Enter += new System.EventHandler(this.tb_grpcd_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "사용여부";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "단위코드명 길이";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "단위코드 길이";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "그룹코드명";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "그룹코드";
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
            // cdg_grpcd
            // 
            this.cdg_grpcd.DataPropertyName = "cdg_grpcd";
            this.cdg_grpcd.FillWeight = 80F;
            this.cdg_grpcd.HeaderText = "그룹코드";
            this.cdg_grpcd.Name = "cdg_grpcd";
            this.cdg_grpcd.ReadOnly = true;
            // 
            // cdg_grpnm
            // 
            this.cdg_grpnm.DataPropertyName = "cdg_grpnm";
            this.cdg_grpnm.FillWeight = 80F;
            this.cdg_grpnm.HeaderText = "그룹코드명";
            this.cdg_grpnm.Name = "cdg_grpnm";
            this.cdg_grpnm.ReadOnly = true;
            // 
            // cdg_length
            // 
            this.cdg_length.DataPropertyName = "cdg_length";
            this.cdg_length.HeaderText = "단위코드 길이";
            this.cdg_length.Name = "cdg_length";
            this.cdg_length.ReadOnly = true;
            // 
            // cdg_nmleng
            // 
            this.cdg_nmleng.DataPropertyName = "cdg_nmleng";
            this.cdg_nmleng.FillWeight = 120F;
            this.cdg_nmleng.HeaderText = "단위코드명 길이";
            this.cdg_nmleng.Name = "cdg_nmleng";
            this.cdg_nmleng.ReadOnly = true;
            // 
            // cdg_use
            // 
            this.cdg_use.DataPropertyName = "cdg_use";
            this.cdg_use.FillWeight = 80F;
            this.cdg_use.HeaderText = "사용여부";
            this.cdg_use.Name = "cdg_use";
            this.cdg_use.ReadOnly = true;
            this.cdg_use.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cdg_use.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // GroupManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 426);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GroupManager";
            this.Text = "GroupManager";
            this.Load += new System.EventHandler(this.GroupManager_Load);
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
        private System.Windows.Forms.CheckBox tb_cdg_use;
        private System.Windows.Forms.TextBox tb_cdg_nmleng;
        private System.Windows.Forms.TextBox tb_cdg_length;
        private System.Windows.Forms.TextBox tb_cdg_grpnm;
        private System.Windows.Forms.TextBox tb_cdg_grpcd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox src_grpnm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdg_grpcd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdg_grpnm;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdg_length;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdg_nmleng;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cdg_use;
    }
}