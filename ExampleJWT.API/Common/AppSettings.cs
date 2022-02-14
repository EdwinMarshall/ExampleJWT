namespace ExampleJWT.API.Common
{
    public class AppSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int LifeTimeOnMinutes { get; set; }
    }
}
