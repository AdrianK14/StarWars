namespace StarWars.Extensions
{
    public static class StringExtensions
    {
        public static string CombineUrl(this string basePart, string relativePart)
        {
            return $"{basePart.TrimEnd('/')}/{relativePart.TrimStart('/')}/";
        }
    }
}
