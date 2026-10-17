#nullable disable
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MinorProject3.Pages
{
    public class ManagersModel : PageModel
    {
        private readonly DataAccess db = new DataAccess();

        public DataTable ManagersTable { get; set; }
        public DataTable ClubsTable { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string TacticalStyle { get; set; }

        [BindProperty]
        public int? ClubID { get; set; }

        public void OnGet()
        {
            LoadData();
        }

        public IActionResult OnPostAdd()
        {
            if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName))
            {
                var vals = new Dictionary<string, object>
                {
                    { "FirstName", FirstName.Trim() },
                    { "LastName", LastName.Trim() },
                    { "TacticalStyle", string.IsNullOrWhiteSpace(TacticalStyle) ? (object)DBNull.Value : TacticalStyle.Trim() },
                    { "ClubID", ClubID.HasValue ? (object)ClubID.Value : DBNull.Value }
                };
                db.InsertRecord("Manager", vals);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            db.DeleteRecord("Manager", "ManagerID", id);
            return RedirectToPage();
        }

        private void LoadData()
        {
            ManagersTable = db.GetManagers();
            ClubsTable = db.GetAllRecords("Club");
        }
    }
}