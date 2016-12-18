using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SpielGutWebInterface.Models;

namespace SpielGutWebInterface.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Diese Option aktivieren, nachdem Sie die Kontobestätigung für die Funktion zum Zurücksetzen des Kennworts aktiviert haben
            ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!string.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (!IsValid) return;
            // Benutzerkennwort überprüfen
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            // Require the user to have a confirmed email before they can log on.
            var user = manager.FindByName(Email.Text);
            if (user == null) return;
            if (!user.EmailConfirmed)
            {
                FailureText.Text = "Invalid login attempt. You must have a confirmed email address. Enter your email and password, then press 'Resend Confirmation'.";
                ErrorMessage.Visible = true;
                ResendConfirm.Visible = true;
            }
            else
            {

                // Anmeldefehler werden bezüglich einer Kontosperre nicht gezählt.
                // Wenn Sie aktivieren möchten, dass Kennwortfehler eine Sperre auslösen, ändern Sie in "shouldLockout: true".
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(string.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                            Request.QueryString["ReturnUrl"],
                            RememberMe.Checked),
                            true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid Credentials.";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }

        protected void SendEmailConfirmationToken(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Email.Text);
            if (user == null) return;
            if (user.EmailConfirmed) return;
            var code = manager.GenerateEmailConfirmationToken(user.Id);
            var callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

            FailureText.Text = "Confirmation email sent. Please view the email and confirm your account.";
            ErrorMessage.Visible = true;
            ResendConfirm.Visible = false;
        }

    }
}