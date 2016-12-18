using System;
using SpielGutWebInterface.User.Interface;

namespace SpielGutWebInterface.api
{
    public partial class ExtendRental : ManagablePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "text/plain";
                if (string.IsNullOrWhiteSpace(Request.QueryString["rid"]))
                {
                    Response.StatusCode = 400;
                    return;
                }

                RentalManager.Extend(Request.QueryString["rid"], 1);
                Response.StatusCode = 200;
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
            }
        }
    }
}
