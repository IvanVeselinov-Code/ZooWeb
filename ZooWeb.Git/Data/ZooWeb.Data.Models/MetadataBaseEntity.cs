namespace ZooWeb.Data.Models
{
    public abstract class MetadataBaseEntity : BaseEntity
    {
        public ZooWebUser CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public ZooWebUser? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public ZooWebUser? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
