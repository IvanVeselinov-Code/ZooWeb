using Microsoft.AspNetCore.Http;

namespace ZooWeb.Service.Cloud
{
    public interface ICloudinaryService
    {
        Task<Dictionary<string, object>> UploadFile(IFormFile file);
    }
}
