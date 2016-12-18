using System;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNet.Identity;
using SpielGutWebInterface.User.Interface;

namespace SpielGutWebInterface.User
{
    public partial class Details : ManagablePage
    {
        protected override bool CheckUserData => false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack || !CheckDetailsValues()) return;
            CurrentUser.FullName = UserFullName.Text;
            CurrentUser.Address = UserAddress.Text;
            CurrentUser.Phone = UserPhone.Text;
            UserManager.Update(CurrentUser);
            HttpContext.Current.Response.Redirect("/Default.aspx");
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