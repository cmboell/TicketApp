using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
//custom tag helper that stylizes the submit buttons
namespace TicketApp.Models
{
    [HtmlTargetElement(Attributes = "[type=submit]")]
    public class SubmitButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context,
  TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "btn btn-primary btn-small");

        }
    }
}
