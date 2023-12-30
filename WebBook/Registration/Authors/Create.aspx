<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="WebBook.Registration.Authors.Create" %>

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
    <asp:RequiredFieldValidator ID="rfPicture" runat="server" ErrorMessage="Picture is empty." ControlToValidate="upPictureAuthor" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="reEmail" runat="server" ErrorMessage="Invalid E-mail." ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
    <asp:CustomValidator ID="cvEmailreg" runat="server" ErrorMessage="E-mail already registered." ControlToValidate="txtEmail" OnServerValidate="ValidateEmailRegistered" Display="None"></asp:CustomValidator>
    <asp:CustomValidator ID="cvBirthday" runat="server" ErrorMessage="Invalid birthday." ControlToValidate="txtBirthday" OnServerValidate="ValidateBirthday" Display="None"></asp:CustomValidator>
    <asp:CustomValidator ID="cvGender" runat="server" ErrorMessage="Invalid gender." ControlToValidate="dpGender" OnServerValidate="ValidateGender" Display="None"></asp:CustomValidator>
    <!-- Validation -->

    <!-- Title -->
    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <h3>Author</h3>
            <h1>CREATE</h1>
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
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Please check the errors:" CssClass="valsum" />
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
                <asp:Button Text="Create" CssClass="btn btn-success col-md-2 pull-right" ID="btnCreate" runat="server" OnClick="btnCreate_Click" TabIndex="7" />
                <input type="reset" class="btn btn-info col-md-2 pull-right" name="btnReset" value="Reset" tabindex="8" />
                <asp:HyperLink ID="hplnkRetDet" CssClass="btn btn-default col-md-2 pull-right" runat="server" NavigateUrl="~/Registration/Authors/Index.aspx" Text="Return" TabIndex="9" />
            </div>
            <%} %>
            <!-- Actions -->
        </div>
    </div>
    <!-- Registration -->
    <link href="../../Content/customs/Author/create.css" rel="stylesheet" />
    <script src="../../Scripts/customs/components/datetimepicker.js"></script>
</asp:Content>
