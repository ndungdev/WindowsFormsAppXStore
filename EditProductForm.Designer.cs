namespace WindowsFormsAppXStore
{
    partial class EditProductForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtImageURL = new System.Windows.Forms.TextBox();
            this.txtInventoryQuantity = new System.Windows.Forms.TextBox();
            this.txtSellingPrice = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.lblImageURL = new System.Windows.Forms.Label();
            this.lblInventoryQty = new System.Windows.Forms.Label();
            this.lblSellingPrice = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(186, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(301, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtImageURL
            // 
            this.txtImageURL.Location = new System.Drawing.Point(186, 143);
            this.txtImageURL.Name = "txtImageURL";
            this.txtImageURL.Size = new System.Drawing.Size(190, 20);
            this.txtImageURL.TabIndex = 21;
            // 
            // txtInventoryQuantity
            // 
            this.txtInventoryQuantity.Location = new System.Drawing.Point(186, 117);
            this.txtInventoryQuantity.Name = "txtInventoryQuantity";
            this.txtInventoryQuantity.Size = new System.Drawing.Size(190, 20);
            this.txtInventoryQuantity.TabIndex = 20;
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.Location = new System.Drawing.Point(186, 91);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(190, 20);
            this.txtSellingPrice.TabIndex = 19;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(186, 65);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(190, 20);
            this.txtProductName.TabIndex = 18;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(186, 39);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(190, 20);
            this.txtProductCode.TabIndex = 17;
            // 
            // lblImageURL
            // 
            this.lblImageURL.AutoSize = true;
            this.lblImageURL.Location = new System.Drawing.Point(44, 146);
            this.lblImageURL.Name = "lblImageURL";
            this.lblImageURL.Size = new System.Drawing.Size(109, 13);
            this.lblImageURL.TabIndex = 16;
            this.lblImageURL.Text = "Image URL (Optional)";
            // 
            // lblInventoryQty
            // 
            this.lblInventoryQty.AutoSize = true;
            this.lblInventoryQty.Location = new System.Drawing.Point(44, 120);
            this.lblInventoryQty.Name = "lblInventoryQty";
            this.lblInventoryQty.Size = new System.Drawing.Size(93, 13);
            this.lblInventoryQty.TabIndex = 15;
            this.lblInventoryQty.Text = "Inventory Quantity";
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.AutoSize = true;
            this.lblSellingPrice.Location = new System.Drawing.Point(44, 94);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(65, 13);
            this.lblSellingPrice.TabIndex = 14;
            this.lblSellingPrice.Text = "Selling Price";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(44, 68);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(75, 13);
            this.lblProductName.TabIndex = 13;
            this.lblProductName.Text = "Product Name";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Location = new System.Drawing.Point(44, 42);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(72, 13);
            this.lblProductCode.TabIndex = 12;
            this.lblProductCode.Text = "Product Code";
            // 
            // EditProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 242);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtImageURL);
            this.Controls.Add(this.txtInventoryQuantity);
            this.Controls.Add(this.txtSellingPrice);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.lblImageURL);
            this.Controls.Add(this.lblInventoryQty);
            this.Controls.Add(this.lblSellingPrice);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblProductCode);
            this.MaximizeBox = false;
            this.Name = "EditProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditProductForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtImageURL;
        private System.Windows.Forms.TextBox txtInventoryQuantity;
        private System.Windows.Forms.TextBox txtSellingPrice;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label lblImageURL;
        private System.Windows.Forms.Label lblInventoryQty;
        private System.Windows.Forms.Label lblSellingPrice;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductCode;
    }
}