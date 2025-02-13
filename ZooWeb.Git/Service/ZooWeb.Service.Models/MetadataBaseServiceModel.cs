namespace ZooWeb.Service.Models
{
    public abstract class MetadataBaseServiceModel : BaseServiceModel
    {
        public ZooWebUserServiceModel CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public ZooWebUserServiceModel? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public ZooWebUserServiceModel? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
