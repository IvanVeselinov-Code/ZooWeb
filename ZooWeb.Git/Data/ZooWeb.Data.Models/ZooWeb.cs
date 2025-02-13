namespace ZooWeb.Data.Models
{
    public class ZooWebRole : MetadataBaseEntity
    {
        public const string ZooWebRoleDefaultAuthority = "User";

        public string Label { get; set; }

        // CSS Color configuration
        public string Color { get; set; }

        public string Authority { get; set; } = ZooWebRoleDefaultAuthority;
    }
}
