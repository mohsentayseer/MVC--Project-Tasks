using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace task_day4.Models
{
    public static class HtmlHelpers
    {
        public static IHtmlContent StyleText(this IHtmlHelper html, string text, string color , bool isBold = true)
        {
            string style = $"color: {color};";
            if (isBold)
            {
                style += " font-weight: bold;";
            }

            string htmlString = $"<td style=\"{style}\">{text}</td>";

            return new HtmlString(htmlString);
        }
    }
}
