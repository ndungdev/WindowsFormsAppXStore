namespace WindowsFormsAppXStore
{
    partial class Dashboard
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
            this.tabDashboard = new System.Windows.Forms.TabControl();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.dataGridViewProDucts = new System.Windows.Forms.DataGridView();
            this.tabEmployees = new System.Windows.Forms.TabPage();
            this.txtSearchEmployee = new System.Windows.Forms.TextBox();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnSearchEmployee = new System.Windows.Forms.Button();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.btnEditCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.tabSales = new System.Windows.Forms.TabPage();
            this.txtSearchSale = new System.Windows.Forms.TextBox();
            this.btnViewSale = new System.Windows.Forms.Button();
            this.btnSearchSale = new System.Windows.Forms.Button();
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabDashboard.SuspendLayout();
            this.tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProDucts)).BeginInit();
            this.tabEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.tabCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            this.tabSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDashboard
            // 
            this.tabDashboard.Controls.Add(this.tabProducts);
            this.tabDashboard.Controls.Add(this.tabEmployees);
            this.tabDashboard.Controls.Add(this.tabCustomers);
            this.tabDashboard.Controls.Add(this.tabSales);
            this.tabDashboard.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tabDashboard.Location = new System.Drawing.Point(-1, 118);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.SelectedIndex = 0;
            this.tabDashboard.Size = new System.Drawing.Size(818, 484);
            this.tabDashboard.TabIndex = 0;
            // 
            // tabProducts
            // 
            this.tabProducts.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tabProducts.Controls.Add(this.txtSearch);
            this.tabProducts.Controls.Add(this.btnDeleteProduct);
            this.tabProducts.Controls.Add(this.btnEditProduct);
            this.tabProducts.Controls.Add(this.btnAddProduct);
            this.tabProducts.Controls.Add(this.btnSearchProduct);
            this.tabProducts.Controls.Add(this.dataGridViewProDucts);
            this.tabProducts.Location = new System.Drawing.Point(4, 38);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(810, 442);
            this.tabProducts.TabIndex = 0;
            this.tabProducts.Text = "Produscts";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(121, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(228, 37);
            this.txtSearch.TabIndex = 5;
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(692, 6);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(112, 37);
            this.btnDeleteProduct.TabIndex = 4;
            this.btnDeleteProduct.Text = "Delete";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Location = new System.Drawing.Point(574, 6);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(112, 37);
            this.btnEditProduct.TabIndex = 3;
            this.btnEditProduct.Text = "Edit";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(456, 6);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(112, 37);
            this.btnAddProduct.TabIndex = 2;
            this.btnAddProduct.Text = "Add";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Location = new System.Drawing.Point(3, 6);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(112, 37);
            this.btnSearchProduct.TabIndex = 1;
            this.btnSearchProduct.Text = "Search";
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // dataGridViewProDucts
            // 
            this.dataGridViewProDucts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProDucts.Location = new System.Drawing.Point(3, 49);
            this.dataGridViewProDucts.Name = "dataGridViewProDucts";
            this.dataGridViewProDucts.Size = new System.Drawing.Size(804, 390);
            this.dataGridViewProDucts.TabIndex = 0;
            // 
            // tabEmployees
            // 
            this.tabEmployees.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tabEmployees.Controls.Add(this.txtSearchEmployee);
            this.tabEmployees.Controls.Add(this.btnDeleteEmployee);
            this.tabEmployees.Controls.Add(this.btnEditEmployee);
            this.tabEmployees.Controls.Add(this.btnAddEmployee);
            this.tabEmployees.Controls.Add(this.btnSearchEmployee);
            this.tabEmployees.Controls.Add(this.dataGridViewEmployees);
            this.tabEmployees.Location = new System.Drawing.Point(4, 38);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployees.Size = new System.Drawing.Size(810, 442);
            this.tabEmployees.TabIndex = 1;
            this.tabEmployees.Text = "Employees";
            // 
            // txtSearchEmployee
            // 
            this.txtSearchEmployee.Location = new System.Drawing.Point(121, 5);
            this.txtSearchEmployee.Name = "txtSearchEmployee";
            this.txtSearchEmployee.Size = new System.Drawing.Size(228, 37);
            this.txtSearchEmployee.TabIndex = 11;
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Location = new System.Drawing.Point(692, 5);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(112, 37);
            this.btnDeleteEmployee.TabIndex = 10;
            this.btnDeleteEmployee.Text = "Delete";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.Location = new System.Drawing.Point(574, 5);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(112, 37);
            this.btnEditEmployee.TabIndex = 9;
            this.btnEditEmployee.Text = "Edit";
            this.btnEditEmployee.UseVisualStyleBackColor = true;
            this.btnEditEmployee.Click += new System.EventHandler(this.btnEditEmployee_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(456, 5);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(112, 37);
            this.btnAddEmployee.TabIndex = 8;
            this.btnAddEmployee.Text = "Add";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnSearchEmployee
            // 
            this.btnSearchEmployee.Location = new System.Drawing.Point(3, 5);
            this.btnSearchEmployee.Name = "btnSearchEmployee";
            this.btnSearchEmployee.Size = new System.Drawing.Size(112, 37);
            this.btnSearchEmployee.TabIndex = 7;
            this.btnSearchEmployee.Text = "Search";
            this.btnSearchEmployee.UseVisualStyleBackColor = true;
            this.btnSearchEmployee.Click += new System.EventHandler(this.btnSearchEmployee_Click);
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(3, 48);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.Size = new System.Drawing.Size(804, 390);
            this.dataGridViewEmployees.TabIndex = 6;
            // 
            // tabCustomers
            // 
            this.tabCustomers.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tabCustomers.Controls.Add(this.txtSearchCustomer);
            this.tabCustomers.Controls.Add(this.btnEditCustomer);
            this.tabCustomers.Controls.Add(this.btnAddCustomer);
            this.tabCustomers.Controls.Add(this.btnSearchCustomer);
            this.tabCustomers.Controls.Add(this.dataGridViewCustomers);
            this.tabCustomers.Location = new System.Drawing.Point(4, 38);
            this.tabCustomers.Name = "tabCustomers";
            this.tabCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomers.Size = new System.Drawing.Size(810, 442);
            this.tabCustomers.TabIndex = 2;
            this.tabCustomers.Text = "Customers";
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Location = new System.Drawing.Point(121, 5);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(228, 37);
            this.txtSearchCustomer.TabIndex = 11;
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.Location = new System.Drawing.Point(695, 6);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(112, 37);
            this.btnEditCustomer.TabIndex = 9;
            this.btnEditCustomer.Text = "Edit";
            this.btnEditCustomer.UseVisualStyleBackColor = true;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(577, 6);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(112, 37);
            this.btnAddCustomer.TabIndex = 8;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Location = new System.Drawing.Point(3, 5);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(112, 37);
            this.btnSearchCustomer.TabIndex = 7;
            this.btnSearchCustomer.Text = "Search";
            this.btnSearchCustomer.UseVisualStyleBackColor = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // dataGridViewCustomers
            // 
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(3, 48);
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.Size = new System.Drawing.Size(804, 390);
            this.dataGridViewCustomers.TabIndex = 6;
            // 
            // tabSales
            // 
            this.tabSales.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tabSales.Controls.Add(this.txtSearchSale);
            this.tabSales.Controls.Add(this.btnViewSale);
            this.tabSales.Controls.Add(this.btnSearchSale);
            this.tabSales.Controls.Add(this.dataGridViewSales);
            this.tabSales.Location = new System.Drawing.Point(4, 38);
            this.tabSales.Name = "tabSales";
            this.tabSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabSales.Size = new System.Drawing.Size(810, 442);
            this.tabSales.TabIndex = 3;
            this.tabSales.Text = "Sales";
            // 
            // txtSearchSale
            // 
            this.txtSearchSale.Location = new System.Drawing.Point(121, 5);
            this.txtSearchSale.Name = "txtSearchSale";
            this.txtSearchSale.Size = new System.Drawing.Size(228, 37);
            this.txtSearchSale.TabIndex = 11;
            // 
            // btnViewSale
            // 
            this.btnViewSale.Location = new System.Drawing.Point(692, 5);
            this.btnViewSale.Name = "btnViewSale";
            this.btnViewSale.Size = new System.Drawing.Size(112, 37);
            this.btnViewSale.TabIndex = 10;
            this.btnViewSale.Text = "View";
            this.btnViewSale.UseVisualStyleBackColor = true;
            this.btnViewSale.Click += new System.EventHandler(this.btnViewSale_Click);
            // 
            // btnSearchSale
            // 
            this.btnSearchSale.Location = new System.Drawing.Point(3, 5);
            this.btnSearchSale.Name = "btnSearchSale";
            this.btnSearchSale.Size = new System.Drawing.Size(112, 37);
            this.btnSearchSale.TabIndex = 7;
            this.btnSearchSale.Text = "Search";
            this.btnSearchSale.UseVisualStyleBackColor = true;
            this.btnSearchSale.Click += new System.EventHandler(this.btnSearchSale_Click);
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Location = new System.Drawing.Point(3, 48);
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.Size = new System.Drawing.Size(804, 390);
            this.dataGridViewSales.TabIndex = 6;
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lblDashboard.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.SlateBlue;
            this.lblDashboard.Location = new System.Drawing.Point(12, 12);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(467, 91);
            this.lblDashboard.TabIndex = 1;
            this.lblDashboard.Text = "Dashboard";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.SlateBlue;
            this.btnLogout.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnLogout.Location = new System.Drawing.Point(700, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(103, 38);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(815, 603);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.tabDashboard);
            this.ForeColor = System.Drawing.SystemColors.MenuText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.tabDashboard.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            this.tabProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProDucts)).EndInit();
            this.tabEmployees.ResumeLayout(false);
            this.tabEmployees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.tabCustomers.ResumeLayout(false);
            this.tabCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            this.tabSales.ResumeLayout(false);
            this.tabSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabDashboard;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabEmployees;
        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.TabPage tabSales;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.DataGridView dataGridViewProDucts;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.TextBox txtSearchEmployee;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.Button btnEditEmployee;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnSearchEmployee;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.Button btnEditCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.TextBox txtSearchSale;
        private System.Windows.Forms.Button btnViewSale;
        private System.Windows.Forms.Button btnSearchSale;
        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.Button btnLogout;
    }
}