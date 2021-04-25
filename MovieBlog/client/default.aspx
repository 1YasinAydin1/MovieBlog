<%@ Page Title="" Language="C#" MasterPageFile="~/client/client.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Asp.Net_Entity_.client.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div class="content-grid">
                <div class="content-grid-info">
                    <div class="post-info">
                        <img src='<%# Eval("blogImageCover") %>' class="w-100 img-rounded" />
                        <div style="position: absolute; right: 5%; top: 40px; width: 20%" class="bg-white pl-3 pt-2">
                            <h4><a href="blogDetail.aspx?blogID=<%# Eval("blogID") %>"><%# Eval("blogTitle") %> </a></h4>
                        </div>
                        <p><%# Eval("blogContent") %></p>
                        <div class="row px-4 pb-4">
                            <div class="col-xs-8"><a href="blogDetail.aspx?blogID=<%# Eval("blogID") %>"><span></span>Devamını Oku...</a></div>
                            <div class="col-xs-4 pr-4">
                                <h4 style="text-align: right"><%# Eval("blogDateTime") %></h4>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
