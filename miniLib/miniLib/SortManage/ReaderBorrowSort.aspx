<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="ReaderBorrowSort.aspx.cs" Inherits="miniLib.SortManage.ReaderBorrowSort" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" style="width: 628px; height: 91px">
        <tr>
      <td height="9" background="../images/index_08.gif"></td>
    </tr>
    <tr>
      <td width="777" height="472">
            <table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td height="4"></td>
              </tr>
              <tr>
                <td width="756" height="45" background="../images/zu zhe pai hang.gif">&nbsp;</td>
              </tr>
              <tr>
                <td height="200" background="../images/tu shu pai hang2.gif"><asp:GridView ID="gvReaderSort" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" Font-Size="9pt" ForeColor="#333333" HorizontalAlign="Center" Width="678px" OnRowDataBound="gvReaderSort_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvReaderSort_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="排名" />
                        <asp:BoundField DataField="Id" HeaderText="读者编号" />
                        <asp:BoundField DataField="LoginName" HeaderText="读者姓名" />
                        <asp:BoundField DataField="UserRoleId" HeaderText="读者类型" />
                        <asp:BoundField DataField="CardNumber" HeaderText="证件号码" />
                        <asp:BoundField DataField="Phone" HeaderText="电话" />
                        <asp:BoundField DataField="Gender" HeaderText="性别" />
                        <asp:BoundField DataField="BorrowSum" HeaderText="借阅次数" />
                    </Columns>
                    <HeaderStyle BackColor="#DFF5F5" Font-Bold="False" ForeColor="Black" />
                </asp:GridView></td>
              </tr>
              <tr>
                <td height="4" background="../images/tu shu pai hang3.gif"></td>
              </tr>
            </table></td>
        </tr>
      </table>
</asp:Content>
