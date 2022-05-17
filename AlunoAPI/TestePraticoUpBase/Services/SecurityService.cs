namespace AlunoAPI.Services
{
    public class SecurityService
    {
        public string CriptografaSenha(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }
    }
}
