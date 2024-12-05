using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsAppXStore.Dashboard;

namespace WindowsFormsAppXStore
{
    public partial class AddSaleForm : Form
    {
        public AddSaleForm()
        {
            InitializeComponent();
            LoadCustomers();
            LoadEmployees();
            InitializeSaleDetailsGrid();
            txtSaleDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void LoadCustomers()
        {
            var customers = CustomerService.GetAllCustomers();
            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "CustomerName";
            cmbCustomer.ValueMember = "CustomerID";
        }

        private void LoadEmployees()
        {
            var employees = EmployeeService.GetEmployees();
            cmbEmployee.DataSource = employees;
            cmbEmployee.DisplayMember = "EmployeeName";
            cmbEmployee.ValueMember = "EmployeeID";
        }

        private void InitializeSaleDetailsGrid()
        {
            dataGridViewSaleDetails.Columns.Add("ProductID", "Product ID");
            dataGridViewSaleDetails.Columns.Add("ProductName", "Product Name");
            dataGridViewSaleDetails.Columns.Add("Quantity", "Quantity");
            dataGridViewSaleDetails.Columns.Add("SellingPrice", "Selling Price");
            dataGridViewSaleDetails.Columns.Add("Subtotal", "Subtotal");

            var removeButton = new DataGridViewButtonColumn
            {
                HeaderText = "Action",
                Text = "Remove",
                UseColumnTextForButtonValue = true
            };
            dataGridViewSaleDetails.Columns.Add(removeButton);
        }

        private void btnSaveSale_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null || cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Please select a customer and an employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sale = new Sale
            {
                SaleDate = DateTime.Parse(txtSaleDate.Text),
                CustomerID = (int)cmbCustomer.SelectedValue,
                EmployeeID = (int)cmbEmployee.SelectedValue,
                TotalAmount = decimal.Parse(txtTotalAmount.Text)
            };

            int saleId = SaleService.AddSale(sale);
            foreach (DataGridViewRow row in dataGridViewSaleDetails.Rows)
            {
                if (row.Cells["ProductID"].Value != null)
                {
                    var saleDetail = new SaleDetail
                    {
                        SaleID = saleId,
                        ProductID = (int)row.Cells["ProductID"].Value,
                        Quantity = int.Parse(row.Cells["Quantity"].Value.ToString()),
                        SellingPrice = decimal.Parse(row.Cells["SellingPrice"].Value.ToString()),
                        Subtotal = decimal.Parse(row.Cells["Subtotal"].Value.ToString())
                    };
                    SaleDetailService.AddSaleDetail(saleDetail);
                }
            }
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Sale added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            List<Product> products = ProductService.GetAllProducts(); // Fetch products from DB or cache
            using (var selectProductForm = new SelectProductForm(products))
            {
                if (selectProductForm.ShowDialog() == DialogResult.OK)
                {
                    var selectedProduct = selectProductForm.SelectedProduct;
                    int quantity = selectProductForm.Quantity;
                    decimal sellingPrice = selectedProduct.SellingPrice;
                    decimal subtotal = sellingPrice * quantity;

                    dataGridViewSaleDetails.Rows.Add(selectedProduct.ProductID, selectedProduct.ProductName, quantity, sellingPrice, subtotal);
                    CalculateTotal();
                }
            }
        }
        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridViewSaleDetails.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    total += decimal.Parse(row.Cells["Subtotal"].Value.ToString());
                }
            }
            txtTotalAmount.Text = total.ToString("0.00");
        }
        private void dataGridViewSaleDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewSaleDetails.Columns["Action"].Index)
            {
                dataGridViewSaleDetails.Rows.RemoveAt(e.RowIndex);
                CalculateTotal();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
