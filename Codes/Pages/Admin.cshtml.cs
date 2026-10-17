#nullable disable
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MinorProject3.Pages
{
    public class AdminModel : PageModel
    {
        private readonly DataAccess db = new DataAccess();

        public DataTable ClubsTable { get; set; }

        [BindProperty]
        public string ClubName { get; set; }

        [BindProperty]
        public string City { get; set; }

        [BindProperty]
        public string Stadium { get; set; }

        public void OnGet()
        {
            LoadData();
        }

        public IActionResult OnPostAdd()
        {
            if (!string.IsNullOrWhiteSpace(ClubName))
            {
                var vals = new Dictionary<string, object>
                {
                    { "ClubName", ClubName.Trim() },
                    { "City", string.IsNullOrWhiteSpace(City) ? (object)DBNull.Value : City.Trim() },
                    { "Stadium", string.IsNullOrWhiteSpace(Stadium) ? (object)DBNull.Value : Stadium.Trim() }
                };
                db.InsertRecord("Club", vals);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            db.DeleteRecord("Club", "ClubID", id);
            return RedirectToPage();
        }

        private void LoadData()
        {
            ClubsTable = db.GetAllRecords("Club");
        }
    }
}