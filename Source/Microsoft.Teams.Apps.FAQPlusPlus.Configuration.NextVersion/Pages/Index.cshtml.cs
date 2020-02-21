using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Teams.Apps.FAQPlusPlus.Configuration.NextVersion.Models;
using Microsoft.Teams.Apps.FAQPlusPlus.Configuration.NextVersion.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Teams.Apps.FAQPlusPlus.Configuration.NextVersion.Pages
{
    public class IndexModel : PageModel
    {
        private readonly FAQPlusPlusConfigurationService faqPlusPlusConfigurationService;

        public IndexModel(FAQPlusPlusConfigurationService faqPlusPlusConfigurationService)
        {
            this.faqPlusPlusConfigurationService = faqPlusPlusConfigurationService;
        }

        [BindProperty]
        public FAQPlusPlusConfiguration FAQPlusPlusConfiguration { get; set; }

        public void OnGet()
        {
            this.FAQPlusPlusConfiguration = this.faqPlusPlusConfigurationService.GetAsync().Result;
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                this.faqPlusPlusConfigurationService.SaveAsync(this.FAQPlusPlusConfiguration).Wait();
            }
        }
    }
}