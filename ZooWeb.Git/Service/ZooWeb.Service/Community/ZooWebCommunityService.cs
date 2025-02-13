using ZooWeb.Data.Models;
using ZooWeb.Data.Repositories;
using ZooWeb.Service.Mappings;
using ZooWeb.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace ZooWeb.Service.Community
{
    public class ZooWebCommunityService : IZooWebCommunityService
    {
        private readonly ZooWebCommunityRepository ZooWebCommunityRepository;

        private readonly ZooWebTagRepository ZooWebTagRepository;

        public ZooWebCommunityService(
            ZooWebCommunityRepository ZooWebCommunityRepository, 
            ZooWebTagRepository ZooWebTagRepository)
        {
            this.ZooWebCommunityRepository = ZooWebCommunityRepository;
            this.ZooWebTagRepository = ZooWebTagRepository;
        }

        public async Task<ZooWebCommunityServiceModel> CreateAsync(ZooWebCommunityServiceModel model)
        {
            ZooWebCommunity ZooWebCommunity = model.ToEntity();

            ZooWebCommunity.Tags = ZooWebCommunity.Tags.Select(async tag => {
                return (await this.ZooWebTagRepository.CreateAsync(tag));
            }).Select(t => t.Result).ToList();

            await ZooWebCommunityRepository.CreateAsync(ZooWebCommunity);

            return ZooWebCommunity.ToModel();
        }

        public async Task<ZooWebCommunityServiceModel> DeleteAsync(string id)
        {
            ZooWebCommunity category = await ZooWebCommunityRepository.GetAll().SingleOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                throw new NullReferenceException($"No category found with id - {id}.");
            }

            await ZooWebCommunityRepository.DeleteAsync(category);

            return category.ToModel();
        }

        public IQueryable<ZooWebCommunityServiceModel> GetAll()
        {
            return ZooWebCommunityRepository.GetAll()
                .Include(c => c.Tags)
                .Include(c => c.ThumbnailPhoto)
                .Include(c => c.BannerPhoto)
                .Include(c => c.CreatedBy)
                .Include(c => c.UpdatedBy)
                .Include(c => c.DeletedBy)
                .Select(c => c.ToModel());
        }

        public async Task<ZooWebCommunityServiceModel> GetByIdAsync(string id)
        {
            return (await ZooWebCommunityRepository.GetAll()
                .Include(c => c.CreatedBy)
                .Include(c => c.UpdatedBy)
                .Include(c => c.DeletedBy)
                .SingleOrDefaultAsync(c => c.Id == id))?.ToModel();
        }

        public async Task<ZooWebCommunityServiceModel> UpdateAsync(string id, ZooWebCommunityServiceModel model)
        {
            ZooWebCommunity category = await ZooWebCommunityRepository.GetAll().SingleOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                throw new NullReferenceException($"No category found with id - {id}.");
            }

            category.Name = model.Name;
            category.Description = model.Description;
            category.ThumbnailPhoto = model.ThumbnailPhoto != null ? model.ThumbnailPhoto.ToEntity() : category.ThumbnailPhoto;
            category.BannerPhoto = model.BannerPhoto != null ? model.BannerPhoto.ToEntity() : category.BannerPhoto;

            await ZooWebCommunityRepository.UpdateAsync(category);

            return category.ToModel();
        }
    }
}
