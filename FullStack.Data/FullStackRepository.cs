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
    }
}
