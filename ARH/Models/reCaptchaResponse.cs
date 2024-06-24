namespace ARH.Models
{
    public class ReCaptchaResponse
    {
        public bool Success { get; set; }
        public DateTime ChallengeTs { get; set; }
        public string Hostname { get; set; }
        public IEnumerable<string> ErrorCodes { get; set; }
    }
}
