using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FullStack.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Data
{
    public interface IFullStackRepository
    {
        User GetUser(int id);
        List<User> GetUsers();
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(int id);

        Advert GetAdvert(int id);
        IEnumerable<Advert> GetAdverts(int userId);
        Advert CreateAdvert(int userId, Advert advert);
        Advert UpdateAdvert(int userId, Advert advert);
        void DeleteAdvert(int id);

        List<Province> GetProvinces();
        Province GetProvince(int id);
        IEnumerable<City> GetCities(int provinceId);



    }
    public class FullStackRepository: IFullStackRepository
    {
        private readonly FullStackDbContext _ctx;
 
        public FullStackRepository(FullStackDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<User> GetUsers()
        {
            //throw new NotImplementedException();
            return _ctx.Users.ToList();
        }

        public User GetUser(int id)
        {
            //throw new NotImplementedException();
            return _ctx.Users.Find(id);
        }

        public User CreateUser(User user)
        {
            //throw new NotImplementedException();
            
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            //throw new NotImplementedException();

            var existing = _ctx.Users.SingleOrDefault(em => em.Id == user.Id);
            if (existing == null) return null;

            _ctx.Entry(existing).State = EntityState.Detached;
            _ctx.Users.Attach(user);
            _ctx.Entry(user).State = EntityState.Modified;
            _ctx.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            //throw new NotImplementedException();

            var entity = _ctx.Users.Find(id);
            _ctx.Users.Remove(entity);
            _ctx.SaveChanges();
        }

        public IEnumerable<Advert> GetAdverts(int userId) 
        {
            //throw new NotImplementedException();

            if (userId == 0) return _ctx.Adverts.ToList();
            else return _ctx.Adverts.Where(a => a.UserId == userId);

        }
        public Advert GetAdvert(int id) 
        {
            //throw new NotImplementedException();

            return _ctx.Adverts.Find(id);
        }
        public Advert CreateAdvert(int userId, Advert advert) 
        {
            //throw new NotImplementedException();
            // always set the UserId to the passed-in userId

            advert.UserId = userId;
            _ctx.Adverts.Add(advert);
            _ctx.SaveChanges();
            return advert;
        }
        public Advert UpdateAdvert(int userId, Advert advert)
        {
            //throw new NotImplementedException();

            var existing = _ctx.Adverts.SingleOrDefault(em => em.Id == advert.Id);
            if (existing == null) return null;
            if (userId != advert.UserId) return null;

            _ctx.Entry(existing).State = EntityState.Detached;
            _ctx.Adverts.Attach(advert);
            _ctx.Entry(advert).State = EntityState.Modified;
            _ctx.SaveChanges();
            return advert;

        }
        public void DeleteAdvert(int id)
        {
            //throw new NotImplementedException();

            var entity = _ctx.Adverts.Find(id);
            _ctx.Adverts.Remove(entity);
            _ctx.SaveChanges();
        }

        public List<Province> GetProvinces()
        {
            //throw new NotImplementedException();
            return _ctx.Provinces.ToList();
        }

        public Province GetProvince(int id)
        {
            //throw new NotImplementedException();
            return _ctx.Provinces.Find(id);
        }
       
        public IEnumerable<City> GetCities(int provinceId)
        {
            //throw new NotImplementedException();
            if(provinceId == 0) return _ctx.Cities.ToList();
            else return _ctx.Cities.Where(p => p.ProvinceId == provinceId);

        }
    }
}
