﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="AddReader.aspx.cs" Inherits="miniLib.AddReader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {

        });
    </script>
    <table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
          <form name="form1" method="post" action="">
          <td valign="top"><table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="756" height="24" colspan="3" align="right">&nbsp;</td>
            </tr>
            <tr>
              <td height="45" colspan="3" background="../images/tianjiaxiugaitushuxinxi.gif" style="background-image: url(../images/tianjiaxiugaiduzhexinxi.gif)">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="3" background="../images/tu shu pai hang2.gif"><table width="730" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td colspan="5" align="center">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="175" height="26" align="right" class="daohang1">&nbsp;</td>
                  <td width="66" align="center" class="daohang1">读者编号：</td>
                  <td colspan="3">
                      <asp:Label ID="LabelReaderId" runat="server" Width="163px"></asp:Label>
                    </td>
                  <td width="306" align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="28" align="right" class="daohang1">&nbsp;</td>
                  <td height="28" align="center" class="daohang1">姓名：</td>
                  <td colspan="3"><asp:TextBox ID="txtReader" runat="server" Height="22px" Width="163px"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                    <tr>
                  <td height="27" align="right" class="daohang1">&nbsp;</td>
                  <td height="27" align="center" class="daohang1">密码：</td>
                  <td colspan="3"><label>
                    <asp:TextBox ID="TxtPwd" runat="server" Height="22px" Width="163px"></asp:TextBox>
                  </label></td>
                  <td align="center" style="text-align: left" class="daohang1">&nbsp;</td>
                </tr>
                   <tr>
                  <td height="27" align="right" class="daohang1">&nbsp;</td>
                  <td height="27" align="center" class="daohang1">密码确认：</td>
                  <td colspan="3"><label>
                    <asp:TextBox ID="TxtConfirmPwd" runat="server" Height="22px" Width="163px"></asp:TextBox>
                  </label></td>
                  <td align="center" style="text-align: left" class="daohang1">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1"> 性别：</td>
                  <td colspan="3"><label>
                    <asp:DropDownList ID="ddlSex" runat="server" Width="154px">
                    <asp:ListItem>男</asp:ListItem>
                    <asp:ListItem>女</asp:ListItem>
                </asp:DropDownList>
                  </label></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="29" align="right" class="daohang1">&nbsp;</td>
                  <td height="29" align="center" class="daohang1">读者类型：</td>
                  <td colspan="3"><asp:DropDownList ID="ddlRType" runat="server" Width="155px">
                      <asp:ListItem>管理员</asp:ListItem>
                      <asp:ListItem>读者</asp:ListItem>
                      <asp:ListItem>Vip</asp:ListItem>
                </asp:DropDownList></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1">证件号码：</td>
                  <td colspan="3">
                      <asp:TextBox ID="TxtCardNumber" runat="server" Height="22px" Width="163px"></asp:TextBox>
                    </td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="27" align="right" class="daohang1">&nbsp;</td>
                  <td height="27" align="center" class="daohang1">电话：</td>
                  <td colspan="3"><asp:TextBox ID="txtTel" runat="server" Height="22px" Width="163px"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="24" align="right" class="daohang1">&nbsp;</td>
                  <td height="24" align="center" class="daohang1">Email：</td>
                  <td colspan="3"><asp:TextBox ID="txtEmail" runat="server" Height="22px" Width="163px"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="27" align="right" class="daohang1">&nbsp;</td>
                  <td height="27" align="center" class="daohang1">注册日期：</td>
                  <td colspan="3"><label>
                    <asp:TextBox ID="txtDate" runat="server" Height="22px" Width="163px"></asp:TextBox>
                  </label></td>
                  <td align="center" style="text-align: left" class="daohang1">（格式为2007-01-01）&nbsp;</td>
                </tr>
                <tr>
                  <td height="28" align="right" class="daohang1">&nbsp;</td>
                  <td height="28" align="center" class="daohang1">&nbsp;</td>
                  <td colspan="3">&nbsp;</td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" colspan="2" align="center">&nbsp;</td>
                  <td colspan="3"><label>
                  </label>
                    <label>
                    </label>
                    <asp:Button ID="btnAdd" runat="server" Enabled="False" OnClick="btnAdd_Click" Text="添加" Height="20px" style="margin-top: 13px" Width="43px" />
                      &nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="修改" OnClick="btnSave_Click" Enabled="False" Width="47px" />
                      &nbsp;
                      <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" CausesValidation="False" Width="43px" />&nbsp; </td>
                  <td align="center">&nbsp;</td>
                </tr>
              </table>                
                <p>
                  <label></label>
                </p>
               </td>
              </tr>
            <tr>
              <td height="4" colspan="3" valign="top" background="../images/tu shu pai hang3.gif"></td>
            </tr>
            
          </table>
            </td></form>
        </tr>
      </table>
</asp:Content>
