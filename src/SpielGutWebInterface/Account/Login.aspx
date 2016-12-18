<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SpielGutWebInterface.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="content-card bright-background">
        <h1>Login</h1>

        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="warning-text">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>

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
        
        <asp:Button runat="server" OnClick="LogIn" Text="Login" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" />
        <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
        <br />

        <!--
                    <asp:CheckBox runat="server" ID="RememberMe" />
                    <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me</asp:Label>
                    <asp:Button runat="server" ID="ResendConfirm" OnClick="SendEmailConfirmationToken" Text="Resend confirmation" Visible="false" CssClass="btn btn-default" />
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Als neuer Benutzer registrieren</asp:HyperLink>
                    <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
                    -->

    </div>
</asp:Content>
