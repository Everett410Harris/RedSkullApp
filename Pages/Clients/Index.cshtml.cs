using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RedSkullApp.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();   
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=localhost;Initial Catalog=skullcustoms;Integrated Security=True ";
            }
            catch (Exception ex)
            {
                
            }
        }
    }

    public class ClientInfo
    {
        public String id;
        public String name;
        public String email;
        public String phone;
        public String address;
    }
}
