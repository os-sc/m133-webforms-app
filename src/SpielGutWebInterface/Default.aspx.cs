using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SpielGutWebInterface.Models;

namespace SpielGutWebInterface
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated) return;
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = um.FindById(User.Identity.GetUserId());
            MainTitleLabel.Text = string.IsNullOrWhiteSpace(user.FullName) ? "Welcome!" : "Welcome back, " + user.FullName;
            MainTextLabel.Text = "Please choose where to go next in the menu.";
        }
    }
}