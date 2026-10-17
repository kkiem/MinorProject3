#nullable disable
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MinorProject3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess db = new DataAccess();

        public DataTable PlayersTable { get; set; }
        public DataTable ClubsTable { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string Position { get; set; }

        [BindProperty]
        public int? ClubID { get; set; }

        public void OnGet()
        {
            LoadData();
        }

        public IActionResult OnPostSearch()
        {
            LoadData();
            return Page();
        }

        public IActionResult OnPostAdd()
        {
            if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName))
            {
                var vals = new Dictionary<string, object>
                {
                    { "FirstName", FirstName.Trim() },
                    { "LastName", LastName.Trim() },
                    { "Position", string.IsNullOrWhiteSpace(Position) ? (object)DBNull.Value : Position.Trim() },
                    { "ClubID", ClubID.HasValue ? (object)ClubID.Value : DBNull.Value }
                };
                db.InsertRecord("Player", vals);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            db.DeleteRecord("Player", "PlayerID", id);
            return RedirectToPage();
        }

        private void LoadData()
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                PlayersTable = db.GetPlayers();
            }
            else
            {
                PlayersTable = db.SearchPlayers(SearchTerm.Trim());
            }

            ClubsTable = db.GetAllRecords("Club");
        }
    }
}