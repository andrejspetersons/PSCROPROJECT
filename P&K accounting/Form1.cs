using System.Windows.Forms;
using System.Data.SqlClient;
using P_K_accounting.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Globalization;

namespace P_K_accounting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void submitbill_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                string amountTextBoxInput = amountTextBox.Text;
                amountTextBoxInput = amountTextBoxInput.Replace(decimalSeparator == "." ? "," : ".", decimalSeparator);
                BillViewModel paymentbill = new BillViewModel();
                paymentbill.Login = clientDropDown.SelectedItem.ToString();
                paymentbill.ServiceName = serviceDropDown.SelectedItem.ToString();
                decimal amount;
                if(decimal.TryParse(amountTextBoxInput,NumberStyles.Number,CultureInfo.InvariantCulture, out amount))
                {
                    paymentbill.Amount = Convert.ToDecimal(amountTextBoxInput);
                }
                else
                {
                    MessageBox.Show($"Input {amountTextBoxInput} is not valid","Error",MessageBoxButtons.OK);
                    return;
                }
                
                paymentbill.IssueDate = Convert.ToDateTime(issueDatePicker.Text);
                paymentbill.DueToDate = Convert.ToDateTime(payToDatePicker.Text);

                string jsonData = JsonSerializer.Serialize(paymentbill);
                StringContent content = new StringContent(jsonData,Encoding.UTF8, "application/json");

                try
                {
                   HttpResponseMessage response = await client.PostAsync("http://localhost:5239/paymentbill",content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Payment bill was successfully added", "Success", MessageBoxButtons.OK);
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.;Initial Catalog=PSI_CRO_DB;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string selectUsersQuery = "SELECT Login FROM Clients";
                using (SqlDataReader reader = ExecuteQuery(con, selectUsersQuery))
                {
                    clientDropDown.Items.Clear();
                    while (reader.Read())
                    {
                        string login = reader[0].ToString();//possible that was null
                        clientDropDown.Items.Add(login);
                    }
                }

                string selectServicesquery = "SELECT Name FROM CompanyServices";
                using (SqlDataReader reader = ExecuteQuery(con, selectServicesquery))
                {
                    serviceDropDown.Items.Clear();
                    while (reader.Read())
                    {
                        string serviceName = reader[0].ToString();
                        serviceDropDown.Items.Add(serviceName);
                    }
                }

                con.Close();
            }
        }

        private SqlDataReader ExecuteQuery(SqlConnection con, string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            return cmd.ExecuteReader();
        }

    }
}
