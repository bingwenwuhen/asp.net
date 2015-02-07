<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="miniLib.Register" %>

<!DOCTYPE html>
<html>
    <head>
        <title>注册</title>
    </head>
    <body>
     <center>
        <form id="form1" runat="server">
     
 <div style="font-size:small">
  <table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td style="width: 10px"><img src="../Images/az-tan-top-left-round-corner.gif" width="10" height="28" /></td>
    <td bgcolor="#DDDDCC"><span class="STYLE1">注册新用户</span></td>
    <td width="10"><img src="../Images/az-tan-top-right-round-corner.gif" width="10" height="28" /></td>
  </tr>
</table>


<table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
    <td><div align="center">
      <table height="61" cellpadding="0" cellspacing="0" style="height: 332px">
        <tr>
         <h1> <td height="33" colspan="2"><p class="STYLE2" style="text-align: center">注册新帐户</p></td></h1>
        </tr>
        <tr>
          <td width="24%" align="center" valign="top" style="height: 26px">用户名</td>
          <td valign="top" width="37%" align="left" style="height: 26px">
              <asp:TextBox ID="TxtUser" runat="server"></asp:TextBox>
            </td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">密码：</td>
          <td valign="top" width="37%" align="left">
              <asp:TextBox ID="TxtPwd" runat="server" TextMode="Password"></asp:TextBox>
            </td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">确认密码：</td>
          <td valign="top" width="37%" align="left">
              <asp:TextBox ID="TxtConfirmPwd" runat="server" TextMode="Password"></asp:TextBox>
            </td>          
        </tr>
           <tr>
          <td width="24%" height="26" align="center" valign="top">性别：</td>
          <td valign="top" width="37%" align="left">
              
              <asp:RadioButton ID="RadioMan" runat="server" Checked="True" Text="男" />
              <asp:RadioButton ID="RadioWoman" runat="server" Text="女" />
              
            </td>          
        </tr>
         <tr>
          <td width="24%" height="26" align="center" valign="top">Email：</td>
          <td valign="top" width="37%" align="left">
              <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
             </td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">地址：</td>
          <td valign="top" width="37%" align="left">
              <asp:TextBox ID="TxtAddress" runat="server"></asp:TextBox>
            </td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">手机：</td>
          <td valign="top" width="37%" align="left">
              <asp:TextBox ID="TxtPhone" runat="server"></asp:TextBox>
            </td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">
              验证码：</td>
          <td valign="top" width="37%" align="left">
              <asp:TextBox ID="TxtvCode" runat="server"></asp:TextBox>
              <asp:Image ID="Image1" runat="server" ImageUrl="~/ajax/ValidateCode.ashx"/>  
            </td>          
        </tr>
        <tr>
          <td colspan="2" align="left">&nbsp;</td>           
        </tr>
        <tr>
          <td colspan="2" align="center">
              <asp:Button ID="BtnConfirm" runat="server" Text="确定" OnClick="BtnConfirm_Click" />
              <asp:Button ID="BtnCancel" runat="server" Text="取消" />
            </td>           
        </tr>
      </table>
      <div class="STYLE5">---------------------------------------------------------</div>
    </div>	
    </td>
    <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
  </tr>
</table>

<table width="80%" height="3" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="3" bgcolor="#DDDDCC"><img src="../Images/touming.gif" width="27" height="9" /></td>
  </tr>
</table>
</div>
        </form>
         </center>
    </body>
</html>