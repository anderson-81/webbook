<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WebBook.Registration.Books.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="../../Scripts/jquery.maskMoney.js"></script>

    <!-- Validation -->
    <asp:RequiredFieldValidator ID="rfTitle" runat="server" ErrorMessage="Title is empty." ControlToValidate="txtTitle" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfISBN" runat="server" ErrorMessage="ISBN is empty." ControlToValidate="txtISBN" EnableClientScript="False" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfPages" runat="server" ErrorMessage="Page is empty." ControlToValidate="txtPages" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfPrice" runat="server" ErrorMessage="Price is empty." ControlToValidate="txtPrice" Display="None"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="cvISBN" runat="server" OnServerValidate="ValidateISBN" ErrorMessage="Invalid ISBN." Display="None" ControlToValidate="txtISBN"></asp:CustomValidator>
    <asp:CustomValidator ID="cvPages" runat="server" OnServerValidate="ValidatePages" ErrorMessage="Invalid number pages." Display="None" ControlToValidate="txtPages"></asp:CustomValidator>
    <asp:CustomValidator ID="cvPrice" runat="server" OnServerValidate="ValidatePrice" ErrorMessage="Invalid price." Display="None" ControlToValidate="txtPrice"></asp:CustomValidator>
    <!-- Validation -->


    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <h3>Book</h3>
            <h1>EDIT</h1>
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
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="valsum" HeaderText="Errors:" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblTitle" runat="server" CssClass="control-label" Text="Title"></asp:Label>
                <asp:TextBox ID="txtTitle" runat="server" MaxLength="100" TabIndex="0" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblISBN" runat="server" CssClass="control-label" Text="ISBN"></asp:Label>
                <asp:TextBox ID="txtISBN" runat="server" MaxLength="13" TabIndex="1" ReadOnly="true" CssClass="form-control field-readonly" BackColor="Silver"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPages" runat="server" CssClass="control-label" Text="Pages"></asp:Label>
                <asp:TextBox ID="txtPages" runat="server" TextMode="Number" min="1" CssClass="form-control" AutoPostBack="true" MaxLength="6" TabIndex="2" OnTextChanged="txtPages_TextChanged"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPrice" runat="server" CssClass="control-label" Text="Price"></asp:Label>
                <asp:TextBox ID="txtPrice" CssClass="currency form-control" runat="server" MaxLength="14" TabIndex="3"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPicture" runat="server" CssClass="control-label" Text="Picture"></asp:Label>
                <asp:Image ID="imgPicture" Name="imgPicture" runat="server" CssClass="imgPicture pull-right" />
                <%--<asp:HyperLink ID="hpCurrImage" Name="hpCurrImage" CssClass="pull-right" runat="server" Font-Bold="true" Text="Current Image" TabIndex="9" Target="" />--%>
                <asp:FileUpload ID="upPictBook" CssClass="form-control" runat="server" TabIndex="4" />
            </div>
            <div class="form-group">
                <!-- Actions -->
                <% if (Request.IsAuthenticated){ %>
                <button type="button" class="btn btn-warning col-md-2 pull-right" data-toggle="modal" data-target="#modalEdit" tabindex="7">Edit</button>
                <button type="button" class="btn btn-danger col-md-2 pull-right" data-toggle="modal" data-target="#modalDelete" tabindex="8">Delete</button>
                <asp:HyperLink ID="hplnkRetDet" runat="server" class="btn btn-default col-md-2 pull-right" Text="Return" TabIndex="9" />
                <%} %>
                <!-- Actions -->
            </div>
        </div>
    </div>
    <!-- Registration -->

    <!-- Modals -->
    <div id="modalEdit" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Question</h4>
                </div>
                <div class="modal-body">
                    <p>Do you want edit this Book?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-info" data-dismiss="modal">No</button>
                    <asp:Button ID="btnEdit" runat="server" Text="Yes" UseSubmitBehavior="false" CssClass="btn btn-default btn-warning" OnClick="btnEdit_Click" />
                </div>
            </div>
        </div>
    </div>
    <div id="modalDelete" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Question</h4>
                </div>
                <div class="modal-body">
                    <p>Do you want delete this Book?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-info" data-dismiss="modal">No</button>
                    <asp:Button ID="btnDelete" runat="server" Text="Yes" CausesValidation="false" UseSubmitBehavior="false" CssClass="btn btn-default btn-danger" OnClick="btnDelete_Click" />
                </div>
            </div>
        </div>
    </div>
    <div id="modalMessage" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" id="titleMsg"></h4>
                </div>
                <div class="modal-body">
                    <p id="msgMsg"></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-primary" data-dismiss="modal" id="btnModalMsg">Ok</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modals -->
    <script src="../../Scripts/customs/components/currency.js"></script>
    <script src="../../Scripts/customs/Book/edit.js"></script>
    <link href="../../Content/customs/Book/edit.css" rel="stylesheet" />
</asp:Content>
