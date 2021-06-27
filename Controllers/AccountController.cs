using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BusBookingSystem.Models.Entities;
using BusBookingSystem.Models.IEntityRepositories;
using BusBookingSystem.ViewModels.Account;
using BusBookingSystem.Models;

namespace BusBookingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;        
        private readonly IApplicationUserRepository applicationUserRepository;

        public AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            IApplicationUserRepository applicationUserRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.applicationUserRepository = applicationUserRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to ApplicationUser
                var applicationUser = new ApplicationUser
                {
                    UserType = AppConstant.PASSENGER,
                    UserName = model.Email,
                    DisplayName = model.FirstName + " " + model.LastName,
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirth,
                    PhoneNumber = model.PhoneNumber.ToString(),
                    Email = model.Email,
                };
                //applicationUser = applicationUserRepository.Add(applicationUser);
                //Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(applicationUser, model.Password);

                //If user is successfully created, user is signed in using SignInManager
                //Redirect to Home action of PassengerController
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(applicationUser, AppConstant.PASSENGER);
                    await signInManager.SignInAsync(applicationUser, isPersistent: false);
                    return RedirectToAction("Home", AppConstant.PASSENGER);
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    //Obtaining userType from UserRepository class 
                    ApplicationUser user = applicationUserRepository.GetApplicationUserFromEmail(model.Email);
                    if (user.UserType == AppConstant.PASSENGER)
                    {
                        return RedirectToAction("Home", AppConstant.PASSENGER);
                    }
                    else if(user.UserType == AppConstant.BUS_OPERATOR)
                    {
                        return RedirectToAction("ViewBookingList", AppConstant.BUSOPERATOR_CONTROLLER);
                    }
                    else if(user.UserType == AppConstant.ADMIN)
                    {
                        return RedirectToAction("ViewBusList", AppConstant.ADMIN);
                    }
                }
                ModelState.AddModelError(string.Empty, "Incorrect Email address or Password");
            }
            // Adding this so as to avoid losing login with google button
            model.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            model.ReturnUrl = "";
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl ??= Url.Content("~/");
            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View("Login", loginViewModel);
            }

            //Information about user is provided by external login provider
            var info = await signInManager.GetExternalLoginInfoAsync();
            //If information is not present
            if (info == null)
            {
                ModelState.AddModelError(String.Empty, "Error loading external login information");
                return View("Login", loginViewModel);
            }

            //Obtaining userType from ApplicationUserRepository class 
            var user = applicationUserRepository.GetApplicationUserFromEmail(info.Principal.FindFirstValue(ClaimTypes.Email));
            if (user != null)
            {
                string userType = user.UserType;
                if (userType == AppConstant.PASSENGER)
                {
                    returnUrl = Url.Content("~/Passenger/Home");
                }
                else if (userType == AppConstant.BUS_OPERATOR)
                {
                    returnUrl = Url.Content("~/BusOperator/ViewBookingList");
                }
                else if (userType == AppConstant.ADMIN)
                {
                    returnUrl = Url.Content("~/Admin/ViewBusList");
                }
            }
            //If user is already present in system i.e. row is present in AspNetUserLogins table and AspNetUsers table
            var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                //If user have local account i.e. row in AspNetUsers table 
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                //If user's email is given by external login provider
                if (email != null)
                {
                    //Find user by email in AspNetUsers table
                    var appUser = await userManager.FindByEmailAsync(email);
                    //If user do not have local account, add it into database
                    if (appUser == null)
                    {
                        //Add user information into User table
                        appUser = new Passenger
                        {
                            UserType = AppConstant.PASSENGER,
                            DisplayName = info.Principal.Identity.Name,
                            Email = email,
                            UserName = email,
                            DateOfBirth = Convert.ToDateTime("01-01-1990"),
                        };
                        await userManager.CreateAsync(appUser);
                        await userManager.AddToRoleAsync(appUser, AppConstant.PASSENGER);
                    }
                    //Add row in AspNetUserLogins table assuming user have local account
                    await userManager.AddLoginAsync(appUser, info);
                    await signInManager.SignInAsync(appUser, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                //If email is not provided
                ViewBag.ErrorTitle = $"Email claim not received from : {info.LoginProvider}";
                ViewBag.ErrorMessage = "Please contact support on help@support.com";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Home", "Passenger");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        //MyProfile methods
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyProfile(string userName)
        {
            var appUser = await userManager.FindByNameAsync(userName);
            var model = applicationUserRepository.GetApplicationUser(appUser.Id);
            ViewBag.UserName = userName;
            return View(model);
        }
    }
}