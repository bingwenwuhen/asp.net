﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="BCaseManage.aspx.cs" Inherits="miniLib.SysSet.BCaseManage" %>
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
                  <td height="45" colspan="3" align="right" background="../images/danganguanli.gif" style="background-image: url(../images/shujiaguanli.gif)">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="622" height="32" align="right"><img src="../images/tianjia tubiao.gif" width="19" height="18"></td>
                  <td width="89" align="right" class="daohang1"><asp:HyperLink ID="hpLinkAddBCase" runat="server" NavigateUrl="~/SysSet/AddBCase.aspx" ForeColor="Black">添加书架信息</asp:HyperLink></td>
                  <td width="45">&nbsp;</td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="43" background="../images/tu shu pai hang2.gif"><asp:GridView ID="gvBCaseInfo" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" PageSize="8" AutoGenerateColumns="False" Font-Size="15pt" OnPageIndexChanging="gvBCaseInfo_PageIndexChanging" OnRowCancelingEdit="gvBCaseInfo_RowCancelingEdit" OnRowDeleting="gvBCaseInfo_RowDeleting" OnRowEditing="gvBCaseInfo_RowEditing" OnRowUpdating="gvBCaseInfo_RowUpdating" Width="643px" HorizontalAlign="Center" GridLines="None">
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="BookCaseId" HeaderText="书架编号" ReadOnly="True" />
                        <asp:BoundField DataField="Name" HeaderText="书架名称" />
                        <asp:CommandField EditText="修改" HeaderText="修改" ShowEditButton="True" />
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
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
