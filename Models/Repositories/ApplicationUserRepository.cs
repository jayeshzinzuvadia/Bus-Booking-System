using BusBookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using BusBookingSystem.Models.IEntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusBookingSystem.Models.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly AppDbContext context;
        public ApplicationUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public ApplicationUser Add(ApplicationUser user)
        {
            context.ApplicationUser.Add(user);
            context.SaveChanges();
            return user;
        }

        public bool Delete(string userId)
        {
            ApplicationUser user = context.ApplicationUser.Find(userId);
            if (user != null)
            {
                context.ApplicationUser.Remove(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public ApplicationUser GetApplicationUser(string userId)
        {
            return context.ApplicationUser.Find(userId);            
        }

        public ApplicationUser GetApplicationUserFromEmail(string email)
        {
            ApplicationUser applicationUser = context.ApplicationUser.FirstOrDefault(usr => usr.NormalizedEmail == email.ToUpper());
            if (applicationUser != null)
            {
                return context.ApplicationUser.Find(applicationUser.Id);
            }
            return null;
        }

        public List<ApplicationUser> GetApplicationUserListOfType(string userType)
        {
            return context.ApplicationUser.ToList().FindAll(user => user.UserType == userType);
        }

        public ApplicationUser Update(ApplicationUser userChanges)
        {
            var user = context.ApplicationUser.Attach(userChanges);
            user.State = EntityState.Modified;
            context.SaveChanges();
            return userChanges;
        }
    }
}
