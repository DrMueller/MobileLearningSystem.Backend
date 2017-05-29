namespace Mmu.Mls.WebServices.Infrastructure.Settings
{
    public class AppSettings
    {
        public const string SECTION_NAME = "AppSettings";

        public string DocumentDbAuthKey { get; set; }

        public string DocumentDbCollectionId { get; set; }

        public string DocumentDbDatabaseId { get; set; }

        public string DocumentDbServiceEndpointUrl { get; set; }
    }
}