<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="ChangeUserInformation.aspx.cs" Inherits="miniLib.ChangeUserInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
          <form name="form1" method="post" action="">
          <td valign="top" style="width: 766px"><table border="0" align="center" cellpadding="0" cellspacing="0" style="width: 909px">
            <tr>
              <td width="756" height="24" colspan="3" align="right">&nbsp;</td>
            </tr>
            <tr>
              <td height="45" colspan="3" background="../images/tianjiaxiugaitushuxinxi.gif" style="background-image: url(../images/genggaimima.gif)">
                  </td>
            </tr>
            <tr>
              <td colspan="3" background="../images/tu shu pai hang2.gif"><table width="730" border="0" align="center" cellpadding="0" cellspacing="0" style="height: 213px">
                <tr>
                  <td colspan="5" align="center">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="175" height="26" align="right" class="daohang1">&nbsp;</td>
                  <td align="center" class="daohang1" style="width: 85px">登录名：</td>
                  <td colspan="3">
                      <asp:Label ID="LabelName" runat="server"></asp:Label>
                    </td>
                  <td align="center" style="width: 294px">&nbsp;</td>
                </tr>
                  </tr>
                  <tr>
                  <td align="right" class="daohang1" style="height: 25px"></td>
                  <td align="center" class="daohang1" style="width: 85px; height: 25px;"></td>
                  <td colspan="3" style="height: 25px"><label>
                  </label></td>
                  <td align="center" style="width: 294px; height: 25px;"></td>
                </tr>
                <tr>
                  <td height="28" align="right" class="daohang1">&nbsp;</td>
                  <td height="28" align="center" class="daohang1" style="width: 85px">个人住址：</td>
                  <td colspan="3"><asp:TextBox ID="txtAdress" runat="server" Width="236px" Height="29px"></asp:TextBox></td>
                  <td align="center" style="width: 294px">
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="txtAdress">*</asp:RequiredFieldValidator>
                      <br />
                    </td>
                </tr>
                  <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1" style="width: 85px"></td>
                  <td colspan="3"><label>
                  </label></td>
                  <td align="center" style="width: 294px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1" style="width: 85px">电话：</td>
                  <td colspan="3"><label>
                    <asp:TextBox ID="txtPhone" runat="server" Width="226px" Height="25px"></asp:TextBox>
                  </label></td>
                  <td align="center" style="width: 294px">
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="txtPhone">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                  </tr>
                  <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1" style="width: 85px"></td>
                  <td colspan="3"><label>
                  </label></td>
                  <td align="center" style="width: 294px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="29" align="right" class="daohang1">&nbsp;</td>
                  <td height="29" align="center" class="daohang1" style="width: 85px">Email：</td>
                  <td colspan="3"><asp:TextBox ID="txtEmail" runat="server" Width="232px" Height="28px"></asp:TextBox></td>
                  <td align="center" style="width: 294px; text-align: left">
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
              </tr>
                  <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1" style="width: 85px"></td>
                  <td colspan="3"><label>
                  </label></td>
                  <td align="center" style="width: 294px">&nbsp;</td>
                </tr>
                 <tr>
                  <td height="29" align="right" class="daohang1">&nbsp;</td>
                  <td height="29" align="center" class="daohang1" style="width: 85px">级别：</td>
                  <td colspan="3">
                      <asp:Label ID="LbCategeory" runat="server"></asp:Label>
                     </td>
                  <td align="center" style="width: 294px; text-align: left">
                      不可修改</td>
                </tr>
              </tr>
                  <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1" style="width: 85px"></td>
                  <td colspan="3"><label>
                  </label></td>
                  <td align="center" style="width: 294px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="29" align="right" class="daohang1">&nbsp;</td>
                  <td height="29" align="center" class="daohang1" style="width: 85px">性别：</td>
                  <td colspan="3">
                      <asp:RadioButton ID="RadioMan" runat="server" Text="男" />
                      <asp:RadioButton ID="RadioWoman" runat="server" Text="女" />
                    </td>
                  <td align="center" style="width: 294px; text-align: left">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" colspan="2" align="center">&nbsp;</td>
                  <td colspan="3"><label>
                  </label>
                    <label>
                    </label>
                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" Height="26px" style="margin-left: 0px" Width="58px" />
                      &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" CausesValidation="False" Height="28px" Width="60px" />
                    </td>
                  <td align="center" style="width: 294px">&nbsp;</td>
                </tr>
         <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1" style="width: 85px"></td>
                  <td colspan="3"><label>
                  </label></td>
                  <td align="center" style="width: 294px">&nbsp;</td>
                </tr>
         <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1" style="width: 85px"></td>
                  <td colspan="3"><label>
                  </label></td>
                  <td align="center" style="width: 294px">&nbsp;</td>
                </tr>
              </table>                
                <p>
                  <label></label>
                </p>
               </td>
              </tr>
            <tr>
              <td height="3" colspan="3" valign="top" background="../images/tu shu pai hang3.gif"></td>
            </tr>
            
          </table>
            </td></form>
        </tr>
      </table>
</asp:Content>
