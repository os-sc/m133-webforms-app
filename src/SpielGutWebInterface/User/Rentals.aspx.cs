using System;
using System.Web.UI.WebControls;
using SpielGutWebInterface.Domain.Entity;
using SpielGutWebInterface.User.Interface;

namespace SpielGutWebInterface.User
{
    public partial class Rentals : ManagablePage
    {
        protected override bool CheckUserData => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateRentalTable();
            PopulateRentableToys();
            if (IsPostBack) RegisterNewRental();
        }

        private void RegisterNewRental()
        {
            var toy = ToyManager.GetByName(ToySelection.Text);
            int weeks;
            if (!int.TryParse(RentalDuration.Text, out weeks)) return;
            RentalManager.AddNewRental(CurrentUser.Email, toy, weeks);
            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }

        private void PopulateRentalTable()
        {
            RentalTableContents.Text = "";
            var rentals = Domain.Manager.RentalManager.OrderByDueDate(RentalManager.GetRentalsByUser(CurrentUser.Email));
            foreach (var rental in rentals)
            {
                AddRentalRow(rental);
            }
        }

        private void PopulateRentableToys()
        {
            RentableOptions.Text = "";
            var inRent = RentalManager.GetAllActive();
            var toys = ToyManager.GetAll();
            foreach (var rental in inRent)
                toys.Remove(ToyManager.GetById(rental.Toy));

            foreach (var toy in toys)
                RentableOptions.Text += "<option value=\"" + toy.Name + "\">" + toy.Id + "<option>";
        }

        private void AddRentalRow(Rental r)
        {
            var t = ToyManager.GetById(r.Toy);
            RentalTableContents.Text += FillTemplate(r, t, Rental.IsActive(r));
        }

        private static string FillTemplate(Rental r, Toy t, bool active)
        {
            var template = "<tr><td class=\"mdl-data-table__cell--non-numeric\"><span class=\"bold\">%ToyManufacturer%</span> %ToyName%</td><td>%StartDate%</td><td>%DueDate%</td><td><button type=\"Button\" class=\"mdl-button mdl-js-button mdl-button--icon mdl-button--colored %hidden%\" OnClick=\"ExtendRental('%RentalId%');\"><i class=\"material-icons\">add</i></button></td></tr>";
            template = active ? template.Replace("%hidden%", "") : template.Replace("%hidden%", "hidden");
            return template
                .Replace("%RentalId%", r.Id)
                .Replace("%ToyManufacturer%", t.Manufacturer)
                .Replace("%ToyName%", t.Name)
                .Replace("%StartDate%", r.StartDate.ToShortDateString())
                .Replace("%DueDate%", r.DueReturnDate.ToShortDateString());
        }
    }
}