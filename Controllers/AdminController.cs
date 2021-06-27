using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusBookingSystem.Models;
using BusBookingSystem.Models.Entities;
using BusBookingSystem.Models.IEntityRepositories;
using BusBookingSystem.Utilities;
using BusBookingSystem.ViewModels.Admin;

namespace BusBookingSystem.Controllers
{
    [Authorize(Roles = AppConstant.ADMIN)]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IPassengerRepository passengerRepository;
        private readonly IBusOperatorRepository busOperatorRepository;
        private readonly IAdminRepository adminRepository;
        private readonly IBusRepository busRepository;
        private readonly IBusRouteRepository busRouteRepository;
        private readonly IApplicationUserRepository applicationUserRepository;
        private readonly ISeatRepository seatRepository;
        private readonly ITicketRepository ticketRepository;

        public AdminController(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IPassengerRepository passengerRepository,
            IBusOperatorRepository busOperatorRepository,
            IAdminRepository adminRepository,
            IBusRepository busRepository,
            IBusRouteRepository busRouteRepository,
            IApplicationUserRepository applicationUserRepository,
            ISeatRepository seatRepository,
            ITicketRepository ticketRepository)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.passengerRepository = passengerRepository;
            this.busOperatorRepository = busOperatorRepository;
            this.adminRepository = adminRepository;
            this.busRepository = busRepository;
            this.busRouteRepository = busRouteRepository;
            this.applicationUserRepository = applicationUserRepository;
            this.seatRepository = seatRepository;
            this.ticketRepository = ticketRepository;
        }

        //Manage Bus methods
        [HttpGet]
        public IActionResult ViewBusList()
        {
            var busList = busRepository.GetAllBuses();
            ViewBag.TotalNoOfBus = busList.Count();
            List<BusListViewModel> viewModel = new List<BusListViewModel>();
            foreach (Bus bus in busList)
            {
                BusOperator busOperator = busOperatorRepository.GetBusOperator(bus.BusOperatorId);
                var model = new BusListViewModel
                {
                    Bus = bus,
                    BusOperatorName = (busOperator == null) ? "Vacancy" : busOperator.DisplayName
                };
                viewModel.Add(model);
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddNewBus()
        {
            var freeBusOperatorsList = busRepository.GetAvailableBusOperators();
            ViewBag.AvailBusOperatorUserList = new SelectList(freeBusOperatorsList, "Id", "DisplayName");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewBus(Bus model)
        {
            if (ModelState.IsValid)
            {
                model.Ratings = "3.7";
                busRepository.Add(model);
                return RedirectToAction("ViewBusList", AppConstant.ADMIN);
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateBus(string busId)
        {
            var model = busRepository.GetBus(Convert.ToInt32(busId));
            var freeBusOperatorsList = busRepository.GetAvailableBusOperators();
            var busOperatorObj = busOperatorRepository.GetBusOperator(model.BusOperatorId);
            if(busOperatorObj != null)
            {
                ViewBag.BusOperatorId = busOperatorObj.Id;
                ViewBag.BusOperatorName = busOperatorObj.DisplayName;                
            }
            else
            {
                ViewBag.BusOperatorId = "";
                ViewBag.BusOperatorName = "Please Select";
            }
            ViewBag.AvailBusOperatorUserList = new SelectList(freeBusOperatorsList, "Id", "DisplayName");
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateBus(Bus model)
        {
            if (ModelState.IsValid)
            {
                busRepository.Update(model);                
                return RedirectToAction("ViewBusList", AppConstant.ADMIN);
            }
            return View();
        }

        [HttpPost]
        public IActionResult RemoveBus(int busId)
        {
            Bus bus = busRepository.GetBus(busId);
            if (bus != null)
            {
                ////Remove from BusRoute
                //List<BusRoute> busRouteList = busRouteRepository.GetAllBusRoutesByBusId(bus.BusId).ToList();
                //if (busRouteList != null)
                //{
                //    foreach (BusRoute busRoute in busRouteList)
                //    {
                //        busRouteRepository.DeleteBusRoute(busRoute.BusRouteId);
                //    }
                //}                
                //Remove from Bus
                busRepository.Delete(bus.BusId);
            }
            return RedirectToAction("ViewBusList", AppConstant.ADMIN);
        }

        [HttpGet]
        public IActionResult ViewBusRouteList(int busId)
        {
            Bus bus = busRepository.GetBus(busId);
            BusOperator busOperator = busOperatorRepository.GetBusOperator(bus.BusOperatorId);
            List<BusRoute> busRouteList = busRouteRepository.GetAllBusRoutesByBusId(busId);
            ViewBag.TotalNoOfBusRoutes = busRouteList.Count();
            var model = new BusRouteListViewModel()
            {
                Bus = bus,
                BusRouteList = busRouteList,
                BusOperatorName = (busOperator == null) ? "Vacancy" : busOperator.DisplayName
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNewBusRoute(int busId)
        {
            var bus = busRepository.GetBus(busId);
            ViewBag.BusName = bus.BusName;
            ViewBag.RouteSequence = bus.RouteSequence;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewBusRoute(BusRoute model, int busId)
        {
            if (ModelState.IsValid && busId != 0)
            {
                model.BusId = busId;
                busRouteRepository.AddBusRoute(model);
                return RedirectToAction("ViewBusRouteList", AppConstant.ADMIN, new { busId = model.BusId });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateBusRoute(int busRouteId, int busId)
        {
            var bus = busRepository.GetBus(busId);
            ViewBag.BusName = bus.BusName;
            ViewBag.RouteSequence = bus.RouteSequence;
            var model = busRouteRepository.GetBusRoute(busRouteId);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateBusRoute(BusRoute model)
        {
            if (ModelState.IsValid)
            {
                busRouteRepository.UpdateBusRoute(model);
                return RedirectToAction("ViewBusRouteList", AppConstant.ADMIN, new { busId = model.BusId });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult RemoveBusRoute(int busRouteId)
        {
            //Remove from BusRoute
            BusRoute busRoute = busRouteRepository.GetBusRoute(busRouteId);
            if (busRoute != null)
            {
                busRouteRepository.DeleteBusRoute(busRoute.BusRouteId);
                return RedirectToAction("ViewBusRouteList", AppConstant.ADMIN, new { busId = busRoute.BusId });
            }
            return View();
        }

        //Manage Users methods
        [HttpGet]
        public IActionResult ViewUserList(string userType)
        {
            if(userType == null)
            {
                userType = AppConstant.BUS_OPERATOR;
            }
            var model = new UserListViewModel {
                UserType = userType,
                ApplicationUserList = applicationUserRepository.GetApplicationUserListOfType(userType),
            };
            ViewBag.TotalUsers = model.ApplicationUserList.Count;
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNewUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(AddNewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Store user information in ApplicationUser table
                ApplicationUser applicationUser = FillUserDetails(model);

                //Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(applicationUser, model.Password);

                //If user is successfully created, then
                if (result.Succeeded)
                {
                    if (applicationUser.UserType == AppConstant.BUS_OPERATOR)
                    {
                        await userManager.AddToRoleAsync(applicationUser, AppConstant.BUS_OPERATOR);
                    }
                    else if (applicationUser.UserType == AppConstant.ADMIN)
                    {
                        await userManager.AddToRoleAsync(applicationUser, AppConstant.ADMIN);
                    }
                    return RedirectToAction("ViewUserList", AppConstant.ADMIN);
                }
                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        public ApplicationUser FillUserDetails(AddNewUserViewModel model)
        {
            if (model.UserType == AppConstant.BUS_OPERATOR)
            {
                BusOperator busOperator = new BusOperator
                {
                    UserType = AppConstant.BUS_OPERATOR,
                    DisplayName = model.FirstName + " " + model.LastName,
                    Gender = model.Gender,
                    Email = model.Email,
                    UserName = model.Email,
                    DateOfBirth = model.DateOfBirth,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Salary = model.Salary,
                    DateOfJoining = model.DateOfJoining,
                };
                return busOperator;
            }
            else if (model.UserType == AppConstant.ADMIN)
            {
                Admin adminUser = new Admin
                {
                    UserType = AppConstant.ADMIN,
                    DisplayName = model.FirstName + " " + model.LastName,
                    Gender = model.Gender,
                    Email = model.Email,
                    UserName = model.Email,
                    DateOfBirth = model.DateOfBirth,
                    PhoneNumber = model.PhoneNumber,
                };
                return adminUser;
            }
            return null;
        }

        [HttpGet]
        public IActionResult UserDetails(string Id)
        {
            ApplicationUser model = applicationUserRepository.GetApplicationUser(Id);
            var viewModel = new UserDetailsViewModel
            {
                User = model,
                Email = model.Email,
                Age = DateUtility.DateDifferenceFromToday(model.DateOfBirth),
            };
            if (model.UserType == AppConstant.BUS_OPERATOR)
            {
                var busOperatorModel = busOperatorRepository.GetBusOperator(model.Id);
                viewModel.Address = busOperatorModel.Address;
                viewModel.Salary = busOperatorModel.Salary;
                viewModel.Experience = DateUtility.DateDifferenceFromToday(busOperatorModel.DateOfJoining);
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult UpdateUser(string Id)
        {
            var model = applicationUserRepository.GetApplicationUser(Id);
            var name = model.DisplayName.Split();
            string lastName = "";
            if (name.Length > 1)
            {
                lastName = name[1];
            }
            var viewModel = new UpdateUserViewModel
            {
                FirstName = name[0],
                LastName = lastName,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,
                DateOfBirth = model.DateOfBirth,
                UserType = model.UserType,
                UpdateUserId = Id,
            };
            if (model.UserType == AppConstant.BUS_OPERATOR)
            {
                var busOperatorModel = busOperatorRepository.GetBusOperator(Id);
                viewModel.Address = busOperatorModel.Address;
                viewModel.Salary = busOperatorModel.Salary;
                viewModel.DateOfJoining = busOperatorModel.DateOfJoining;
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = model.UpdateUserId;
                if (model.UserType == AppConstant.PASSENGER || model.UserType == AppConstant.ADMIN)
                {
                    ApplicationUser user = applicationUserRepository.GetApplicationUser(userId);
                    if (user != null)
                    {
                        user.DisplayName = model.FirstName + " " + model.LastName;
                        user.Gender = model.Gender;
                        user.DateOfBirth = model.DateOfBirth;
                        user.PhoneNumber = model.PhoneNumber;
                        //applicationUserRepository.Update(user);
                        await userManager.UpdateAsync(user);
                    }
                }
                else if (model.UserType == AppConstant.BUS_OPERATOR)
                {
                    BusOperator busOperator = busOperatorRepository.GetBusOperator(userId);
                    if (busOperator != null)
                    {
                        busOperator.DisplayName = model.FirstName + " " + model.LastName;
                        busOperator.Gender = model.Gender;
                        busOperator.DateOfBirth = model.DateOfBirth;
                        busOperator.PhoneNumber = model.PhoneNumber;
                        busOperator.Address = model.Address;
                        busOperator.Salary = model.Salary;
                        busOperator.DateOfJoining = model.DateOfJoining;
                        // Both the methods are working fine
                        //busOperatorRepository.Update(busOperator);
                        await userManager.UpdateAsync(busOperator);
                    }
                }
                return RedirectToAction("ViewUserList", AppConstant.ADMIN);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUser(string Id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"ApplicationUser with userId = {Id} cannot be found";
                return View("RoleNotFound");
            }
            //Removing from AspNetUserRoles
            await userManager.RemoveFromRoleAsync(user, user.UserType);
            //Removing from AspNetUsers
            await userManager.DeleteAsync(user);
            return RedirectToAction("ViewUserList", AppConstant.ADMIN);
        }

        // Manage Role Methods for MASTER user
        [HttpGet]
        [Authorize(Roles = AppConstant.MASTER)]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = AppConstant.MASTER)]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {                    
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", AppConstant.ADMIN);
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AppConstant.MASTER)]
        public async Task<IActionResult> DeleteRole(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"ApplicationUser with userId = {Id} cannot be found";
                return View("RoleNotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", AppConstant.ADMIN);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("ListRoles");
            }
        }

        [HttpGet]
        [Authorize(Roles = AppConstant.MASTER)]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        [Authorize(Roles = AppConstant.MASTER)]
        public async Task<IActionResult> EditRole(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {Id} cannot be found";
                return View("RoleNotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.DisplayName);
                }
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AppConstant.MASTER)]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("RoleNotFound");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = AppConstant.MASTER)]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;
            var role = await roleManager.FindByIdAsync(roleId);
            ViewBag.roleName = role.Name;
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("RoleNotFound");
            }

            var model = new List<UserRoleViewModel>();
            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    DisplayName = user.DisplayName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }
                model.Add(userRoleViewModel);
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AppConstant.MASTER)]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("RoleNotFound");
            }
            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);
                IdentityResult result;
                //If user is selected and is not a member of AspNetRoles table
                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!(model[i].IsSelected) && (await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", new { Id = roleId });
                    }
                }
            }
            return RedirectToAction("EditRole", new { Id = roleId });
        }
    }
}
