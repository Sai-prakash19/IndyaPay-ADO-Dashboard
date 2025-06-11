using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Finservices_ado_dashboar.Pages
{
    public partial class RechargeHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadRechargeHistory();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            LoadRechargeHistory();
        }

        private void LoadRechargeHistory()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RechargeDB"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Recharge WHERE 1=1";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrEmpty(ddlOperator.SelectedValue))
                {
                    query += " AND Operator = @op";
                    cmd.Parameters.AddWithValue("@op", ddlOperator.SelectedValue);
                }

                if (DateTime.TryParse(txtFromDate.Text, out DateTime fromDate))
                {
                    query += " AND RechargedAt >= @from";
                    cmd.Parameters.AddWithValue("@from", fromDate);
                }

                if (DateTime.TryParse(txtToDate.Text, out DateTime toDate))
                {
                    query += " AND RechargedAt <= @to";
                    cmd.Parameters.AddWithValue("@to", toDate);
                }

                query += " ORDER BY RechargedAt DESC";

                cmd.CommandText = query;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            gvHistory.DataSource = dt;
            gvHistory.DataBind();
            lblCount.Text = $"Total Records: {dt.Rows.Count}";
        }
    }
}
