<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="miniLib.BookDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:DetailsView ID="BookDetailsView" runat="server" AutoGenerateRows="False" Height="50px">
        <Fields>
            <asp:BoundField DataField="BookName" HeaderText="书名" SortExpression="BookName" />
            <asp:ImageField DataImageUrlField="ISBN" DataImageUrlFormatString="~/images/bookcovers/{0}.jpg" HeaderText="封面">
            </asp:ImageField>
            <asp:BoundField DataField="Author" HeaderText="作者简介" SortExpression="Author" />
            <asp:TemplateField HeaderText="单价" SortExpression="Price">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Price") %>'></asp:Label>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ContentDescription" HeaderText="内容介绍" SortExpression="ContentDescription" />
            <asp:BoundField DataField="TOC" HeaderText="目录" htmlEncode="false" SortExpression="TOC" />
        </Fields>
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <EditRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    </asp:DetailsView>
    </asp:Content>
