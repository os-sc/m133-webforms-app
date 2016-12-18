using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using SpielGutWebInterface.User.Interface;

namespace SpielGutWebInterface.User
{
    public partial class Account : ManagablePage
    {
        protected override bool CheckUserData => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (!CheckDetailsValues()) return;
                CurrentUser.FullName = UserFullName.Text;
                CurrentUser.Address = UserAddress.Text;
                CurrentUser.Phone = UserPhone.Text;
                UserManager.Update(CurrentUser);
            }
            else
            {
                UserFullName.Text = CurrentUser.FullName;
                UserAddress.Text = CurrentUser.Address;
                UserPhone.Text = CurrentUser.Phone;
            }
        }

        protected void UserLogout(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        private bool CheckDetailsValues()
        {
            var res = Regex.Match(UserPhone.Text, "[0-9]").Success;
            if (string.IsNullOrWhiteSpace(UserFullName.Text)) res = false;
            if (string.IsNullOrWhiteSpace(UserAddress.Text)) res = false;
            return res;
        }
    }
}