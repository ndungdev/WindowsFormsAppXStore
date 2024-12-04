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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string employeeCode = txtEmployeeCode.Text.Trim();
            string employeeName = txtEmployeeName.Text.Trim();
            string position = txtPosition.Text.Trim();
            string authority = cbAuthoriry.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(employeeCode) || string.IsNullOrEmpty(employeeName) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all required fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Employee newEmployee = new Employee
            {
                EmployeeCode = employeeCode,
                EmployeeName = employeeName,
                Position = position,
                Authority = authority,
                Username = username,
                PasswordHash = password, // Sẽ được hash trong AuthService
                PasswordReset = false
            };

            try
            {
                AuthService.Register(newEmployee);
                MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Login LoginForm = new Login();
                LoginForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Hide();
            Login.ShowDialog();
        }
    }
}
