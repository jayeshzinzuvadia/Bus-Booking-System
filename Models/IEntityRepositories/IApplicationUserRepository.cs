using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.Models.IEntityRepositories
{
    public interface IApplicationUserRepository
    {
        ApplicationUser Add(ApplicationUser user);
        ApplicationUser Update(ApplicationUser userChanges);
        ApplicationUser GetApplicationUser(string userId);
        ApplicationUser GetApplicationUserFromEmail(string email);
        List<ApplicationUser> GetApplicationUserListOfType(string userType);
        bool Delete(string userId);
    }
}
