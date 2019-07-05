<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebBook.Registration.Books.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <script>
        //var lista = null;
        //var param = JSON.stringify({
        //    opcao: 1
        //});
        //$.post('server/execucao.php', param, function (data) {
        //    lista = $.parseJSON(data);
        //    var jp = JSON.parse(JSON.stringify(lista));
        //    var i = 0;
        //    var j = 0;
        //    while (i < jp.length) {
        //        j = 0;
        //        $("#port").append('<div class="row" style="margin-top:30px;display:none;" id="' + i + '"></div>');
        //        while (j < jp[i].length) {
        //            $('#' + i).append('<div class="col-sm-3 portfolio-item"><a href="#' + jp[i][j]['id'] + 'm" class="portfolio-link" data-toggle="modal" style="text-decoration: none;"> <div class="caption"> <div class="caption-content"> <i class="fa fa-search-plus fa-3x"></i> </div> </div> <img src="' + jp[i][j]['image'] + '" class="img-responsive" alt="' + jp[i][j]['title'] + '" style="border:5px solid black;border-radius:7px;"> <div class="portfolio-caption text-center"><h4 style="margin-top:35px;">' + jp[i][j]['title'] + '</h4></div></a></div>');
        //            $("body").append("<div class='portfolio-modal modal fade' id='" + jp[i][j]['id'] + "m' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-content'><div class='close-modal' data-dismiss='modal'><a href='#' data-dismiss='modal' class='lnkTop'><i class='fa fa-times'></i></a></div><div class='container'><div class='row'><div class='col-lg-8 col-lg-offset-2'><div class='modal-body'><h2>" + jp[i][j]['title'] + "</h2><img src='' class='img-responsive img-centered' alt=''><p></p><div class='list-inline item-details' id=conteudo-" + jp[i][j]['id'] + "></div></div></div></div></div></div></div>");
        //            j++;
        //        }
        //        i++;
        //    }
        //});
    </script>


</asp:Content>
