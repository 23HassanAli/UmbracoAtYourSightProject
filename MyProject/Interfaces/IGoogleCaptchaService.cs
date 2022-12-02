namespace MyProject.Interfaces
{
    public interface IGoogleCaptchaService
    {
        Task<bool> VerifyToken(string token);
    }
}
