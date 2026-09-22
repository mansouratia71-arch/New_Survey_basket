namespace Survey_Basket.Dto
{
    public class SettingJwt
    {
        public const string getSection = "jwt";
      public string Key { get; set; }=string.Empty;
      public string Issuer {  get; set; }= string.Empty;

        public string Audience { get; set; } = string.Empty;
      public int DurationInMinutes {  get; set; }

    }
}
