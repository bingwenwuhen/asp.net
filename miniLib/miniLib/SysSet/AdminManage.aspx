﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="AdminManage.aspx.cs" Inherits="miniLib.SysSet.AdminManage" %>
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
                  <td height="45" colspan="3" align="right" background="../images/danganguanli.gif" style="background-image: url(../images/guanliyuanshezhi.gif)">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="622" height="32" align="right"><img src="../images/tianjia tubiao.gif" width="19" height="18"></td>
                  <td width="89" align="right" class="daohang1"><asp:HyperLink ID="hpLinkAddAdmin" runat="server" NavigateUrl="~/SysSet/AddAdmin.aspx" ForeColor="Black">添加管理员</asp:HyperLink></td>
                  <td width="45">&nbsp;</td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="23" background="../images/tu shu pai hang2.gif" style="text-align: center"><asp:GridView ID="gvAdminPurview" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" PageSize="5" AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvAdminPurview_PageIndexChanging" OnRowCancelingEdit="gvAdminPurview_RowCancelingEdit" OnRowDeleting="gvAdminPurview_RowDeleting" OnRowEditing="gvAdminPurview_RowEditing" OnRowUpdating="gvAdminPurview_RowUpdating" Width="543px">
                    <HeaderStyle BackColor="#DFF5F5" Font-Bold="False" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="管理员编号" ReadOnly="True" />
                        <asp:BoundField DataField="LoginName" HeaderText="管理员名称" ReadOnly="True" />
                        <asp:CheckBoxField DataField="SysSet" HeaderText="系统设置" />
                        <asp:CheckBoxField DataField="ReadSet" HeaderText="读者管理" />
                        <asp:CheckBoxField DataField="BookSet" HeaderText="图书管理" />
                        <asp:CheckBoxField DataField="BorrowBack" HeaderText="图书借还" />
                        <asp:CheckBoxField DataField="SysQuery" HeaderText="系统查询" />
                        <asp:CommandField EditText="权限设置" HeaderText="权限设置" ShowEditButton="True" UpdateText="设置" />
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
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
