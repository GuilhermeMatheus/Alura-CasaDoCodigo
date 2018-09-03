using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigoWeb.TagHelpers
{
    // <moneyDisplay> </moneyDisplay>
    public class MoneyDisplayTagHelper : TagHelper
    {
        private CultureInfo _culture = CultureInfo.GetCultureInfo("pt-BR");
        public decimal Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = Value.ToString("C", _culture);

            output.TagName = "span";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetContent(content);

            // base.Process(context, output);
        }
    }
}
