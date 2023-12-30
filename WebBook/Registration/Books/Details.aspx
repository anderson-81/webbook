<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebBook.Registration.Books.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Title -->
    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <h3>Book</h3>
            <h1>DETAILS</h1>
        </div>
    </div>
    <!-- Title -->

    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <hr />
        </div>
    </div>

    <div class="row">
        <div class="col-md-offset-2 col-md-5">
            <div class="form-group">
                <asp:Label runat="server" CssClass="control-label lbl-field" Text="Title"></asp:Label><br />
                <asp:Label ID="lblTitle" CssClass="control-label lbl-data-title" runat="server"></asp:Label><br />
            </div>
            <div class="row">
                <div class="col-md-9">
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="control-label lbl-field" Text="Author"></asp:Label><br />
                        <asp:Label ID="lblArtisticName" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="control-label lbl-field" Text="ISBN"></asp:Label><br />
                        <asp:Label ID="lblISBN" runat="server"></asp:Label><br />
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <asp:Label runat="server"  CssClass="control-label lbl-field" Text="Price"></asp:Label><br />
                        <asp:Label ID="lblPrice" runat="server"></asp:Label><br />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="control-label lbl-field" Text="Pages"></asp:Label><br />
                        <asp:Label ID="lblPage" runat="server"></asp:Label><br />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <asp:Image ID="imgPictureBookDetail" class="pull-right border-img img-details" runat="server" /><br />
            </div>
        </div>
    </div>

    <div class="row mg-5">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <% if (Request.IsAuthenticated)
            { %>
                <asp:HyperLink ID="hplnkEditDet" CssClass="btn btn-warning col-md-2 pull-right" runat="server" Text="Edit" TabIndex="0" />
                <asp:HyperLink ID="hplnkRetDet" CssClass="btn btn-default col-md-2 pull-right" runat="server" Text="Return" TabIndex="1" />
            <%} %>
        </div>
    </div>
    <link href="../../Content/customs/Book/details.css" rel="stylesheet" />
</asp:Content>
