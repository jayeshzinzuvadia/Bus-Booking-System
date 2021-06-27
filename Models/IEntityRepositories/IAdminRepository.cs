using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.Models.IEntityRepositories
{
    public interface IAdminRepository
    {
        Admin Add(Admin admin);
        Admin Update(Admin adminChanges);
        bool Delete(string adminUserId);
        Admin GetAdmin(string adminUserId);
        IEnumerable<Admin> GetAdminList();
    }
}
