<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebBook.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <h2><%: Title %> </h2>
        </div>
    </div>

    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <hr />
        </div>
    </div>

    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <asp:ValidationSummary runat="server" ID="valSum" HeaderText="Erros:" CssClass="valsum" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" Display="None" ErrorMessage="Username is empty." />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" Display="None" ErrorMessage="Password is empty." />
        </div>
    </div>

    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <section id="loginForm">
                <div class="col-md-offset-3 col-md-6 col-md-offset-3">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="control-label">Username</asp:Label>
                        <asp:TextBox runat="server" ID="UserName" CssClass="form-control" Text="Administrator" />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Password</asp:Label>
                        <asp:TextBox runat="server" ID="Password" CssClass="form-control" TextMode="Password" Text="#Administrator01" />
                    </div>
                    <div class="form-group">
                        <asp:Button runat="server" OnClick="LogIn" Text="Login" CssClass="btn btn-success pull-right col-md-4" />
                    </div>
                </div>
            </section>
        </div>
    </div>


    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
    </div>

    <link href="../Content/customs/Account/login.css" rel="stylesheet" />
    <script src="../Scripts/customs/Account/login.js"></script>
</asp:Content>
