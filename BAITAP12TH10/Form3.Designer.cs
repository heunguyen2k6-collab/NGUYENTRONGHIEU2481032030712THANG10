namespace BAITAP12TH10
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnNapDuLieu = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblPhanTram = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "NẠP DỮ LIỆU BẤT ĐỒNG BỘ";
            // 
            // btnNapDuLieu
            // 
            this.btnNapDuLieu.Location = new System.Drawing.Point(57, 71);
            this.btnNapDuLieu.Name = "btnNapDuLieu";
            this.btnNapDuLieu.Size = new System.Drawing.Size(149, 23);
            this.btnNapDuLieu.TabIndex = 1;
            this.btnNapDuLieu.Text = "Nạp Dữ Liệu Async";
            this.btnNapDuLieu.UseVisualStyleBackColor = true;
            this.btnNapDuLieu.Click += new System.EventHandler(this.btnNapDuLieu_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(235, 71);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(250, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // lblPhanTram
            // 
            this.lblPhanTram.AutoSize = true;
            this.lblPhanTram.Location = new System.Drawing.Point(524, 74);
            this.lblPhanTram.Name = "lblPhanTram";
            this.lblPhanTram.Size = new System.Drawing.Size(26, 16);
            this.lblPhanTram.TabIndex = 3;
            this.lblPhanTram.Text = "0%";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 131);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(591, 150);
            this.dgvData.TabIndex = 4;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.lblPhanTram);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnNapDuLieu);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNapDuLieu;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblPhanTram;
        private System.Windows.Forms.DataGridView dgvData;
    }
}