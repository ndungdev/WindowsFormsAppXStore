using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace WindowsFormsAppXStore
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            LoadProducts();
            LoadEmployees();
            LoadCustomers();
            LoadSales();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Hide();
            Login.Show();
        }
        public static class Database
        {
            private static readonly string connectionString = @"Data Source=MSI;Initial Catalog=X_Store;Integrated Security=True";

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
        }

        public class Product
        {
            public int ProductID { get; set; }          // Primary Key
            public string ProductCode { get; set; }    // Mã sản phẩm
            public string ProductName { get; set; }    // Tên sản phẩm
            public decimal SellingPrice { get; set; }  // Giá bán
            public int InventoryQuantity { get; set; } // Số lượng tồn kho
            public string ImageURL { get; set; }       // Đường dẫn hình ảnh
        }

        public class Employee
        {
            public int EmployeeID { get; set; }          // Primary Key
            public string EmployeeCode { get; set; }    // Mã nhân viên
            public string EmployeeName { get; set; }    // Tên nhân viên
            public string Position { get; set; }        // Chức vụ
            public string Authority { get; set; }       // Quyền hạn
            public string Username { get; set; }        // Tên đăng nhập
            public string PasswordHash { get; set; }    // Mật khẩu mã hóa
            public bool PasswordReset { get; set; }     // Đặt lại mật khẩu
        }

        public class Customer
        {
            public int CustomerID { get; set; }        // Primary Key
            public string CustomerCode { get; set; }  // Mã khách hàng
            public string CustomerName { get; set; }  // Tên khách hàng
            public string PhoneNumber { get; set; }   // Số điện thoại
            public string Address { get; set; }       // Địa chỉ
        }

        public class Sale
        {
            public int SaleID { get; set; }            // Primary Key
            public DateTime SaleDate { get; set; }    // Ngày bán
            public decimal TotalAmount { get; set; }  // Tổng số tiền
            public int EmployeeID { get; set; }       // Foreign Key -> Employee
            public int CustomerID { get; set; }       // Foreign Key -> Customer
        }

        public class SaleDetail
        {
            public int SaleDetailID { get; set; }      // Primary Key
            public int SaleID { get; set; }           // Foreign Key -> Sale
            public int ProductID { get; set; }        // Foreign Key -> Product
            public int Quantity { get; set; }         // Số lượng
            public decimal SellingPrice { get; set; } // Giá bán mỗi sản phẩm
            public decimal Subtotal { get; set; }     // Tổng tiền (Quantity * SellingPrice)
        }

        public class InventoryTransaction
        {
            public int TransactionID { get; set; }    // Primary Key
            public int ProductID { get; set; }        // Foreign Key -> Product
            public string TransactionType { get; set; } // Loại giao dịch ('Import', 'Sale')
            public int Quantity { get; set; }         // Số lượng
            public DateTime TransactionDate { get; set; } // Ngày giao dịch
        }
        public static class UserSession
        {
            public static string Username { get; set; }
            public static string Authority { get; set; }

            public static void SetUser(string username, string authority)
            {
                Username = username;
                Authority = authority;
            }

            public static void Clear()
            {
                Username = null;
                Authority = null;
            }
        }
        public static class AuthService
        {
            public static void Register(Employee employee)
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Employee 
                                 (EmployeeCode, EmployeeName, Position, Authority, Username, PasswordHash, PasswordReset) 
                                 VALUES (@EmployeeCode, @EmployeeName, @Position, @Authority, @Username, @PasswordHash, @PasswordReset)";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
                        cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                        cmd.Parameters.AddWithValue("@Position", employee.Position);
                        cmd.Parameters.AddWithValue("@Authority", employee.Authority);
                        cmd.Parameters.AddWithValue("@Username", employee.Username);
                        cmd.Parameters.AddWithValue("@PasswordHash", HashPassword(employee.PasswordHash));
                        cmd.Parameters.AddWithValue("@PasswordReset", employee.PasswordReset);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            /// <summary>
            /// Hash mật khẩu người dùng.
            /// </summary>
            /// <param name="password">Mật khẩu gốc.</param>
            /// <returns>Chuỗi hash của mật khẩu.</returns>
            private static string HashPassword(string password)
            {
                using (var sha256 = System.Security.Cryptography.SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    return Convert.ToBase64String(bytes);
                }
            }
            /// <summary>
            /// Kiểm tra thông tin đăng nhập của người dùng.
            /// </summary>
            /// <param name="username">Tên đăng nhập.</param>
            /// <param name="password">Mật khẩu.</param>
            /// <returns>True nếu xác thực thành công, ngược lại là False.</returns>
            public static bool Login(string username, string password)
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT PasswordHash, Authority FROM Employee WHERE Username = @Username";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["PasswordHash"].ToString();
                                string authority = reader["Authority"].ToString();
                                UserSession.SetUser(username, authority);
                                return VerifyPassword(password, storedHash);
                            }
                        }
                    }
                }
                return false; // Sai username hoặc password
            }

            /// <summary>
            /// Kiểm tra mật khẩu bằng cách so sánh với hash được lưu trong cơ sở dữ liệu.
            /// </summary>
            /// <param name="password">Mật khẩu người dùng nhập.</param>
            /// <param name="storedHash">Hash được lưu trữ trong cơ sở dữ liệu.</param>
            /// <returns>True nếu khớp, False nếu không.</returns>
            private static bool VerifyPassword(string password, string storedHash)
            {
                string hashedInput = HashPassword(password);
                return hashedInput == storedHash;
            }
        }
        public static class ProductService
        {
            public static List<Product> GetAllProducts()
            {
                var products = new List<Product>();
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Product";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Product
                                {
                                    ProductID = reader.GetInt32(0),
                                    ProductCode = reader.GetString(1),
                                    ProductName = reader.GetString(2),
                                    SellingPrice = reader.GetDecimal(3),
                                    InventoryQuantity = reader.GetInt32(4),
                                    ImageURL = reader.IsDBNull(5) ? null : reader.GetString(5)
                                });
                            }
                        }
                    }
                }
                return products;
            }

            public static void AddProduct(Product product)
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Product (ProductCode, ProductName, SellingPrice, InventoryQuantity, ImageURL) " +
                                   "VALUES (@Code, @Name, @Price, @Quantity, @Image)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Code", product.ProductCode);
                        cmd.Parameters.AddWithValue("@Name", product.ProductName);
                        cmd.Parameters.AddWithValue("@Price", product.SellingPrice);
                        cmd.Parameters.AddWithValue("@Quantity", product.InventoryQuantity);
                        cmd.Parameters.AddWithValue("@Image", (object)product.ImageURL ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public static void UpdateProduct(Product product)
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Product SET ProductCode = @Code, ProductName = @Name, " +
                                   "SellingPrice = @Price, InventoryQuantity = @Quantity, ImageURL = @Image " +
                                   "WHERE ProductID = @ID";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", product.ProductID);
                        cmd.Parameters.AddWithValue("@Code", product.ProductCode);
                        cmd.Parameters.AddWithValue("@Name", product.ProductName);
                        cmd.Parameters.AddWithValue("@Price", product.SellingPrice);
                        cmd.Parameters.AddWithValue("@Quantity", product.InventoryQuantity);
                        cmd.Parameters.AddWithValue("@Image", (object)product.ImageURL ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public static void DeleteProduct(int productId)
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Product WHERE ProductID = @ID";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", productId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public static List<Product> SearchProduct(string searchTerm)
            {
                var products = new List<Product>();
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT * FROM Product 
                                 WHERE ProductName LIKE @SearchTerm OR ProductCode LIKE @SearchTerm";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Product
                                {
                                    ProductID = reader.GetInt32(0),
                                    ProductCode = reader.GetString(1),
                                    ProductName = reader.GetString(2),
                                    SellingPrice = reader.GetDecimal(3),
                                    InventoryQuantity = reader.GetInt32(4),
                                    ImageURL = reader.IsDBNull(5) ? null : reader.GetString(5)
                                });
                            }
                        }
                    }
                }
                return products;
            }
        }

        private void LoadProducts()
        {
            try
            {
                var products = ProductService.GetAllProducts();
                dataGridViewProDucts.DataSource = products;
                dataGridViewProDucts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a search term.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadProducts(); // Load all products if search term is empty
                return;
            }

            try
            {
                var products = ProductService.SearchProduct(searchTerm);
                if (products.Count > 0)
                {
                    dataGridViewProDucts.DataSource = products;
                }
                else
                {
                    MessageBox.Show("No products found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewProDucts.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (UserSession.Authority == "Full" || UserSession.Authority == "Warehouse")
            {
                // Mở Popup Form để thêm sản phẩm
                AddProductForm addProductForm = new AddProductForm();
                if (addProductForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Có thể tải lại danh sách sản phẩm nếu có GridView
                    LoadProducts();
                }
            }
            else
            {
                MessageBox.Show($"You do not have permission to add product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (UserSession.Authority == "Full" || UserSession.Authority == "Warehouse")
            {
                if (dataGridViewProDucts.CurrentRow == null)
                {
                    MessageBox.Show("Please select a product to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedProduct = (Product)dataGridViewProDucts.CurrentRow.DataBoundItem;

                EditProductForm editForm = new EditProductForm(selectedProduct);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
            else
            {
                MessageBox.Show($"You do not have permission to edit product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (UserSession.Authority == "Full" || UserSession.Authority == "Warehouse")
            {
                    if (dataGridViewProDucts.CurrentRow == null)
                {
                    MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedProduct = (Product)dataGridViewProDucts.CurrentRow.DataBoundItem;

                var confirmResult = MessageBox.Show($"Are you sure to delete the product '{selectedProduct.ProductName}'?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        ProductService.DeleteProduct(selectedProduct.ProductID);
                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show($"You do not have permission to delete product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static class EmployeeService
        {

            // 1. Thêm nhân viên
            public static void AddEmployee(Employee employee)
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Employee (EmployeeCode, EmployeeName, Position, Authority, Username, PasswordHash, PasswordReset)
                                 VALUES (@EmployeeCode, @EmployeeName, @Position, @Authority, @Username, @PasswordHash, @PasswordReset)";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
                        cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                        cmd.Parameters.AddWithValue("@Position", employee.Position);
                        cmd.Parameters.AddWithValue("@Authority", employee.Authority);
                        cmd.Parameters.AddWithValue("@Username", employee.Username);
                        cmd.Parameters.AddWithValue("@PasswordHash", employee.PasswordHash);
                        cmd.Parameters.AddWithValue("@PasswordReset", employee.PasswordReset);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // 2. Lấy danh sách nhân viên
            public static List<Employee> GetEmployees()
            {
                var employees = new List<Employee>();

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Employee";

                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                EmployeeCode = reader["EmployeeCode"].ToString(),
                                EmployeeName = reader["EmployeeName"].ToString(),
                                Position = reader["Position"].ToString(),
                                Authority = reader["Authority"].ToString(),
                                Username = reader["Username"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                PasswordReset = Convert.ToBoolean(reader["PasswordReset"])
                            });
                        }
                    }
                }

                return employees;
            }

            // 3. Cập nhật nhân viên
            public static void UpdateEmployee(Employee employee)
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE Employee
                                 SET EmployeeCode = @EmployeeCode,
                                     EmployeeName = @EmployeeName,
                                     Position = @Position,
                                     Authority = @Authority,
                                     Username = @Username,
                                     PasswordHash = @PasswordHash,
                                     PasswordReset = @PasswordReset
                                 WHERE EmployeeID = @EmployeeID";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                        cmd.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
                        cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                        cmd.Parameters.AddWithValue("@Position", employee.Position);
                        cmd.Parameters.AddWithValue("@Authority", employee.Authority);
                        cmd.Parameters.AddWithValue("@Username", employee.Username);
                        cmd.Parameters.AddWithValue("@PasswordHash", employee.PasswordHash);
                        cmd.Parameters.AddWithValue("@PasswordReset", employee.PasswordReset);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // 4. Xóa nhân viên
            public static void DeleteEmployee(int employeeID)
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // 5. Tìm kiếm nhân viên theo tên hoặc mã nhân viên
            public static List<Employee> SearchEmployees(string keyword)
            {
                var employees = new List<Employee>();

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT * FROM Employee
                                 WHERE EmployeeName LIKE @Keyword OR EmployeeCode LIKE @Keyword";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(new Employee
                                {
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    EmployeeCode = reader["EmployeeCode"].ToString(),
                                    EmployeeName = reader["EmployeeName"].ToString(),
                                    Position = reader["Position"].ToString(),
                                    Authority = reader["Authority"].ToString(),
                                    Username = reader["Username"].ToString(),
                                    PasswordHash = reader["PasswordHash"].ToString(),
                                    PasswordReset = Convert.ToBoolean(reader["PasswordReset"])
                                });
                            }
                        }
                    }
                }

                return employees;
            }
        }
        private void LoadEmployees()
        {
            try
            {
                var employees = EmployeeService.GetEmployees();
                dataGridViewEmployees.DataSource = employees;
                dataGridViewEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchEmployee.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a search term.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadEmployees(); // Load all employees if search term is empty
                return;
            }

            try
            {
                var employees = EmployeeService.SearchEmployees(searchTerm);
                if (employees.Count > 0)
                {
                    dataGridViewEmployees.DataSource = employees;
                }
                else
                {
                    MessageBox.Show("No employees found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewEmployees.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (UserSession.Authority == "Full")
            {
                // Mở Popup Form để thêm sản phẩm
                AddEmployeeForm AddEmployeeForm = new AddEmployeeForm();
                if (AddEmployeeForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Có thể tải lại danh sách sản phẩm nếu có GridView
                    LoadEmployees();
                }
            }
            else
            {
                MessageBox.Show($"You do not have permission to add employee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            if (UserSession.Authority == "Full")
            {
                if (dataGridViewEmployees.CurrentRow == null)
                {
                    MessageBox.Show("Please select an employee to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedEmployee = (Employee)dataGridViewEmployees.CurrentRow.DataBoundItem;

                EditEmployeeForm editForm = new EditEmployeeForm(selectedEmployee);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadEmployees();
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to edit employees.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (UserSession.Authority == "Full")
            {
                if (dataGridViewEmployees.CurrentRow == null)
                {
                    MessageBox.Show("Please select an employee to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedEmployee = (Employee)dataGridViewEmployees.CurrentRow.DataBoundItem;

                var confirmResult = MessageBox.Show($"Are you sure to delete the employee '{selectedEmployee.EmployeeName}'?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        EmployeeService.DeleteEmployee(selectedEmployee.EmployeeID);
                        MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployees();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to delete employees.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static class CustomerService
        {

            // Retrieve all customers
            public static List<Customer> GetAllCustomers()
            {
                var customers = new List<Customer>();

                using (var connection = Database.GetConnection())
                {
                    string query = "SELECT * FROM Customer";
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customers.Add(new Customer
                                {
                                    CustomerID = (int)reader["CustomerID"],
                                    CustomerCode = reader["CustomerCode"].ToString(),
                                    CustomerName = reader["CustomerName"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Address = reader["Address"].ToString()
                                });
                            }
                        }
                    }
                }

                return customers;
            }

            // Search customers
            public static List<Customer> SearchCustomers(string searchTerm)
            {
                var customers = new List<Customer>();

                using (var connection = Database.GetConnection())
                {
                    string query = "SELECT * FROM Customer WHERE CustomerName LIKE @Search OR PhoneNumber LIKE @Search";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Search", $"%{searchTerm}%");
                        connection.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customers.Add(new Customer
                                {
                                    CustomerID = (int)reader["CustomerID"],
                                    CustomerCode = reader["CustomerCode"].ToString(),
                                    CustomerName = reader["CustomerName"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Address = reader["Address"].ToString()
                                });
                            }
                        }
                    }
                }

                return customers;
            }

            // Add new customer
            public static void AddCustomer(Customer customer)
            {
                using (var connection = Database.GetConnection())
                {
                    string query = "INSERT INTO Customer (CustomerCode, CustomerName, PhoneNumber, Address) VALUES (@Code, @Name, @Phone, @Address)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", customer.CustomerCode);
                        command.Parameters.AddWithValue("@Name", customer.CustomerName);
                        command.Parameters.AddWithValue("@Phone", customer.PhoneNumber);
                        command.Parameters.AddWithValue("@Address", customer.Address);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Update existing customer
            public static void UpdateCustomer(Customer customer)
            {
                using (var connection = Database.GetConnection())
                {
                    string query = "UPDATE Customer SET CustomerName = @Name, PhoneNumber = @Phone, Address = @Address WHERE CustomerID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", customer.CustomerID);
                        command.Parameters.AddWithValue("@Name", customer.CustomerName);
                        command.Parameters.AddWithValue("@Phone", customer.PhoneNumber);
                        command.Parameters.AddWithValue("@Address", customer.Address);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        private void LoadCustomers()
        {
            try
            {
                var customers = CustomerService.GetAllCustomers();
                dataGridViewCustomers.DataSource = customers;
                dataGridViewCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (UserSession.Authority == "Full" || UserSession.Authority == "Sale")
            {

                AddCustomerForm addCustomerForm = new AddCustomerForm();
                if (addCustomerForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to add customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (UserSession.Authority == "Full" || UserSession.Authority == "Sale")
            {
                if (dataGridViewCustomers.CurrentRow == null)
                {
                    MessageBox.Show("Please select a customer to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedCustomer = (Customer)dataGridViewCustomers.CurrentRow.DataBoundItem;

                EditCustomerForm editCustomerForm = new EditCustomerForm(selectedCustomer);
                if (editCustomerForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomers();
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to add customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchCustomer.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a search term.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadCustomers(); // Load all customers if search term is empty
                return;
            }

            try
            {
                var customers = CustomerService.SearchCustomers(searchTerm);
                if (customers.Count > 0)
                {
                    dataGridViewCustomers.DataSource = customers;
                }
                else
                {
                    MessageBox.Show("No customers found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewCustomers.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static class SaleService
        {

            public static List<Sale> GetSales(string searchTerm = "")
            {
                List<Sale> sales = new List<Sale>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "SELECT * FROM Sales WHERE SaleID LIKE @Search OR CustomerID LIKE @Search";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Search", $"%{searchTerm}%");

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        sales.Add(new Sale
                        {
                            SaleID = Convert.ToInt32(reader["SaleID"]),
                            SaleDate = Convert.ToDateTime(reader["SaleDate"]),
                            TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            CustomerID = Convert.ToInt32(reader["CustomerID"])
                        });
                    }
                }
                return sales;
            }

            public static int AddSale(Sale sale)
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = @"INSERT INTO Sales (SaleDate, TotalAmount, EmployeeID, CustomerID) 
                             OUTPUT INSERTED.SaleID
                             VALUES (@SaleDate, @TotalAmount, @EmployeeID, @CustomerID)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SaleDate", sale.SaleDate);
                    cmd.Parameters.AddWithValue("@TotalAmount", sale.TotalAmount);
                    cmd.Parameters.AddWithValue("@EmployeeID", sale.EmployeeID);
                    cmd.Parameters.AddWithValue("@CustomerID", sale.CustomerID);

                    conn.Open();
                    int saleId = (int)cmd.ExecuteScalar(); // Return the generated SaleID
                    return saleId;
                }
            }


            public static Sale GetSaleById(int saleID)
            {
                Sale sale = null;

                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "SELECT * FROM Sales WHERE SaleID = @SaleID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SaleID", saleID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        sale = new Sale
                        {
                            SaleID = Convert.ToInt32(reader["SaleID"]),
                            SaleDate = Convert.ToDateTime(reader["SaleDate"]),
                            TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            CustomerID = Convert.ToInt32(reader["CustomerID"])
                        };
                    }
                }

                return sale;
            }
        }
        private void LoadSales()
        {
            try
            {
                var sales = SaleService.GetSales(txtSearch.Text.Trim());
                dataGridViewSales.DataSource = sales;
                dataGridViewSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchSale_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchSale.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a search term.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadSales(); // Load all sales if search term is empty
                return;
            }

            try
            {
                var sales = SaleService.GetSales(searchTerm); // Search by SaleID or CustomerID
                if (sales.Count > 0)
                {
                    dataGridViewSales.DataSource = sales;
                }
                else
                {
                    MessageBox.Show("No sales found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewSales.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching sales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static class SaleDetailService
        {

            public static List<SaleDetail> GetSaleDetailsBySaleId(int saleID)
            {
                List<SaleDetail> saleDetails = new List<SaleDetail>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "SELECT * FROM SaleDetails WHERE SaleID = @SaleID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SaleID", saleID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        saleDetails.Add(new SaleDetail
                        {
                            SaleDetailID = Convert.ToInt32(reader["SaleDetailID"]),
                            SaleID = Convert.ToInt32(reader["SaleID"]),
                            ProductID = Convert.ToInt32(reader["ProductID"]),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
                            Subtotal = Convert.ToDecimal(reader["Subtotal"])
                        });
                    }
                }

                return saleDetails;
            }
            public static void AddSaleDetail(SaleDetail saleDetail)
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = @"INSERT INTO SaleDetails (SaleID, ProductID, Quantity, SellingPrice, Subtotal) 
                             VALUES (@SaleID, @ProductID, @Quantity, @SellingPrice, @Subtotal)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SaleID", saleDetail.SaleID);
                    cmd.Parameters.AddWithValue("@ProductID", saleDetail.ProductID);
                    cmd.Parameters.AddWithValue("@Quantity", saleDetail.Quantity);
                    cmd.Parameters.AddWithValue("@SellingPrice", saleDetail.SellingPrice);
                    cmd.Parameters.AddWithValue("@Subtotal", saleDetail.Subtotal);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnViewSale_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.CurrentRow == null)
            {
                MessageBox.Show("Please select a sale to view details.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedSale = (Sale)dataGridViewSales.CurrentRow.DataBoundItem;

            SaleDetailsForm detailsForm = new SaleDetailsForm(selectedSale.SaleID);
            detailsForm.ShowDialog();
        }

        private void btnAddSale_Click(object sender, EventArgs e)
        {
            if (UserSession.Authority == "Full" || UserSession.Authority == "Sale")
            {

                AddSaleForm AddSaleForm = new AddSaleForm();
                if (AddSaleForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSales();
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to add customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
