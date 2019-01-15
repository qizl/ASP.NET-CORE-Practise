using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MvcCore.TagHelpers
{
    [HtmlTargetElement("email")]
    public class EmailTagHelper : TagHelper
    {
        // Can be passed via <email mail-to="..." />. 
        // Pascal case gets translated into lower-kebab-case.
        public string MailTo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";    // Replaces <email> with <a> tag
            
            output.Attributes.SetAttribute("href", "mailto:" + MailTo);
            output.Content.SetContent(MailTo);
        }
    }
}