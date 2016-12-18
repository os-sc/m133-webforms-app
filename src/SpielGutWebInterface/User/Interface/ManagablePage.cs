using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SpielGutWebInterface.Domain.Manager;
using SpielGutWebInterface.Models;

namespace SpielGutWebInterface.User.Interface
{
    public class ManagablePage : Page 
    {
        protected UserManager<ApplicationUser> UserManager { get; private set; }
        protected RentalManager RentalManager { get; private set; }
        protected ToyManager ToyManager { get; private set; }
        protected ApplicationUser CurrentUser { get; set; }

        protected virtual bool CheckUserData => true;

        public ManagablePage()
        {
            if (!User.Identity.IsAuthenticated) HttpContext.Current.Response.Redirect("/Account/Login.aspx");

            UserManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(
                    new ApplicationDbContext()
                )
            );

            CurrentUser = UserManager.FindById(
                User.Identity.GetUserId()
                );
            ToyManager = new ToyManager(
                Server.MapPath("~/Content/Toys.xdb")
                );
            RentalManager = new RentalManager(
                Server.MapPath("~/Content/Rentals.xdb")
                );

            if(!AreDetailesSet(CurrentUser))
                HttpContext.Current.Response.Redirect("/User/Details.aspx");

        }

        protected bool AreDetailesSet(ApplicationUser user)
        {
            if (!CheckUserData) return true;

            if (string.IsNullOrWhiteSpace(user.FullName))
                return false;
            if (string.IsNullOrWhiteSpace(user.Address))
                return false;
            return !string.IsNullOrWhiteSpace(user.Phone);
        }

    }
}