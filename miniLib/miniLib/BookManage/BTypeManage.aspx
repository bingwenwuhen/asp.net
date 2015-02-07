<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="BTypeManage.aspx.cs" Inherits="miniLib.BookManage.BTypeManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#Add").click(function () {
                var number = $("#number").val();
                var name = $("#Category").val();
                $.post("/ajax/AddCategory.ashx", {"number":number,"name":name},PostFinsh);
            });
            $("#Cancel").click(function () {
                var cancel = confirm("确定取消吗？");
                if (cancel) {
                    window.location = "BTypeManage.aspx";
                } else {

                }
            });
        });
        var PostFinsh = function (data) {
            if (data == "ok") {
                alert("新增成功！");
            } else {
                alert("新增失败！");
            }
            window.location = "BTypeManage.aspx";
        }
    </script>
    <table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
          <td valign="top"><table border="0" align="center" cellpadding="0" cellspacing="0" style="width: 868px">
            <tr>
              <td width="756" height="24" align="right" class="daohang1">&nbsp;</td>
            </tr>
            <tr>
              <td height="22" background="../images/tu shu pai hang2.gif"><table height="77" border="0" align="right" cellpadding="0" cellspacing="0" style="width: 837px">
                <tr>
                  <td colspan="3" align="right" background="../images/danganguanli.gif" style="height: 45px; background-image: url(../images/tushuleixingguanli.gif);">&nbsp;</td>
                  </tr>
                <tr>
                  
                  <td width="89" align="right" class="daohang1"></td>
                  <td width="45">&nbsp;</td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="23" background="../images/tu shu pai hang2.gif"><asp:GridView ID="gvBTypeInfo" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" PageSize="5" AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvBTypeInfo_PageIndexChanging" OnRowCancelingEdit="gvBTypeInfo_RowCancelingEdit" OnRowDeleting="gvBTypeInfo_RowDeleting" OnRowEditing="gvBTypeInfo_RowEditing" OnRowUpdating="gvBTypeInfo_RowUpdating" Width="625px" HorizontalAlign="Center">
                    <HeaderStyle BackColor="#DFF5F5" Font-Bold="False" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="图书类型编号" ReadOnly="True" />
                        <asp:BoundField DataField="Name" HeaderText="图书类型名称" />
                        <asp:CommandField EditText="修改" HeaderText="修改" ShowEditButton="True" />
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView><br />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 编号：<input type="text" id="number" style="width: 155px; height: 21px"/>类型：<input type="text" id="Category" style="width: 155px; height: 21px"/><input type="button" id="Add" value="新增" style="width: 48px; height: 25px"/>&nbsp;<input type="button" id="cancel" value="取消" style="width: 48px; height: 25px"/>
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
