using FullStack.API.Helpers;
using FullStack.Data;
using FullStack.Data.Entities;
using FullStack.ViewModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.API.Services
{
    public interface IProvinceService
    {
        IEnumerable<ProvinceModel> GetAll();
        ProvinceModel GetById(int id);
    }
    public class ProvinceService : IProvinceService
    {
        private readonly IFullStackRepository _repo;
        private readonly AppSettings _appSettings;
        public ProvinceService(IFullStackRepository repo, IOptions<AppSettings> appSettings)
        {
            this._repo = repo;
            this._appSettings = appSettings.Value;

        }
        public IEnumerable<ProvinceModel> GetAll()
        {
            var proviceList = _repo.GetProvinces();
            return proviceList.Select(p => Map(p));
        }

        public ProvinceModel GetById(int id)
        {
            var provinceEntity = _repo.GetProvince(id);
            if (provinceEntity == null) return null;
            return Map(provinceEntity);
        }

        // Helper methods
        private ProvinceModel Map(Province provice)
        {
            return new ProvinceModel
            {
                Id = provice.Id,
                Name = provice.Name
            };
        }
    }
}
