<%@ Page Title="Your Password Has Been Changed" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="SpielGutWebInterface.Account.ResetPasswordConfirmation" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="content-card bright-background">
        <h1><%: Title %></h1>
        <div>
            <p>Your password has been changed. Click
                <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">here</asp:HyperLink>
                to login. </p>
        </div>
    </div>
</asp:Content>
