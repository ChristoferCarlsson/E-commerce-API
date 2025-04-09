namespace WebApplication5.Interfaces
{
    public interface IExternalApiService
    {
        Task<string> GetExternalDataAsync(string url);
    }
}
