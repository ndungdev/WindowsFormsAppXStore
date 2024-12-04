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
    public partial class EditProductForm : Form
    {
        private Product _product;

        public EditProductForm(Product product)
        {
            InitializeComponent();
            _product = product;
            LoadProductDetails();
        }

        private void LoadProductDetails()
        {
            txtProductCode.Text = _product.ProductCode;
            txtProductName.Text = _product.ProductName;
            txtSellingPrice.Text = _product.SellingPrice.ToString();
            txtInventoryQuantity.Text = _product.InventoryQuantity.ToString();
            txtImageURL.Text = _product.ImageURL;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtProductCode.Text) || string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter all required fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSellingPrice.Text, out decimal sellingPrice))
            {
                MessageBox.Show("Invalid selling price!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtInventoryQuantity.Text, out int inventoryQuantity))
            {
                MessageBox.Show("Invalid inventory quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cập nhật đối tượng Product
            _product.ProductCode = txtProductCode.Text;
            _product.ProductName = txtProductName.Text;
            _product.SellingPrice = sellingPrice;
            _product.InventoryQuantity = inventoryQuantity;
            _product.ImageURL = txtImageURL.Text;

            try
            {
                // Gọi dịch vụ cập nhật sản phẩm
                ProductService.UpdateProduct(_product);
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
