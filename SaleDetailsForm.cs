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
    public partial class SaleDetailsForm : Form
    {
        private int _saleID;

        public SaleDetailsForm(int saleID)
        {
            InitializeComponent();
            _saleID = saleID;
        }

        private void SaleDetailsForm_Load(object sender, EventArgs e)
        {
            LoadSaleDetails();
        }
        private void LoadSaleDetails()
        {
            try
            {
                // Load Sale Info
                var sale = SaleService.GetSaleById(_saleID);
                if (sale != null)
                {
                    lblSaleInfo.Text = $"Sale ID: {sale.SaleID} | Date: {sale.SaleDate} | Total: {sale.TotalAmount:C}";
                }

                // Load Sale Details
                var saleDetails = SaleDetailService.GetSaleDetailsBySaleId(_saleID);
                dataGridViewSaleDetails.DataSource = saleDetails;
                dataGridViewSaleDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sale details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
