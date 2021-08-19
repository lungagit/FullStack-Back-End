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
    public interface ICityService
    {
        IEnumerable<CityModel> GetCities(int provinceId);
    }
    
    public class CityService: ICityService
    {
        private readonly IFullStackRepository _repo;
        private readonly AppSettings _appSettings;
        public CityService(IFullStackRepository repo, IOptions<AppSettings> appSettings)
        {
            this._repo = repo;
            this._appSettings = appSettings.Value;
        }

        public IEnumerable<CityModel> GetCities(int provinceId)
        {
            var cityList = _repo.GetCities(provinceId);
            return cityList.Select(c => Map(c));
        }

        //Helper method
        private CityModel Map(City city)
        {
            return new CityModel
            {
                Id = city.Id,
                Name = city.Name,
            };

        }
    }
    
}
