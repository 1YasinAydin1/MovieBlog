<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="actionBlog.aspx.cs" Inherits="Asp.Net_Entity_.admin.actionBlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form id="Form1" runat="server">
        <div class="container my-5">
            <asp:Panel ID="Panel1" CssClass="row col-8" runat="server">
                <div class="bg-dark px-2 pt-2 font-weight-light" style="font-size: smaller; text-align: center; border-bottom-left-radius: 15px; border-top-left-radius: 15px; color: #fff">
                    <asp:Label ID="Label5" runat="server" Text="ID"></asp:Label>
                </div>
                <asp:TextBox ID="IDTextBox" runat="server" ReadOnly="true" CssClass="form-control col-6"></asp:TextBox>
            </asp:Panel>
            <div class="form-group row justify-content-center mx-5 pb-5">

                <div class="col-7 mt-4">
                    <div class="bg-dark font-weight-light" style="font-size: smaller; text-align: center; border-top-left-radius: 15px; border-top-right-radius: 15px; color: #fff">
                        <asp:Label ID="Label9" runat="server" Text="Başlık"></asp:Label>
                    </div>
                    <asp:TextBox ID="blogTitle" Style="font-size: smaller; text-align: center" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="blogTitle"
                        EnableClientScript="False" ErrorMessage="Boş bırakılamaz*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </div>
                <div class="col-9">
                    <div class="bg-dark font-weight-light" style="text-align: center; border-top-left-radius: 15px; border-top-right-radius: 15px; color: #fff">
                        <asp:Label ID="Label1" runat="server" Text="İçerik"></asp:Label>
                    </div>
                    <asp:TextBox ID="blogContent" Style="font-size: smaller; text-align: center;" runat="server" TextMode="MultiLine" Height="200" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="blogContent"
                        EnableClientScript="False" ErrorMessage="Boş bırakılamaz*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </div>
                <div class="col-7  mt-4">
                    <div class="bg-dark font-weight-light" style="font-size: smaller; text-align: center; border-top-left-radius: 15px; border-top-right-radius: 15px; color: #fff">
                        <asp:Label ID="Label2" runat="server" Text="Kategori"></asp:Label>
                    </div>
                    <asp:DropDownList ID="blogCategory" runat="server" CssClass="form-control" DataTextField="categoryName" DataValueField="categoryID"></asp:DropDownList>
                </div>
                <div class="col-7 mt-4">
                    <div class="bg-dark font-weight-light" style="font-size: smaller; text-align: center; border-top-left-radius: 15px; border-top-right-radius: 15px; color: #fff">
                        <asp:Label ID="Label6" runat="server" Text="Tür"></asp:Label>
                    </div>
                    <asp:DropDownList ID="blogType" runat="server" CssClass="form-control" DataTextField="typeName" DataValueField="typeID"></asp:DropDownList>
                </div>
                <div class="col-7  mt-4">
                    <div class="bg-dark font-weight-light col-4" style="font-size: smaller; text-align: center; border-top-left-radius: 15px; border-top-right-radius: 15px; color: #fff">
                        <asp:Label ID="Label3" runat="server" Text="Kapak Fotoğrafı Link"></asp:Label>
                    </div>
                    <asp:TextBox ID="blogCoverImage" Style="font-size: smaller; text-align: center;" runat="server" CssClass="form-control" MaxLength="300"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="blogCoverImage"
                        EnableClientScript="False" ErrorMessage="Boş bırakılamaz*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </div>
                <div class="row col-7 p-0 mt-4">
                    <div class="col-10">
                        <div class="bg-dark font-weight-light col-5" style="font-size: smaller; text-align: center; border-top-left-radius: 15px; border-top-right-radius: 15px; color: #fff">
                            <asp:Label ID="Label4" runat="server" Text="İçerik Fotoğraf Adeti"></asp:Label>
                        </div>
                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <asp:Button ID="bring" runat="server" Text="Ekle" style="width:15%" CssClass="btn mt-4 mb-2 btn-sm bg-primary text-white" OnClick="bring_Click" />
                </div>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <asp:TextBox ID="blogDetailImageTextBox" Style="font-size: smaller; text-align: center;" runat="server" CssClass="form-control col-7 mt-3" MaxLength="300"></asp:TextBox>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <asp:Button ID="action" runat="server" Text="Kaydet" CssClass="btn bg-success btn-block text-white" OnClick="action_Click" />
        </div>
    </form>


</asp:Content>
