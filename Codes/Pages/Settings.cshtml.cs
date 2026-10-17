#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MinorProject3.Pages
{
    public class SettingsModel : PageModel
    {
        [BindProperty]
        public bool DarkMode { get; set; }

        [BindProperty]
        public bool AskBeforeDelete { get; set; }

        public string SavedMessage { get; set; }

        public void OnGet()
        {
            var settings = AppSettings.Load();
            DarkMode = settings.DarkMode;
            AskBeforeDelete = settings.AskBeforeDelete;
        }

        public IActionResult OnPost()
        {
            var settings = AppSettings.Load();
            settings.DarkMode = DarkMode;
            settings.AskBeforeDelete = AskBeforeDelete;
            settings.Save();

            SavedMessage = "Settings saved successfully!";
            return Page();
        }
    }
}