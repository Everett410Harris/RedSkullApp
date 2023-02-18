using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace RedSkullApp.Pages.Clients
{
    public class IndexModel : PageModel
    {

        // ALLOWS FOR MORE CLIENTS
        public List<ClientInfo> listClients = new List<ClientInfo>();   
        

        // EXECUTED TO ACCESS PAGE 
        public void OnGet()
        {

            // CONNECTS TO DB
            try
            {
                String connectionString = "Data Source=localhost;Initial Catalog=skullcustoms;Integrated Security=True ";

                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        using (SqlDataReader reader = command.ExecuteReader()) 
                        {
                            while (reader.Read()) 
                            {
                                // SAVES DATA OBJECT
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.address = reader.GetString(4);
                                clientInfo.created_at = reader.GetDateTime(5).ToString();

                                // ADDS OBJECTS TO LIST
                                listClients.Add(clientInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }


    // STORES CLIENT DATA
    public class ClientInfo
    {
        public String id;
        public String name;
        public String email;
        public String phone;
        public String address;
        public String created_at;
    }
}
