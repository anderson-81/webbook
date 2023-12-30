<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WebBook.Registration.Authors.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- DATETIMEPICKER BOOTSTRAP -->
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/moment-with-locales.min.js"></script>
    <script type="text/javascript" src="../../Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../Scripts/bootstrap-datetimepicker.min.js"></script>
    <link rel="stylesheet" href="../../Content/bootstrap.min.css" />
    <link rel="stylesheet" href="../../Content/bootstrap-datetimepicker.min.css" />
    <!-- DATETIMEPICKER BOOTSTRAP -->

    <!-- Validation -->
    <asp:RequiredFieldValidator ID="rfName" runat="server" ErrorMessage="Name is empty." ControlToValidate="txtName" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfArtisticName" runat="server" ErrorMessage="Artistic Name is empty." ControlToValidate="txtArtisticName" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfEmail" runat="server" ErrorMessage="E-mail is empty." ControlToValidate="txtEmail" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfBirthday" runat="server" ErrorMessage="Birthday is empty." ControlToValidate="txtBiography" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfGender" runat="server" ErrorMessage="Gender is empty." ControlToValidate="dpGender" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfBiography" runat="server" ErrorMessage="Biography is empty." ControlToValidate="txtBiography" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="reEmail" runat="server" ErrorMessage="Invalid E-mail." ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
    <asp:CustomValidator ID="cvEmailreg" runat="server" ErrorMessage="E-mail already registered." ControlToValidate="txtEmail" OnServerValidate="ValidateEmailRegistered" Display="None"></asp:CustomValidator>
    <asp:CustomValidator ID="cvBirthday" runat="server" ErrorMessage="Invalid birthday." ControlToValidate="txtBirthday" OnServerValidate="ValidateBirthday" Display="None"></asp:CustomValidator>
    <asp:CustomValidator ID="cvGender" runat="server" ErrorMessage="Invalid gender." ControlToValidate="dpGender" OnServerValidate="ValidateGender" Display="None"></asp:CustomValidator>
    <!-- Validation -->

    <!-- Title -->
    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <h3>Author</h3>
            <h1>EDIT</h1>
        </div>
    </div>
    <!-- Title -->

    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <hr />
        </div>
    </div>

    <!-- Errors -->
    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please check the errors:" CssClass="valsum" />
        </div>
    </div>
    <!-- Errors -->

    <!-- Registration -->
    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <div class="form-group">
                <asp:Label ID="lblName" CssClass="control-label" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="txtName" CssClass="form-control" runat="server" MaxLength="45"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblArtisticName" CssClass="control-label" runat="server" Text="Artistic Name"></asp:Label>
                <asp:TextBox ID="txtArtisticName" CssClass="form-control" runat="server" MaxLength="45" TabIndex="1"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblEmail" CssClass="control-label" runat="server" Text="E-mail"></asp:Label><br />
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" MaxLength="45" TabIndex="2"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblBirthday" CssClass="control-label" runat="server" Text="Birthday"></asp:Label><br />
                <div class="input-group date" id="dtpBirthday">
                    <input type="text" id="txtBirthday" class="form-control" runat="server" maxlength="10" tabindex="3" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblGender" CssClass="control-label" runat="server" Text="Gender"></asp:Label>
                <asp:DropDownList ID="dpGender" runat="server" CssClass="form-control" TabIndex="4">
                    <asp:ListItem Selected="True" Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPicture" CssClass="control-label" runat="server" Text="Picture"></asp:Label>
                <%--<asp:HyperLink ID="hpCurrentImage" CssClass="pull-right" runat="server" Text="Current Image" TabIndex="9" />--%>
                <asp:Image ID="imgPicture" Name="imgPicture" runat="server" CssClass="imgPicture pull-right" />
                <asp:FileUpload ID="upPictureAuthor" CssClass="form-control" runat="server" TabIndex="5" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblBiography" CssClass="control-label" runat="server" Text="Biography"></asp:Label><br />
                <asp:TextBox ID="txtBiography" CssClass="form-control" Style="resize: none;" runat="server" TextMode="MultiLine" Width="100%" MaxLength="5000" TabIndex="6"></asp:TextBox>
            </div>
            <!-- Actions -->
            <% if (Request.IsAuthenticated)
               { %>
            <div class="form-group">
                <button type="button" class="btn btn-warning col-md-2 pull-right" data-toggle="modal" data-target="#modalEdit" tabindex="7">Edit</button>
                <button type="button" class="btn btn-danger col-md-2 pull-right" data-toggle="modal" data-target="#modalDelete" tabindex="8">Delete</button>
                <asp:HyperLink ID="hplnkRetDet" CssClass="btn btn-default col-md-2 pull-right" runat="server" Text="Return" TabIndex="9" />
            </div>
            <%} %>
            <!-- Actions -->
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
                    <p>Do you want edit this Author?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-info" data-dismiss="modal">No</button>
                    <asp:Button ID="btnEdit" runat="server" Text="Yes" CssClass="btn btn-default  btn-warning" OnClick="btnEdit_Click" />
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
                    <p>Do you want delete this Author?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-info" data-dismiss="modal">No</button>
                    <asp:Button ID="btnDelete" runat="server" Text="Yes" CssClass="btn btn-default btn-danger" OnClick="btnDelete_Click" CausesValidation="False" />
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
    <link href="../../Content/customs/Author/edit.css" rel="stylesheet" />
    <script src="../../Scripts/customs/components/datetimepicker.js"></script>
</asp:Content>
