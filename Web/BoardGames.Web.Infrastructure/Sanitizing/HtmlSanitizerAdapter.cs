namespace BoardGames.Web.Infrastructure.Sanitizing
{
    using Ganss.XSS;

    public class HtmlSanitizerAdapter
    {
        public static string Sanitize(string html)
        {
            var sanitizer = new HtmlSanitizer();
            var result = sanitizer.Sanitize(html);
            return result;
        }
    }
}
