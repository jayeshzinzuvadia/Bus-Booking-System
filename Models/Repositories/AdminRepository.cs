using Microsoft.EntityFrameworkCore;
using BusBookingSystem.Models.Entities;
using BusBookingSystem.Models.IEntityRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusBookingSystem.Models.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext context;
        public AdminRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Admin Add(Admin admin)
        {
            context.Admin.Add(admin);
            context.SaveChanges();
            return admin;
        }

        public bool Delete(string adminUserId)
        {
            Admin user = GetAdmin(adminUserId);
            if (user != null)
            {
                context.ApplicationUser.Remove(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Admin GetAdmin(string adminUserId)
        {
            return context.Admin.Find(adminUserId);
        }

        public IEnumerable<Admin> GetAdminList()
        {
            return context.Admin;
        }

        public Admin Update(Admin adminChanges)
        {
            var administrator = context.Admin.Attach(adminChanges);
            administrator.State = EntityState.Modified;
            context.SaveChanges();
            return adminChanges;
        }
    }
}
