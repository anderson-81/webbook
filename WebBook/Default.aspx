<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebBook._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron mg-5">
        <h1>WebBook</h1>
        <p class="lead">Prototype of a book and authors registration system made in ASP.NET (C#)(WebForm), and SQL Server database.</p>
    </div>
    
    <style>
        body {
            background: url("../../Content/images/wall.jpg") no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }

        .jumbotron{
            background: url("../../Content/images/black.jpg");
            color:white;
            border:3px solid white;
        }

        .mg-5{
            margin-top:5%;
        }

        hr{
           border:3px solid white;
        }

        .date{
            color:white;
            font-weight:bold;
        }
    </style>

</asp:Content>

