<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="miniLib.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>miniLib</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
<link href="css/css.css" rel="stylesheet" type="text/css"/>
<style type="text/css">
<!--
body {
	background-color: #DDDDDD;
}
    .auto-style1
    {
        height: 22px;
    }
-->
</style>
    <script type="text/javascript">
        function getVCode() {
            document.getElementById("VCode").src = "../ajax/ValidateCode.ashx";
        }
    </script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<div align="center">
  <table id="Table1" width="914" height="459" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td rowspan="5" bgcolor="#DDDDDD">&nbsp;</td>
	    <td height="150" valign="bottom" bgcolor="#65D7D4">&nbsp;</td>
	    <td rowspan="5" bgcolor="#DDDDDD">&nbsp;</td>
    </tr>
    <tr><form id="Form1" name="form1" method="post" action="" runat="server">
      <td height="256" valign="top" background="images/denglu.jpg"><table width="777" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="421" height="103">&nbsp;</td>
          <td width="65">&nbsp;</td>
          <td colspan="2" >&nbsp;</td>
        </tr>
        <tr>
          <td height="26">&nbsp;</td>
          <td><span class="daohang1">用户登录：
            </span>
            <label></label></td>
          <td colspan="3"><label>
            <asp:TextBox ID="txtUser" runat="server" Height="23px" Width="160px"></asp:TextBox>
              &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
          </label></td>
        </tr>
        <tr>
          <td height="22">&nbsp;</td>
          <td class="daohang1">用户密码：</td>
          <td colspan="3"><label>
            <asp:TextBox ID="txtPwd" runat="server" Width="161px" TextMode="Password" Height="24px"></asp:TextBox>
              &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;</label></td>
        </tr>
        <tr>
          <td height="31">&nbsp;</td>
          <td><span class="daohang1">验证码：</span>
            <label></label></td>
          <td colspan="3"><label>
            <asp:TextBox ID="txtCode" runat="server" Width="102px" Height="22px"></asp:TextBox>
              <img id="VCode" onclick="getVCode()" src="../ajax/ValidateCode.ashx"/>
              &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
          </label></td></tr>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <tr>
          <td class="auto-style1" bgcolor="#65D7D4"></td>
          <td class="auto-style1" bgcolor="#65D7D4"></td>

          <td width="69" class="auto-style1"><label>
            <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" style="margin-left: 0px" Width="69px" Height="26px" />
          </label></td>
            <%--<td width="3" class="auto-style1" bgcolor="#65D7D4"></td>--%>
          <td width="51" class="auto-style1"><label>
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" Width="73px" Height="28px" />
          </label></td>
          <td width="171" class="auto-style1" bgcolor="#65D7D4"><label>
              
                                                                </label></td>
        </tr>
      </table></td>
    </form>
    </tr>
    <tr>
      <td width="700" height="230" bgcolor="#65D7D4">&nbsp;</td>
    </tr>
    <%--<tr>
      <td height="66" background="images/index_14.gif">&nbsp;</td>
    </tr>--%>
   <%-- <tr>
      <td colspan="2" bgcolor="#DDDDDD">&nbsp;</td>
    </tr>--%>
  </table>
</div>
</body>
</html>
