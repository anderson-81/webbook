<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebBook.Registration.Authors.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Title -->
    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <h3>Author</h3>
            <h1>DETAILS</h1>
        </div>
    </div>
    <!-- Title -->

    <!-- Details -->
    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-md-offset-2 col-md-3">
            <div class="form-group">
                <asp:Label CssClass="control-label lbl-field" runat="server" Text="Artistic Name"></asp:Label><br />
                <asp:Label CssClass="control-label lbl-data-artisticname" ID="lblArtisticName" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="col-md-9">
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="control-label lbl-field" Text="Name"></asp:Label><br />
                        <asp:Label ID="lblNameDet" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="control-label lbl-field" Text="E-mail"></asp:Label><br />
                        <asp:Label ID="lblEmailDet" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="control-label lbl-field" Text="Birthday"></asp:Label><br />
                        <asp:Label ID="lblBirthdayDet" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="control-label lbl-field" Text="Gender"></asp:Label><br />
                        <asp:Label ID="lblGenderDet" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-5">
            <div class="form-group">
                <asp:Image ID="imgPictureDetail" CssClass="border-img pull-right img-details" runat="server" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-offset-2 col-md-8">
            <div class="form-group">
                <asp:Label runat="server" CssClass="control-label lbl-field" Text="Biography"></asp:Label><br />
                <asp:Label ID="lblBiographyDet" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <!-- Details -->

    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <div class="form-group">
                <asp:HyperLink ID="hplnkEditDet" CssClass="btn btn-warning col-md-2 pull-right" runat="server" Text="Edit" />
                <asp:HyperLink ID="hplnkRetDet" CssClass="btn btn-default col-md-2 pull-right" runat="server" NavigateUrl="~/Registration/Authors/Index.aspx" Text="Return" TabIndex="1" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <h3>BOOKS</h3>
            <div runat="server" id="divGridViewBooksAuthor" visible="false">
                <asp:UpdatePanel ID="upGridBook" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gridViewBooksAuthor" AutoGenerateColumns="False" Width="100%" Visible="False" runat="server" AllowPaging="True" OnPageIndexChanging="gridViewBooksAuthor_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Title" HeaderText="Title" />
                                <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                                <asp:BoundField DataField="ISBN" HtmlEncode="False" DataFormatString="<a target='_blank' href='../../Registration/Books/Details.aspx?ISBN={0}'><img class='details-ico' src='../../Content/images/details-ico.png'></a>">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="form-group">
                <%if (Request.IsAuthenticated)
                  { %>
                <asp:HyperLink ID="hplnkCreateBook" runat="server" CssClass="btn btn-success pull-right col-md-2 mg-5" Text="Create" TabIndex="2" />
                <%} %>
            </div>
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

        .lbl-data-artisticname {
            font-size: 22px;
            font-weight: bold;
        }

        .img-details {
            width: 200px;
            height: 200px;
        }
    </style>
</asp:Content>
