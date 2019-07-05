<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebBook.Registration.Authors.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Title -->
    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <h3>Author</h3>
            <h1>SEARCH</h1>
        </div>
    </div>
    <!-- Title -->

    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <hr />
        </div>
    </div>

    <!-- Input -->
    <div class="row">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <div class="input-group">
                <asp:TextBox ID="txtData" runat="server" CssClass="form-control"></asp:TextBox><br />
                <span class="input-group-btn">
                    <asp:Button ID="btnSearch" CssClass="btn btn-info" runat="server" Text="Search" OnClick="btnSearch_Click" TabIndex="1" /><br />
                </span>
            </div>
        </div>
    </div>
    <!-- Input -->

    <!-- Grid -->
    <div class="row pad-5">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <asp:UpdatePanel ID="upGridPersonAuthor" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gridAuthors" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" PageSize="10" AllowPaging="True" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gridAuthors_PageIndexChanging" Font-Size="Medium">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="ArtisticName" HeaderText="Artistic Name" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Birthday" HeaderText="Birthday" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Id" HtmlEncode="False" DataFormatString="<a target='_blank' href='Details.aspx?Id={0}'><img class='details-ico' src='../../Content/images/details-ico.png'></a>" >
                            <HeaderStyle HorizontalAlign="Center" />
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
    </div>
    <!-- Grid -->

    <!-- Create -->
    <div class="row pad-5">
        <div class="col-md-offset-2 col-md-8 col-md-offset-2">
            <div class="form-group">
                <%if (Request.IsAuthenticated)
                  { %>
                <asp:LinkButton ID="lnkCreate" CssClass="btn btn-success col-md-2 pull-right" PostBackUrl="~/Registration/Authors/Create.aspx" runat="server">Create</asp:LinkButton>
                <%} %>
            </div>
        </div>
    </div>
    <!-- Create -->


    <style>
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

        #MainContent_btnSearch {
            border: 1px solid black;
            border-radius: 4px;
            border-top-left-radius: 0px;
            border-bottom-left-radius: 0px;
        }

        .pad-5 {
            padding-top: 3%;
        }

        .details-ico {
            width: 20px;
            height: 20px;
        }
    </style>

    <script>
        $("#MainContent_txtData").attr("placeholder", "Search for...");
    </script>

</asp:Content>
