<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SpielGutWebInterface.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="content-card bright-background">
    <h1>Registration</h1>
        
    <p class="warning-text">
        <asp:Literal runat="server" ID="ErrorMessage" />
        <asp:ValidationSummary runat="server" CssClass="warning-text" />
    </p>

    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
        <asp:Label runat="server" AssociatedControlID="Email" CssClass="mdl-textfield__label">E-Mail</asp:Label>
        <asp:TextBox runat="server" ID="Email" CssClass="mdl-textfield__input" TextMode="Email" />
    </div>
    <br />
    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
        <asp:Label runat="server" AssociatedControlID="Password" CssClass="mdl-textfield__label">Password</asp:Label>
        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="mdl-textfield__input" />
    </div>
    <br />
    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
        <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="mdl-textfield__label">Confirm Password</asp:Label>
        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="mdl-textfield__input" />
    </div>
    <br />

    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" />
    <!--
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="The email field is required." />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="The password confirm field is required." />
        <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="The passwords do not match." />
    -->
    </div>
</asp:Content>
