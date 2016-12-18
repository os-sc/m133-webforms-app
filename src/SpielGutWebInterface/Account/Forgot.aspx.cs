using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SpielGutWebInterface.Models;

namespace SpielGutWebInterface.Account
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Forgot(object sender, EventArgs e)
        {
            if (!IsValid) return;
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Email.Text);
            if (user == null || !manager.IsEmailConfirmed(user.Id))
            {
                FailureText.Text = "Could not find user.";
                ErrorMessage.Visible = true;
                return;
            }
            var code = manager.GeneratePasswordResetToken(user.Id);
            var callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);
            manager.SendEmail(user.Id, "SpielGut Password Reset", "If you forgot your password and requested a reset, click <a href=\"" + callbackUrl + "\">here</a>, otherwise ignore this message.");
            loginForm.Visible = false;
            DisplayEmail.Visible = true;
        }
    }
}