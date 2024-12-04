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
    public partial class AddEmployeeForm : Form
    {
        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var employee = new Employee
                {
                    EmployeeCode = txtEmployeeCode.Text.Trim(),
                    EmployeeName = txtEmployeeName.Text.Trim(),
                    Position = txtPosition.Text.Trim(),
                    Authority = txtAuthority.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    PasswordHash = HashPassword(txtPassword.Text.Trim()), // Hash password
                    PasswordReset = false
                };

                EmployeeService.AddEmployee(employee);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private string HashPassword(string password)
        {
            // Implement password hashing logic (e.g., SHA-256)
            return password; // Replace with actual hashing
        }
    }
}
