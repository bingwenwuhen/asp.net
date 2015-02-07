<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="BookManage.aspx.cs" Inherits="miniLib.BookManage.BookManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
          <td valign="top"><table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="756" height="24" align="right" class="daohang1">&nbsp;</td>
            </tr>
            <tr>
              <td height="22" background="../images/tu shu pai hang2.gif"><table width="756" height="77" border="0" align="right" cellpadding="0" cellspacing="0">
                <tr>
                  <td height="45" colspan="3" align="right" background="../images/danganguanli.gif">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="622" height="32" align="right"><img src="../images/tianjia tubiao.gif" width="19" height="18"></td>
                  <td width="89" align="right" class="daohang1"><asp:HyperLink ID="hpLinkAddBook" runat="server" NavigateUrl="~/BookManage/AddBook.aspx" ForeColor="Black">添加图书信息</asp:HyperLink></td>
                  <td width="45">&nbsp;</td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="23" background="../images/tu shu pai hang2.gif"><asp:GridView ID="gvBookInfo" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvBookInfo_PageIndexChanging" OnRowDeleting="gvBookInfo_RowDeleting"  Width="732px" HorizontalAlign="Center">
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DFF5F5" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
                        <asp:BoundField DataField="ISBN" HeaderText="ISBN" ReadOnly="true"/>
                        <asp:BoundField DataField="BookName" HeaderText="图书名称" />
                        <asp:BoundField DataField="Type" HeaderText="图书类型" />
                        <asp:BoundField DataField="PubName" HeaderText="出版社" />
                        <asp:BoundField DataField="BookCase" HeaderText="书架" />
                        <asp:BoundField DataField="Author" HeaderText="作者" />
                         <asp:HyperLinkField DataNavigateUrlFormatString="AddBook.aspx?ISBN={0}" HeaderText="修改"
                            Text="修改" DataNavigateUrlFields="ISBN" >
                             <ControlStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            <HeaderStyle ForeColor="Black" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField DataNavigateUrlFormatString="~/BookDetail.aspx?ISBN={0}" HeaderText="详情"
                            Text="详情" DataNavigateUrlFields="ISBN" >
                            <ControlStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            <HeaderStyle ForeColor="Black" />
                        </asp:HyperLinkField>
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" >
                            <HeaderStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            <ControlStyle ForeColor="Black" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
                <p>&nbsp;</p></td>
            </tr>
            <tr>
              <td height="4" valign="top" background="../images/tu shu pai hang3.gif"></td>
            </tr>
            
          </table>
            </td>
        </tr>
      </table>
</asp:Content>
