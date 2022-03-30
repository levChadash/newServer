namespace BL
{
    public interface IPasswordHashHelperBL
    {
        string GenerateSalt(int nSalt);
        string HashPassword(string password, string salt, int nIterations, int nHash);
    }
}