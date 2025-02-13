using ZooWeb.Service.Cloud;
using ZooWeb.Service.Community;
using ZooWeb.Service.Models;
using ZooWeb.Web.Models.Community;
using Microsoft.AspNetCore.Mvc;

namespace ZooWeb.Web.Controllers
{
    public class CommunityController : Controller
    {
        private readonly IZooWebCommunityService ZooWebCommunityService;

        private readonly ICloudinaryService cloudinaryService;

        public CommunityController(IZooWebCommunityService ZooWebCommunityService, 
            ICloudinaryService cloudinaryService)
        {
            this.ZooWebCommunityService = ZooWebCommunityService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("~/Views/Shared/ThreadCommunityCreate.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfirm(CreateCommunityModel createCommunityModel)
        {
            var thumbnailPhotoUrl = await this.UploadPhoto(createCommunityModel.ThumbnailPhoto);
            var bannerPhotoUrl = await this.UploadPhoto(createCommunityModel.BannerPhoto);

            await this.ZooWebCommunityService.CreateAsync(new ZooWebCommunityServiceModel
            {
                Name = createCommunityModel.Name,
                Description = createCommunityModel.Description,
                Tags = createCommunityModel.Tags.Select(tag => new ZooWebTagServiceModel { Label = tag }).ToList(),
                ThumbnailPhoto = new AttachmentServiceModel { CloudUrl = thumbnailPhotoUrl },
                BannerPhoto = new AttachmentServiceModel { CloudUrl = bannerPhotoUrl }
            });

            // TODO: Redirect to Community Page
            return Redirect("/");
        }

        private async Task<string> UploadPhoto(IFormFile photo)
        {
            var uploadResponse = await this.cloudinaryService.UploadFile(photo);

            if (uploadResponse == null)
            {
                return null;
            }

            return uploadResponse["url"].ToString();
        }
    }
}
