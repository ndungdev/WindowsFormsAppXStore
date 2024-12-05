namespace WindowsFormsAppXStore
{
    partial class SaleDetailsForm
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
            this.dataGridViewSaleDetails = new System.Windows.Forms.DataGridView();
            this.lblSaleInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaleDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSaleDetails
            // 
            this.dataGridViewSaleDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSaleDetails.Location = new System.Drawing.Point(12, 45);
            this.dataGridViewSaleDetails.Name = "dataGridViewSaleDetails";
            this.dataGridViewSaleDetails.Size = new System.Drawing.Size(776, 213);
            this.dataGridViewSaleDetails.TabIndex = 0;
            // 
            // lblSaleInfo
            // 
            this.lblSaleInfo.AutoSize = true;
            this.lblSaleInfo.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSaleInfo.Location = new System.Drawing.Point(12, 19);
            this.lblSaleInfo.Name = "lblSaleInfo";
            this.lblSaleInfo.Size = new System.Drawing.Size(74, 23);
            this.lblSaleInfo.TabIndex = 1;
            this.lblSaleInfo.Text = "SaleInfo";
            // 
            // SaleDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 270);
            this.Controls.Add(this.lblSaleInfo);
            this.Controls.Add(this.dataGridViewSaleDetails);
            this.MaximizeBox = false;
            this.Name = "SaleDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaleDetailsForm";
            this.Load += new System.EventHandler(this.SaleDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaleDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSaleDetails;
        private System.Windows.Forms.Label lblSaleInfo;
    }
}