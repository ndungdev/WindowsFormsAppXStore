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
    public partial class EditCustomerForm : Form
    {
        private Customer _customer;
        public EditCustomerForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            txtCustomerCode.Text = _customer.CustomerCode;
            txtCustomerName.Text = _customer.CustomerName;
            txtPhoneNumber.Text = _customer.PhoneNumber;
            txtAddress.Text = _customer.Address;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrEmpty(txtCustomerName.Text) ||
                string.IsNullOrEmpty(txtPhoneNumber.Text) ||
                string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Update customer instance
                _customer.CustomerName = txtCustomerName.Text.Trim();
                _customer.PhoneNumber = txtPhoneNumber.Text.Trim();
                _customer.Address = txtAddress.Text.Trim();

                // Update in database
                CustomerService.UpdateCustomer(_customer);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
