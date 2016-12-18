<%@ Page Title="Password Reset" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="SpielGutWebInterface.Account.ResetPassword" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="content-card bright-background">
        <h1>Password Reset</h1>
        <p class="warning-text">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        
        
        <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
            CssClass="warning-text" Display="Dynamic" ErrorMessage="The password fields do not match is required." />

        <asp:ValidationSummary runat="server" CssClass="warning-text" />
        <br />

        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
        <asp:Label runat="server" AssociatedControlID="Email" CssClass="mdl-textfield__label">E-Mail</asp:Label>
        <asp:TextBox runat="server" ID="Email" CssClass="mdl-textfield__input" TextMode="Email" />
        </div>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
            CssClass="warning-text" ErrorMessage="The E-Mail field is required." />
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
        <asp:Label runat="server" AssociatedControlID="Password" CssClass="mdl-textfield__label">Password</asp:Label>
        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="mdl-textfield__input" />
        </div>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
            CssClass="warning-text" ErrorMessage="The password field is required." />
        <br />
        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
        <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="mdl-textfield__label">Confirm Password</asp:Label>
        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="mdl-textfield__input" />
        </div>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
            CssClass="warning-text" Display="Dynamic" ErrorMessage="The confirm password field is required." />
        <br />
        <asp:Button runat="server" OnClick="Reset_Click" Text="Zurücksetzen" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" />

    </div>
</asp:Content>
