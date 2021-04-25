<%@ Page Title="" Language="C#" MasterPageFile="~/client/client.Master" AutoEventWireup="true" CodeBehind="blogDetail.aspx.cs" Inherits="Asp.Net_Entity_.client.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="col-sm-12 single-main">
            <div class="single-grid">

                <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
                    <div class="carousel-inner">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <div class="carousel-item active">
                                    <img src='<%# Eval("blogImageCover") %>' alt="Second slide">
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="carousel-item">
                                    <img src='<%# Eval("blogImagePath") %>' alt="Second slide">
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>

                <asp:Repeater ID="Repeater3" runat="server">
                    <ItemTemplate>
                        <div class="blogDetailTitle mt-5"><%# Eval("blogTitle") %></div>
                        <p><%# Eval("blogContent") %></p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <ul class="comment-list">
                <h5 class="post-author_head">Yazar : <a href="#" title="admin" rel="author">admin</a></h5>
                <li>
                    <img src="clientTheme/images/avatar.png" class="imgAdmin img-responsive" alt="">
                    <div class="desc">
                        <p>Tüm gönderiler için : <a href="default.aspx" title="Tüm gönderiler" rel="author">admin</a></p>
                    </div>
                    <div class="clearfix"></div>
                </li>
            </ul>

            <div class="content-form">
                <h3>Yorum Gönder</h3>
                <form runat="server">
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="İsim"></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Email"></asp:TextBox>
                    <asp:TextBox ID="TextBox3" runat="server" placeholder="Yorum yazın..."></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Gönder" OnClick="Button1_Click" />
                </form>
            </div>

            <ul class="comment-list">
                <asp:Repeater ID="Repeater4" runat="server">
                    <ItemTemplate>
                        <li>
                            <img src="clientTheme/images/avatar.png" class="imgComment img-responsive" alt="">
                            <h5 class="post-author_head"><%# Eval("commentName") %></h5>
                            <p class="post-author_head font-weight-light"><%# Eval("commentEmail") %></p>
                            <p class="blogCommentContent font-weight-light mt-4"><%# Eval("commentContent") %></p>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>

</asp:Content>
