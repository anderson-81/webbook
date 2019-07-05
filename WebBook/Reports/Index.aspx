<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebBook.Reports.Index" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <h3>WebBook</h3>
            <h1>REPORT</h1>
        </div>
    </div>

    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <hr />
        </div>
    </div>

     <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
         <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportEmbeddedResource="WebBook.Reports.ReportAuthorBook.rdlc" ReportPath="Reports/ReportAuthorBook.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
        </div>
    </div>
    
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

        hr {
            border: 3px solid black;
        }

        .input-group-addon {
            border: 2px solid black;
        }

        .mg-5 {
            margin-top: 5%;
        }

        .details-ico {
            width: 20px;
            height: 20px;
        }

        .border-img {
            border: 3px solid black;
            border-radius: 5px;
        }

        .lbl-field {
            font-size: 14px;
            font-weight: bold;
        }

        .lbl-data-title {
            font-size: 22px;
            font-weight: bold;
        }
        
        .img-details{
            width:200px;
            height:200px;
        }

    </style>
    
    
</asp:Content>
