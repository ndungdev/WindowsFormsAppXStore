namespace WindowsFormsAppXStore
{
    partial class AddSaleForm
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
            this.lblSaleDate = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.txtSaleDate = new System.Windows.Forms.TextBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.dataGridViewSaleDetails = new System.Windows.Forms.DataGridView();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnSaveSale = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaleDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSaleDate
            // 
            this.lblSaleDate.AutoSize = true;
            this.lblSaleDate.Location = new System.Drawing.Point(24, 22);
            this.lblSaleDate.Name = "lblSaleDate";
            this.lblSaleDate.Size = new System.Drawing.Size(54, 13);
            this.lblSaleDate.TabIndex = 0;
            this.lblSaleDate.Text = "Sale Date";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(24, 48);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "Customer";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(24, 76);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(53, 13);
            this.lblEmployee.TabIndex = 2;
            this.lblEmployee.Text = "Employee";
            // 
            // txtSaleDate
            // 
            this.txtSaleDate.Location = new System.Drawing.Point(111, 19);
            this.txtSaleDate.Name = "txtSaleDate";
            this.txtSaleDate.Size = new System.Drawing.Size(137, 20);
            this.txtSaleDate.TabIndex = 3;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(111, 45);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(137, 21);
            this.cmbCustomer.TabIndex = 4;
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(111, 73);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(137, 21);
            this.cmbEmployee.TabIndex = 5;
            // 
            // dataGridViewSaleDetails
            // 
            this.dataGridViewSaleDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSaleDetails.Location = new System.Drawing.Point(270, 19);
            this.dataGridViewSaleDetails.Name = "dataGridViewSaleDetails";
            this.dataGridViewSaleDetails.Size = new System.Drawing.Size(504, 251);
            this.dataGridViewSaleDetails.TabIndex = 6;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(24, 104);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(70, 13);
            this.lblTotalAmount.TabIndex = 7;
            this.lblTotalAmount.Text = "Total Amount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(111, 101);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(137, 20);
            this.txtTotalAmount.TabIndex = 8;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAddProduct.Location = new System.Drawing.Point(27, 140);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(221, 42);
            this.btnAddProduct.TabIndex = 9;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnSaveSale
            // 
            this.btnSaveSale.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSaveSale.Location = new System.Drawing.Point(27, 210);
            this.btnSaveSale.Name = "btnSaveSale";
            this.btnSaveSale.Size = new System.Drawing.Size(100, 40);
            this.btnSaveSale.TabIndex = 10;
            this.btnSaveSale.Text = "Save";
            this.btnSaveSale.UseVisualStyleBackColor = true;
            this.btnSaveSale.Click += new System.EventHandler(this.btnSaveSale_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.Location = new System.Drawing.Point(153, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 41);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddSaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 288);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveSale);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.dataGridViewSaleDetails);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.txtSaleDate);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblSaleDate);
            this.MaximizeBox = false;
            this.Name = "AddSaleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddSaleForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaleDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSaleDate;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.TextBox txtSaleDate;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.DataGridView dataGridViewSaleDetails;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnSaveSale;
        private System.Windows.Forms.Button btnCancel;
    }
}