#nullable disable
using System.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MinorProject3.Pages
{
    public class ClubsModel : PageModel
    {
        private readonly DataAccess db = new DataAccess();
        public DataTable ClubsTable { get; set; }

        public void OnGet()
        {
            ClubsTable = db.GetAllRecords("Club");
        }
    }
}