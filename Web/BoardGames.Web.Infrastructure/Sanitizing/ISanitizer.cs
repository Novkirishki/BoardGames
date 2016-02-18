namespace BoardGames.Web.Infrastructure.Sanitizing
{
    public interface ISanitizer
    {
        string Sanitize(string html);
    }
}
