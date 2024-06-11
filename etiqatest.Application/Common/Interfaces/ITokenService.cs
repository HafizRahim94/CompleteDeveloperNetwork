namespace etiqatest.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string username);
    }
}