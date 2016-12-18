<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rentals.aspx.cs" Inherits="SpielGutWebInterface.User.Rentals" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="content-card bright-background">
        <h1>New Rental</h1>

        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:Label CssClass="mdl-textfield__label" AssociatedControlID="ToySelection" runat="server">Toy</asp:Label>
            <asp:TextBox list="status-list" CssClass="mdl-textfield__input" type="text" ID="ToySelection" runat="server"></asp:TextBox>
        </div>
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:Label CssClass="mdl-textfield__label" AssociatedControlID="RentalDuration" runat="server">Rental Duration (in weeks)</asp:Label>
            <asp:TextBox class="mdl-textfield__input" type="text" pattern="-?[0-9]*(\.[0-9]+)?" ID="RentalDuration" runat="server"></asp:TextBox>
            <span class="mdl-textfield__error">Input is not a valid number!</span>
        </div>
        <br />
        <input class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" type="submit" value="Rent" />
        <datalist id="status-list">
            <asp:Literal runat="server" ID="RentableOptions"></asp:Literal>
        </datalist>
    </div>
    <div class="content-card bright-background">
        <h1>My Rentals</h1>

        <table class="mdl-data-table mdl-js-data-table full-width">
            <thead>
                <tr>
                    <th class="mdl-data-table__cell--non-numeric">Toy</th>
                    <th>Rental Date</th>
                    <th>Due Return Date</th>
                    <th>Extend</th>
                </tr>
            </thead>
            <tbody>
                <asp:Literal runat="server" ID="RentalTableContents"></asp:Literal>

            </tbody>
        </table>

    </div>
</asp:Content>
