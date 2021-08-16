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
    public interface IAdvertService
    {
        IEnumerable<AdvertModel> GetAll(int userId);
        AdvertModel GetById(int id);
        AdvertModel CreateAdvert(int userId, Advert advert);

        AdvertModel UpdateAdvert(int userId, Advert advert);
    }
    public class AdvertService: IAdvertService
    {
        private readonly IFullStackRepository _repo;
        private readonly AppSettings _appSettings;

        public AdvertService(IFullStackRepository repo, IOptions<AppSettings> appSettings)
        {
            this._repo = repo;
            this._appSettings = appSettings.Value;
        }

        public IEnumerable<AdvertModel> GetAll(int userId)
        {
            var advertList = _repo.GetAdverts(userId);
            return advertList.Select(a => Map(a));
        }
        
        public AdvertModel GetById(int id)
        {
            var advertEntity = _repo.GetAdvert(id);
            if (advertEntity == null) return null;
            return Map(advertEntity);
        }
        public AdvertModel CreateAdvert(int userId, Advert advert)
        {
            var advertEntity = _repo.CreateAdvert(userId, advert);
            return Map(advertEntity);
        }

        public AdvertModel UpdateAdvert(int userId, Advert advert)
        {
            var advertEntity = _repo.UpdateAdvert(userId, advert);
            return Map(advertEntity);
        }
        //Helpert methods
        private AdvertModel Map(Advert advert)
        {
            return new AdvertModel
            {
                Id = advert.Id,
                Headline = advert.Headline,
                Province = advert.Province,
                City = advert.City,
                Status = advert.Status,
                AdvertDetails = advert.AdvertDetails,
                Price = advert.Price,
                Deleted = advert.Deleted,
                Hidden = advert.Hidden,
                UserId = advert.UserId
            };
        }

    }
}
