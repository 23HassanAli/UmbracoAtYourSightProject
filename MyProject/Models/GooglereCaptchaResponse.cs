namespace MyProject.Models
{
    public class GooglereCaptchaResponse
    {
        public double Score { get; set; }
        public bool Success { get; set; }
        public string Response { get; set; }//Token
        public string Secret { get; set; }
    }
}
