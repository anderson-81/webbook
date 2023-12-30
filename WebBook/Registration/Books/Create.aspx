<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="WebBook.Registration.Books.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="../../Scripts/jquery.maskMoney.js"></script>

    <!-- Validation -->
    <asp:RequiredFieldValidator ID="rfTitle" runat="server" ErrorMessage="Title is empty." ControlToValidate="txtTitle" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfISBN" runat="server" ErrorMessage="ISBN is empty." EnableClientScript="False" ControlToValidate="txtISBN" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfPages" runat="server" ErrorMessage="Page is empty." ControlToValidate="txtPages" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfPrice" runat="server" ErrorMessage="Price is empty." ControlToValidate="txtPrice" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfPicture" runat="server" ErrorMessage="Picture is empty." ControlToValidate="upPictBook" Display="None"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="cvISBN" runat="server" OnServerValidate="ValidateISBN" ErrorMessage="Invalid ISBN." Display="None" ControlToValidate="txtISBN"></asp:CustomValidator>
    <asp:CustomValidator ID="cvPages" runat="server" OnServerValidate="ValidatePages" ErrorMessage="Invalid number pages." Display="None" ControlToValidate="txtPages"></asp:CustomValidator>
    <asp:CustomValidator ID="cvPrice" runat="server" OnServerValidate="ValidatePrice" ErrorMessage="Invalid price." Display="None" ControlToValidate="txtPrice"></asp:CustomValidator>
    <!-- Validation -->

    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <h3>Book</h3>
            <h1>CREATE</h1>
        </div>
    </div>

    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <hr />
        </div>
    </div>

    <!-- Registration -->
    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <div class="form-group">
                <asp:Label ID="lblAuthorID" CssClass="control-label" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="txtAuthorID" CssClass="form-control field-readonly" runat="server" ReadOnly="true" BackColor="Silver"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblArtisticName" runat="server" CssClass="control-label" Text="Artistic Name"></asp:Label>
                <asp:TextBox ID="txtArtisticName" runat="server" ReadOnly="true" CssClass="form-control field-readonly" BackColor="Silver"></asp:TextBox>
            </div>
            <div class="form-group">
                <hr />
            </div>
            <div class="form-group">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="valsum" HeaderText="Errors:" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblTitle" runat="server" CssClass="control-label" Text="Title"></asp:Label>
                <asp:TextBox ID="txtTitle" runat="server" MaxLength="45" TabIndex="0" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblISBN" runat="server" CssClass="control-label" Text="ISBN"></asp:Label>
                <asp:TextBox ID="txtISBN" runat="server" MaxLength="14" TabIndex="1" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPages" runat="server" CssClass="control-label" Text="Pages"></asp:Label>
                <asp:TextBox ID="txtPages" runat="server" CssClass="form-control" AutoPostBack="true" MaxLength="5" TabIndex="2" OnTextChanged="txtPages_TextChanged"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPrice" runat="server" CssClass="control-label" Text="Price"></asp:Label>
                <asp:TextBox ID="txtPrice" CssClass="currency form-control" runat="server" MaxLength="15" TabIndex="3"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPicture" runat="server" CssClass="control-label" Text="Picture"></asp:Label>
                <asp:FileUpload ID="upPictBook" CssClass="form-control" runat="server" TabIndex="4" />
            </div>
            <div class="form-group">
                <!-- Actions -->
                <% if (Request.IsAuthenticated)
                   { %>
                <asp:Button ID="btnInsert" runat="server" CssClass="btn btn-success pull-right col-md-2" Text="Insert" OnClick="btnInsert_Click" TabIndex="5" />
                <button type="button" class="btn btn-info pull-right col-md-2" onclick="Reset();">Clear</button>
                <asp:HyperLink ID="hpRetCreateBook" CssClass="btn btn-default pull-right col-md-2" runat="server">Return</asp:HyperLink>
                <%} %>
                <!-- Actions -->
            </div>
        </div>
    </div>
    <!-- Registration -->
    <script src="../../Scripts/customs/components/currency.js"></script>
    <link href="../../Content/customs/Book/create.css" rel="stylesheet" />
    <script src="../../Scripts/customs/Book/create.js"></script>
</asp:Content>
