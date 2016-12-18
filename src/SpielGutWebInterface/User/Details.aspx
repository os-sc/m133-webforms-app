<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="SpielGutWebInterface.User.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-card bright-background">
        <h1>Personal Details</h1>
        <p>
            Before you can continue, you need to enter some personal details.
        </p>
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:Label runat="server" Text="Full Name" AssociatedControlID="UserFullName" CssClass="mdl-textfield__label"></asp:Label>
            <asp:TextBox runat="server" ID="UserFullName" CssClass="mdl-textfield__input"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserFullName" ErrorMessage="Name is required" CssClass="warning-text"></asp:RequiredFieldValidator>
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:Label runat="server" Text="Address" AssociatedControlID="UserAddress" CssClass="mdl-textfield__label"></asp:Label>
            <asp:TextBox runat="server" ID="UserAddress" CssClass="mdl-textfield__input"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserAddress" ErrorMessage="Address is required" CssClass="warning-text"></asp:RequiredFieldValidator>
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <asp:Label runat="server" Text="Phone" AssociatedControlID="UserPhone" CssClass="mdl-textfield__label"></asp:Label>
            <asp:TextBox runat="server" ID="UserPhone" CssClass="mdl-textfield__input"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserPhone" ErrorMessage="Phone number is required" CssClass="warning-text"></asp:RequiredFieldValidator>
        <br />
        <input class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" type="submit" value="Save" />
    </div>
</asp:Content>
