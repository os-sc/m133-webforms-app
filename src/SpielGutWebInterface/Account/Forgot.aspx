<%@ Page Title="Password Reset" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="SpielGutWebInterface.Account.ForgotPassword" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="content-card bright-background">
        <asp:PlaceHolder ID="loginForm" runat="server">
            <h1>Password Reset</h1>

            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="warning-text">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>
            
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                CssClass="text-danger" ErrorMessage="The E-Mail field is required." />
            <br />
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <asp:Label runat="server" AssociatedControlID="Email" CssClass="mdl-textfield__label">E-Mail</asp:Label>
                <asp:TextBox runat="server" ID="Email" CssClass="mdl-textfield__input" TextMode="Email" />
            </div>
            <br />
            <asp:Button runat="server" OnClick="Forgot" Text="E-Mail-Link" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" />
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="false">
            <p>
                Please check your mail.
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
