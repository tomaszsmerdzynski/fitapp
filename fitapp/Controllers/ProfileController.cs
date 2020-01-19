using fitapp.App_Start;
using fitapp.Models;
using fitapp.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace fitapp.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: Profile
        public enum ManageMessageId
        { 
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSucces,
            LinkSucces,
            Error
        }

        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }

            //if (User.IsInRole("Admin"))
            //    ViewBag.UserIsAdmin = true;
            //else
            //    ViewBag.UserIsAdmin = false;

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null)
            {
                return View("Error");
            }

            var model = new ProfileCredentialsViewModel()
            {
                Message = message,
                //HasPassword = this.HasPassword(),
                UserData = user.UserData
                
            };

            //model.UserData.CPM = CalculateCpm(model.UserData);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProfile([Bind(Prefix = "UserData")] UserData userData)
        {
            //var genders = new SelectList(
            //    new List<SelectListItem>
            //    {
            //        new SelectListItem { Selected = true, Text = "Kobieta", Value = "Female" },
            //        new SelectListItem { Selected = false, Text = "Mężczyzna", Value = "Male" }
            //    }, "Text", "Value");
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.UserData = userData;
                user.UserData.BMI = CalculateBmi(user.UserData);
                user.UserData.BMR = CalculateBmr(user.UserData);
                user.UserData.CPM = CalculateCpm(user.UserData);
                var result = await UserManager.UpdateAsync(user);

                AddErrors(result);
            }

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        //private bool HasPassword()
        //{
        //    var user = UserManager.FindById(User.Identity.GetUserId());
        //    if (user != null)
        //    {
        //        return user.PasswordHash != null;
        //    }
        //    return false;
        //}

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("password-error", error);
            }
        }
        public double CalculateBmi(UserData userData)
        {
            return Math.Round(userData.Weight / Math.Pow((userData.Height / 100), 2), 2);
        }

        public double CalculateCpm(UserData userData)
        {

            if (userData.PhysicalActivity == null)
            {
                return 0;
            }
            else
            {
                string a = userData.PhysicalActivity;
                double pActivity = Convert.ToDouble(a);

                if (userData.Gender == "Female")
                {
                    return Math.Round(((665 + (9.6 * userData.Weight) + (1.8 * userData.Height) - (4.7 * userData.Age)) * pActivity), 2);
                }
                else
                {
                    return Math.Round(((66 + (13.7 * userData.Weight) + (5 * userData.Height) - (6.76 * userData.Age)) * pActivity), 2);
                }
            }
        }

        public double CalculateBmr(UserData userData)
        {
            if (userData.PhysicalActivity == null)
            {
                return 0;
            }
            else
            {
                if (userData.Gender == "Female")
                {
                    return Math.Round((665 + (9.6 * userData.Weight) + (1.8 * userData.Height) - (4.7 * userData.Age)), 2);
                }
                else
                {
                    return Math.Round((66 + (13.7 * userData.Weight) + (5 * userData.Height) - (6.76 * userData.Age)), 2);
                }
            }
        }
    }
}