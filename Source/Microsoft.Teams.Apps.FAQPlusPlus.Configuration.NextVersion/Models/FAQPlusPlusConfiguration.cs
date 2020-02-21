using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Teams.Apps.FAQPlusPlus.Configuration.NextVersion.Models
{
    public class FAQPlusPlusConfiguration
    {
        [Required(ErrorMessage = "Enter team ID.")]
        [MinLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Team ID")]
        [RegularExpression(@"(\S)+", ErrorMessage = "Enter team ID which should not contain any whitespace.")]
        public string TeamId { get; set; }

        [Required(ErrorMessage = "Enter knowledge base ID.")]
        [MinLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Knowledge base ID")]
        [RegularExpression(@"(\S)+", ErrorMessage = "Enter knowledge base ID which should not contain any whitespace.")]
        public string KnowledgeBaseId { get; set; }

        [Required(ErrorMessage = "Enter a welcome message.")]
        [StringLength(maximumLength: 300, ErrorMessage = "Enter welcome message which should contain less than 300 characters.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Welcome message")]
        public string WelcomeMessageText { get; set; }

        [Required(ErrorMessage = "Enter help tab text.")]
        [StringLength(maximumLength: 3000, ErrorMessage = "Help tab text should contain less than 3000 characters.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Help tab text")]
        public string HelpTabText { get; set; }
    }
}
