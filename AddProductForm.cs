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
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
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

            // Tạo đối tượng Product
            Product product = new Product
            {
                ProductCode = txtProductCode.Text,
                ProductName = txtProductName.Text,
                SellingPrice = sellingPrice,
                InventoryQuantity = inventoryQuantity,
                ImageURL = txtImageURL.Text
            };

            // Thêm sản phẩm vào database
            try
            {
                ProductService.AddProduct(product);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
