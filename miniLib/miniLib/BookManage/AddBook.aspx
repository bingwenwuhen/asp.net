<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="miniLib.BookManage.AddBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("btnCancel").click(function () {
                var result = confirm("你确定取消吗？");
                if (result) {
                    window.location = "AddBook.aspx";
                } else {

                }
            });
        });
    </script>
    <table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
          <form name="form1" method="post" action="">
          <td valign="top" style="width: 1015px"><table border="0" align="center" cellpadding="0" cellspacing="0" style="width: 852px; margin-right: 0px">
            <tr>
              <td height="24" colspan="3" align="right" style="width: 860px">&nbsp;</td>
            </tr>
            <tr>
              <td height="45" colspan="3" background="../images/tianjiaxiugaitushuxinxi.gif" style="width: 860px">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="3" background="../images/tu shu pai hang2.gif" style="width: 860px"><table border="0" align="center" cellpadding="0" cellspacing="0" style="width: 842px">
                <tr>
                  <td colspan="5" align="center">&nbsp;</td>
                  </tr>
                <tr>
                  <td height="26" align="right" class="daohang1">&nbsp;</td>
                  <td width="66" align="center" class="daohang1">Id：</td>
                  <td colspan="3"><label>
                    <asp:TextBox ID="txtID" runat="server" Height="28px" Width="163px"></asp:TextBox>
                  </label></td>
                  <td align="center" class="auto-style3" style="width: 499px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="28" align="right" class="daohang1">&nbsp;</td>
                  <td height="28" align="center" class="daohang1">图书名称：</td>
                  <td colspan="3"><asp:TextBox ID="txtBName" runat="server" Height="28px" Width="163px"></asp:TextBox></td>
                  <td align="center" class="auto-style3" style="width: 499px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1">图书类型：</td>
                  <td colspan="3"><label>
                    <asp:DropDownList ID="ddlBType" runat="server" Width="155px">
                </asp:DropDownList>
                  </label></td>
                  <td align="center" class="auto-style3" style="width: 499px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="29" align="right" class="daohang1">&nbsp;</td>
                  <td height="29" align="center" class="daohang1">作者：</td>
                  <td colspan="3"><asp:TextBox ID="txtAuthor" runat="server" Height="28px" Width="163px"></asp:TextBox></td>
                  <td align="center" class="auto-style3" style="width: 499px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1">ISBN:</td>
                  <td colspan="3"><asp:TextBox ID="txtISBN" runat="server" Height="28px" Width="163px"></asp:TextBox></td>
                  <td align="center" class="auto-style3" style="width: 499px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1">出版社：</td>
                  <td colspan="3"><asp:TextBox ID="txtPub" runat="server" Height="28px" Width="163px"></asp:TextBox></td>
                  <td align="center" class="auto-style3" style="width: 499px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="27" align="right" class="daohang1">&nbsp;</td>
                  <td height="27" align="center" class="daohang1">价格：</td>
                  <td colspan="3"><asp:TextBox ID="txtPrice" runat="server" Height="28px" Width="163px"></asp:TextBox></td>
                  <td align="center" class="auto-style3" style="width: 499px">&nbsp;</td>
                </tr>
                <tr>
                  <td align="right" class="daohang1" style="height: 24px"></td>
                  <td align="center" class="daohang1" style="height: 24px">页码：</td>
                  <td colspan="3" style="height: 24px"><asp:TextBox ID="txtPage" runat="server" Height="28px" Width="163px"></asp:TextBox></td>
                  <td align="center" class="auto-style3" style="width: 499px; height: 24px"></td>
                </tr>
                <tr>
                  <td height="27" align="right" class="daohang1">&nbsp;</td>
                  <td height="27" align="center" class="daohang1">书架：</td>
                  <td colspan="3"><label>
                    <asp:DropDownList ID="ddlBCase" runat="server" Width="155px">
        </asp:DropDownList>
                  </label></td>
                  <td align="center" class="auto-style3" style="width: 499px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="28" align="right" class="daohang1">&nbsp;</td>
                  <td height="28" align="center" class="daohang1">&nbsp;</td>
                  <td colspan="3">&nbsp;</td>
                  <td align="center" class="auto-style3" style="width: 499px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1">内容描述：</td>
                  <td colspan="3"><asp:TextBox ID="txtContent" runat="server" Height="232px" Width="615px" Rows="30" TextMode="MultiLine"></asp:TextBox></td>
                  <td align="center" style="text-align: left; width: 499px;" class="daohang1">&nbsp;</td>
                </tr>
                <tr>
                  <td height="26" align="right" class="daohang1">&nbsp;</td>
                  <td height="26" align="center" class="daohang1">目录：</td>
                  <td colspan="3"> <asp:TextBox ID="txtTOC" runat="server" Height="549px" Width="605px" TextMode="MultiLine"></asp:TextBox></td>
                  <td align="center" class="auto-style3" style="width: 499px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" colspan="2" align="center">&nbsp;</td>
                  <td colspan="3"><label>
                  </label>
                    <label>
                    </label>
                    <asp:Button ID="btnAdd" runat="server" Enabled="False" OnClick="btnAdd_Click" Text="添加" Height="25px" Width="62px" />
                      &nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="修改" OnClick="btnSave_Click" Enabled="False"  Height="25px" Width="62px"  />
                      &nbsp;
                      <asp:Button ID="btnCancel" runat="server" Text="取消"  Height="25px" Width="62px" ClientIDMode="Static"  /></td>
                  <td align="center" class="auto-style3" style="width: 499px">&nbsp;</td>
                </tr>
              </table>                
                <p>
                  <label></label>
                </p>
               </td>
              </tr>
            <tr>
              <td height="4" colspan="3" valign="top" background="../images/tu shu pai hang3.gif" style="width: 860px"></td>
            </tr>
            
          </table>
            </td></form>
        </tr>
      </table>
</asp:Content>
