namespace WebApplication5.Interface
{
    public interface ITokenService
    {
        string GenerateToken(string username, string role);
    }
}
