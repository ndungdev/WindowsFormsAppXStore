namespace WindowsFormsAppXStore
{
    partial class SelectProductForm
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
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnSelectProduct = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(228, 12);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.Size = new System.Drawing.Size(560, 317);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(108, 29);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(104, 20);
            this.txtQuantity.TabIndex = 1;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblQuantity.Location = new System.Drawing.Point(33, 30);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(69, 19);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Quantity";
            // 
            // btnSelectProduct
            // 
            this.btnSelectProduct.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSelectProduct.Location = new System.Drawing.Point(37, 65);
            this.btnSelectProduct.Name = "btnSelectProduct";
            this.btnSelectProduct.Size = new System.Drawing.Size(175, 45);
            this.btnSelectProduct.TabIndex = 3;
            this.btnSelectProduct.Text = "Select Product";
            this.btnSelectProduct.UseVisualStyleBackColor = true;
            this.btnSelectProduct.Click += new System.EventHandler(this.btnSelectProduct_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(86, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SelectProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 344);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelectProduct);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.dataGridViewProducts);
            this.MaximizeBox = false;
            this.Name = "SelectProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectProductForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnSelectProduct;
        private System.Windows.Forms.Button btnCancel;
    }
}