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
    public partial class EditEmployeeForm : Form
    {
        private Employee _employee;
        public EditEmployeeForm(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            txtEmployeeCode.Text = _employee.EmployeeCode;
            txtEmployeeName.Text = _employee.EmployeeName;
            txtPosition.Text = _employee.Position;
            cbAuthority.Text = _employee.Authority;
            txtUsername.Text = _employee.Username;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _employee.EmployeeName = txtEmployeeName.Text.Trim();
                _employee.Position = txtPosition.Text.Trim();
                _employee.Authority = cbAuthority.Text.Trim();
                _employee.Username = txtUsername.Text.Trim();

                EmployeeService.UpdateEmployee(_employee);
                MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
