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
                        <asp:TextBox runat="server" ID="UserName" CssClass="form-control" Text="AndersonBook" ReadOnly="true" />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Password</asp:Label>
                        <asp:TextBox runat="server" ID="Password" CssClass="form-control" TextMode="Password" ReadOnly="true" Text="" />
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

    <script type="text/javascript">
        $("#MainContent_Password").val("AndersonBook81");
    </script>

    <style>
        .valsum {
            background-color: #FFFF99;
            color: red;
            border: 3px solid red;
            border-radius: 7px;
            font-weight: bold;
        }

        body {
            background-color: #babfff;
        }

        .control-label {
            font-weight: bold;
        }

        .form-control {
            border: 2px solid black;
        }

        hr {
            border: 3px solid black;
        }

        .input-group-addon {
            border: 2px solid black;
        }
    </style>

</asp:Content>
