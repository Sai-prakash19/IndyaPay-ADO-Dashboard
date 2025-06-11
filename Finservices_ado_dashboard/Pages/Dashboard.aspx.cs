using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Finservices_ado_dashboard.Pages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadDashboardStats();
        }

        private void LoadDashboardStats()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RechargeDB"].ConnectionString;

            int totalRecharges = 0;
            decimal totalAmount = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) AS Total, ISNULL(SUM(Amount),0) AS TotalAmount FROM Recharge";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    totalRecharges = Convert.ToInt32(reader["Total"]);
                    totalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                }
            }

            lblTotalRecharges.Text = totalRecharges.ToString("N0");
            lblTotalAmount.Text = "₹ " + totalAmount.ToString("N2");
        }
    }
}
