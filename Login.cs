using System;
using System.Windows.Forms;
using static WindowsFormsAppXStore.Dashboard.AuthService;

namespace WindowsFormsAppXStore
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool isAuthenticated = Login(username, password);

                if (isAuthenticated)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở MainForm và đóng LoginForm
                    Dashboard Dashboard = new Dashboard();
                    this.Hide();
                    Dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            Register Register = new Register();
            this.Hide();
            Register.ShowDialog();
        }
    }
}
