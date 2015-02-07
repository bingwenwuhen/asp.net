<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="BookBorrowSort.aspx.cs" Inherits="miniLib.SortManage.BookBorrowSort" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" style="width: 628px; height: 91px">
        <tr>
      <td height="9" background="../images/index_08.gif"></td>
    </tr>
    <tr>
      <td width="777" height="472"><table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
          <td valign="top"><table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td height="24">&nbsp;</td>
            </tr>
            <tr>
              <td width="756" height="45" background="../images/tu shu pai hang.gif">&nbsp;</td>
            </tr>
            <tr>
              <td height="200" background="../images/tu shu pai hang2.gif">
              <asp:GridView ID="gvBookSort" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" Font-Size="9pt" ForeColor="#333333" HorizontalAlign="Center" Width="678px" OnRowDataBound="gvBookSort_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvBookSort_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="排名" />
                        <asp:BoundField DataField="Id" HeaderText="编号" ReadOnly="True" />
                        <asp:BoundField DataField="BookName" HeaderText="图书名称" />
                        <asp:BoundField DataField="type" HeaderText="图书类型" />
                        <asp:BoundField DataField="BookCase" HeaderText="书架" />
                        <asp:BoundField DataField="PubName" HeaderText="出版社" />
                        <asp:BoundField DataField="Author" HeaderText="作者" />
                        <asp:BoundField DataField="Price" HeaderText="定价" />
                    </Columns>
                    <HeaderStyle BackColor="#DFF5F5" Font-Bold="False" ForeColor="Black" />
                </asp:GridView></td>
            </tr>
            <tr>
              <td height="4" background="../images/tu shu pai hang3.gif"></td>
            </tr>
          </table></td>
        </tr>
      </table></td>
    </table>
</asp:Content>
