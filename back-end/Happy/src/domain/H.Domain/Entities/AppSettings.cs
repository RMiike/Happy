namespace H.Domain.Entities
{
    public class AppSettings
    {
        public string BaseUrl { get; set; }
        public string RemoteBaseUrl { get; set; }
        public string Secret { get; set; }
        public int ExpirationHours { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string MailServiceKey { get; set; }
        public string MailServiceFrom { get; set; }
    }
}
