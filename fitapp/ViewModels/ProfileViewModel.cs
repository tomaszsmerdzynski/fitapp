using fitapp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fitapp.ViewModels
{
    public class ProfileCredentialsViewModel
    {
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
        public fitapp.Controllers.ProfileController.ManageMessageId? Message { get; set; }
        public UserData UserData { get; set; }

        //public bool HasPassword { get; set; }
        //public SetPasswordViewModel SetPasswordViewModel { get; set; }
        //public IList<UserLoginInfo> CurrentLogins { get; set; }
        //public IList<AuthenticationDescription> OtherLogins { get; set; }
        //public bool ShowRemoveButton { get; set; }
    }

    //public class SetPasswordViewModel
    //{

    //}

    public class ChangePasswordViewModel
    {

    }
}