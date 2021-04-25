<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Asp.Net_Entity_.admin.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
            
     <table class="table table-hover table-borderless mt-5">
                <thead class="thead-dark">
                <tr>
                    <th scope="row" style="width:10px">ID</th>
                    <th scope="col">Başlık</th>
                    <th scope="col">İçerik</th>
                    <th scope="col" >Kategori</th>
                    <th scope="col">Tür</th>
                    <th scope="col">Zaman</th>
                    <th scope="col">Kapak Fotoğrafı</th>
                    <th scope="col">İçerik Fotoğrafları (Slider)</th>
                    <th scope="col"><div class=" px-1 py-0"><asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="~/admin/actionBlog.aspx" CssClass="btn bg-success btn-block text-white" Text="Blog Ekle"></asp:HyperLink></div></th>
                </tr>
                </thead>
                <tbody>
                    <%-- <div class="form-control"><%# Eval("blogCategory") %></div> --%>
  <asp:Repeater ID="Repeater1" runat="server"><ItemTemplate>
                <tr>
                    <th scope="row">
                        <asp:Label ID="Label1" runat="server"  CssClass="p-2" Text='<%# Eval("blogID") %>'></asp:Label>
                    </th>
                    <td><div style="height:auto" class="form-control"><%# Eval("blogTitle") %></div></td>
                    <td><div style="height:250px; overflow: scroll;"class="form-control"><%# Eval("blogContent") %></div></td>
                    <td><div class="form-control"><%# Eval("categoryName") %></div></td>
                    <td><div style="height:auto"class="form-control"><%# Eval("typeName") %></div></td>
                    <td><div style="height:auto"class="form-control"><%# Eval("blogDateTime") %></div></td>
                    <td><div style="width:200px;height:auto; overflow: scroll;"class="form-control"><%# Eval("blogImageCover") %></div></td>
                    <td><div style="width:200px;height:auto; overflow: scroll;"class="form-control"><%# Eval("blogImageCover") %></div></td>
                    <td class="pt-">   
                            <div class="mt-5" style="text-align: center"><asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl='<%#"actionBlog.aspx?blogID="+Eval("blogID")%>' CssClass="btn bg-warning p-3 btn-block text-white" Text="Güncelle"></asp:HyperLink></div>
                            <div class="mt-2" ><asp:HyperLink runat="server" ID="HyperLink2" NavigateUrl='<%#"home.aspx?blogID="+Eval("blogID")%>' CssClass="btn bg-danger btn-block p-3 text-white" Text="Sil"></asp:HyperLink></div>
                    </td>
                </tr>
     </ItemTemplate></asp:Repeater>
                </tbody>
            </table>
</form>
</asp:Content>
