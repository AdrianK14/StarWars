namespace StarWars.Contracts.SwApiClient
{
    public interface IWebClient
    {
        string SendRequest(string url);
    }
}
