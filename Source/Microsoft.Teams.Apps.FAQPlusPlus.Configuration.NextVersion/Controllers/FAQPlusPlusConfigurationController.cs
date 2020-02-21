using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Teams.Apps.FAQPlusPlus.Configuration.NextVersion.Models;
using Microsoft.Teams.Apps.FAQPlusPlus.Configuration.NextVersion.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microsoft.Teams.Apps.FAQPlusPlus.Configuration.NextVersion.Controllers
{
    [Route("api/[controller]")]
    public class FAQPlusPlusConfigurationController : Controller
    {
        private readonly FAQPlusPlusConfigurationService faqPlusPlusConfigurationService;

        public FAQPlusPlusConfigurationController(FAQPlusPlusConfigurationService faqPlusPlusConfigurationService)
        {
            this.faqPlusPlusConfigurationService = faqPlusPlusConfigurationService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<FAQPlusPlusConfiguration> GetSettings()
        {
            return await this.faqPlusPlusConfigurationService.GetAsync();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task UpdateSettings([FromBody]FAQPlusPlusConfiguration faqPlusPlusConfiguration)
        {
            await this.faqPlusPlusConfigurationService.SaveAsync(faqPlusPlusConfiguration);
        }
    }
}
