using ZooWeb.Data.Models;
using ZooWeb.Data.Repositories;
using ZooWeb.Service.Mappings;
using ZooWeb.Service.Models;

namespace ZooWeb.Service.Tag
{
    public class ZooWebTagService : IZooWebTagService
    {
        private readonly ZooWebTagRepository ZooWebTagRepository;

        public ZooWebTagService(ZooWebTagRepository ZooWebTagRepository)
        {
            this.ZooWebTagRepository = ZooWebTagRepository;
        }

        public async Task<ZooWebTagServiceModel> CreateAsync(ZooWebTagServiceModel model)
        {
            return (await this.ZooWebTagRepository.CreateAsync(model.ToEntity())).ToModel();
        }

        public async Task<ZooWebTag> InternalCreateAsync(ZooWebTag entity)
        {
            return await this.ZooWebTagRepository.CreateAsync(entity);
        }

        public Task<ZooWebTagServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ZooWebTagServiceModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ZooWebTagServiceModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ZooWebTagServiceModel> UpdateAsync(string id, ZooWebTagServiceModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ZooWebTag> InternalGetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
