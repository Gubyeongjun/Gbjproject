
namespace Gbjproject
{
    partial class ButtonForm
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
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_insert = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Image = global::Gbjproject.Properties.Resources.search;
            this.btn_search.Location = new System.Drawing.Point(3, 1);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(61, 60);
            this.btn_search.TabIndex = 0;
            this.btn_search.Tag = "btnSearch_Click";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_func);
            // 
            // btn_insert
            // 
            this.btn_insert.Image = global::Gbjproject.Properties.Resources.add;
            this.btn_insert.Location = new System.Drawing.Point(70, 1);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(61, 60);
            this.btn_insert.TabIndex = 0;
            this.btn_insert.Tag = "btnInsert_Click";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_func);
            // 
            // btn_update
            // 
            this.btn_update.Image = global::Gbjproject.Properties.Resources.update;
            this.btn_update.Location = new System.Drawing.Point(137, 1);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(61, 60);
            this.btn_update.TabIndex = 0;
            this.btn_update.Tag = "btnUpdate_Click";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_func);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::Gbjproject.Properties.Resources.delete;
            this.btn_delete.Location = new System.Drawing.Point(204, 1);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(61, 60);
            this.btn_delete.TabIndex = 0;
            this.btn_delete.Tag = "btnDelete_Click";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_func);
            // 
            // btn_save
            // 
            this.btn_save.Image = global::Gbjproject.Properties.Resources.save;
            this.btn_save.Location = new System.Drawing.Point(271, 1);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(61, 60);
            this.btn_save.TabIndex = 0;
            this.btn_save.Tag = "btnSave_Click";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_func);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::Gbjproject.Properties.Resources.cancel;
            this.btn_cancel.Location = new System.Drawing.Point(338, 1);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(61, 60);
            this.btn_cancel.TabIndex = 0;
            this.btn_cancel.Tag = "btnCancel_Click";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_func);
            // 
            // btn_print
            // 
            this.btn_print.Image = global::Gbjproject.Properties.Resources.print;
            this.btn_print.Location = new System.Drawing.Point(405, 1);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(61, 60);
            this.btn_print.TabIndex = 0;
            this.btn_print.Tag = "btnPrint_Click";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_func);
            // 
            // btn_exit
            // 
            this.btn_exit.Image = global::Gbjproject.Properties.Resources.exit;
            this.btn_exit.Location = new System.Drawing.Point(472, 1);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(61, 60);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Tag = "btn_exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_func);
            // 
            // ButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 62);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.btn_search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ButtonForm";
            this.Text = "ButtonForm";
            this.Load += new System.EventHandler(this.ButtonForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_exit;
    }
}