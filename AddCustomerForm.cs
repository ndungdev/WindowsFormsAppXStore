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
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrEmpty(txtCustomerCode.Text) ||
                string.IsNullOrEmpty(txtCustomerName.Text) ||
                string.IsNullOrEmpty(txtPhoneNumber.Text) ||
                string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create a new customer instance
                var newCustomer = new Customer
                {
                    CustomerCode = txtCustomerCode.Text.Trim(),
                    CustomerName = txtCustomerName.Text.Trim(),
                    PhoneNumber = txtPhoneNumber.Text.Trim(),
                    Address = txtAddress.Text.Trim()
                };

                // Save to database
                CustomerService.AddCustomer(newCustomer);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
