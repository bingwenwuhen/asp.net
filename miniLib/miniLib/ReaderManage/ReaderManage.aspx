<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="ReaderManage.aspx.cs" Inherits="miniLib.ReaderManage.ReaderManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
          <td valign="top" style="width: 903px"><table border="0" align="center" cellpadding="0" cellspacing="0" style="width: 919px">
            <tr>
              <td height="24" align="right" class="daohang1" style="width: 812px">&nbsp;</td>
            </tr>
            <tr>
              <td height="22" background="../images/tu shu pai hang2.gif" style="width: 812px"><table height="77" border="0" align="right" cellpadding="0" cellspacing="0" style="width: 914px">
                <tr>
                  <td colspan="5" align="right" background="../images/danganguanli.gif" style="height: 44px; background-image: url(../images/duzhedanganguanli.gif);">&nbsp;</td>
                  </tr>
                <tr>
                  <td height="32" align="right" style="width: 580px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <img src="../images/tianjia tubiao.gif" width="19" height="18"><asp:HyperLink ID="hpLinkAddReader" runat="server" NavigateUrl="~/ReaderManage/AddReader.aspx" ForeColor="Black">添加读者信息</asp:HyperLink></td>
                  <td width="150" align="right" class="daohang1">&nbsp;</td>
                  <td width="45">&nbsp;</td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="23" background="../images/tu shu pai hang2.gif" style="width: 1000px">
                  <asp:GridView ID="gvReaderInfo" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" PageSize="5" AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvReaderInfo_PageIndexChanging" OnRowDeleting="gvReaderInfo_RowDeleting"  Width="825px" HorizontalAlign="Center" Height="243px">
                    <HeaderStyle BackColor="#DFF5F5" Font-Bold="False" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="读者编号" ReadOnly="True" />
                        <asp:BoundField DataField="LoginName" HeaderText="姓名" />
                        <asp:BoundField DataField="Address" HeaderText="住址" />
                        <asp:BoundField DataField="Phone" HeaderText="电话" />
                        <asp:BoundField DataField="Mail" HeaderText="Email" />
                        <asp:BoundField DataField="Gender" HeaderText="性别" />
                        <asp:BoundField DataField="UserRoleId" HeaderText="级别" />
                        <asp:HyperLinkField DataNavigateUrlFormatString="AddReader.aspx?readerid={0}" HeaderText="详情"
                            Text="详情" DataNavigateUrlFields="id" >
                            <ControlStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            <HeaderStyle ForeColor="Black" />
                        </asp:HyperLinkField>
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
                <p style="width: 641px">&nbsp;</p></td>
            </tr>
            <tr>
              <td height="4" valign="top" background="../images/tu shu pai hang3.gif" style="width: 812px"></td>
            </tr>
            
          </table>
            </td>
        </tr>
      </table>
</asp:Content>
