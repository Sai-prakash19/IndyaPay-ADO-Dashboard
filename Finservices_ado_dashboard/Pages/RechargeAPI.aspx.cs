using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;

namespace Finservices_ado_dashboar.Pages
{
    public partial class RechargeAPI : System.Web.UI.Page
    {
        protected void btnRecharge_Click(object sender, EventArgs e)
        {
            string mobile = txtMobile.Text.Trim();
            string op = txtOperator.Text.Trim();
            string amt = txtAmount.Text.Trim();
            string connStr = ConfigurationManager.ConnectionStrings["RechargeDB"].ConnectionString;

            var requestData = new { MobileNumber = mobile, Operator = op, Amount = amt };
            string requestJson = new JavaScriptSerializer().Serialize(requestData);
            string responseJson = "";

            try
            {
                // Call dummy API
                using (var client = new HttpClient())
                {
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("https://jsonplaceholder.typicode.com/posts", content).Result;
                    responseJson = response.Content.ReadAsStringAsync().Result;
                }

                // Log to APILogs table
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string logQuery = "INSERT INTO APILogs (RequestData, ResponseData, CreatedAt) VALUES (@req, @res, GETDATE())";
                    SqlCommand cmd = new SqlCommand(logQuery, conn);
                    cmd.Parameters.AddWithValue("@req", requestJson);
                    cmd.Parameters.AddWithValue("@res", responseJson);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Insert recharge into Recharge table
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string rechargeQuery = "INSERT INTO Recharge (MobileNumber, Operator, Amount, RechargedAt) VALUES (@mob, @op, @amt, GETDATE())";
                    SqlCommand cmd = new SqlCommand(rechargeQuery, conn);
                    cmd.Parameters.AddWithValue("@mob", mobile);
                    cmd.Parameters.AddWithValue("@op", op);
                    cmd.Parameters.AddWithValue("@amt", decimal.Parse(amt));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                lblMessage.Text = "Recharge simulated and logged successfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
