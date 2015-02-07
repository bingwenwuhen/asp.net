<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="RTypeManage.aspx.cs" Inherits="miniLib.ReaderManage.RTypeManage" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#BtnSubmit").click(function () {
                var Readernumber = $("#ReaderNumber").val();
                var name = $("#ReaderName").val();
                var number = $("#number").val();
                $.post("/ajax/AddReader.ashx", {"Readernumber":Readernumber,"Name":name,"Number":number},postFinsh);
            });
            $("#BtnCancel").click(function () {
                var bool = confirm("你确定取消");
                if (bool) {
                    $("#ReaderNumber").val("");
                    $("#ReaderName").val("");
                    $("#number").val("");
                }else{
                
                }
            });
        });
        var postFinsh=function(data){
            if (data == "ok") {
                alert("添加成功！");
                window.location = "~/RTypeManage.aspx";
            } else {
                alert("添加失败！");
            }
        }
    </script>
    <table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="756" height="24" align="right" class="daohang1">&nbsp;</td>
            </tr>
            <tr>
              <td height="22" background="../images/tu shu pai hang2.gif">
<table width="756" height="77" border="0" align="right" cellpadding="0" cellspacing="0">
                <tr>
                  <td colspan="3" align="right" background="../images/shujiaxinxi.gif" style="height: 44px; background-image: url(../images/duzheleixingguanli.gif);">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="626" height="32" align="right"><img src="../images/tianjia tubiao.gif" width="19" height="18"></td>
                  <td width="85" align="right" class="daohang1"><asp:HyperLink ID="hpLinkAddRType" runat="server" NavigateUrl="~/ReaderManage/AddRType.aspx" Width="102px" ForeColor="Black"></asp:HyperLink></td>
                  <td width="45">&nbsp;</td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="23" background="../images/tu shu pai hang2.gif"><asp:GridView ID="gvRTypeInfo" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" PageSize="5" AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvRTypeInfo_PageIndexChanging" OnRowCancelingEdit="gvRTypeInfo_RowCancelingEdit" OnRowDeleting="gvRTypeInfo_RowDeleting" OnRowEditing="gvRTypeInfo_RowEditing" OnRowUpdating="gvRTypeInfo_RowUpdating" Width="642px" HorizontalAlign="Center" Height="176px">
                    <HeaderStyle BackColor="#DFF5F5" Font-Bold="True" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="读者类型编号" ReadOnly="True" />
                        <asp:BoundField DataField="Name" HeaderText="读者类型名称" />
                        <asp:BoundField DataField="BookNumber" HeaderText="可借数量" />
                        <asp:CommandField EditText="修改" HeaderText="修改" ShowEditButton="True" />
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
                <p>&nbsp;</p>

                   <center>
               读者类型编号： <input type="text" id="ReaderNumber" style="width: 163px; height: 26px"/><br /><br />
               读者类型名称： <input type="text" id="ReaderName" style="height: 25px; width: 165px; margin-left: 0px"/><br /><br />
               可借数量：&nbsp;&nbsp;&nbsp; &nbsp;<input type="text" id="number" style="width: 161px; height: 31px; margin-left: 0px;"/><br />
               <br /><input type="button" id="BtnSubmit"  value="新增" style="width: 71px; height: 28px"/>
                      &nbsp;&nbsp;
                      <input type="button" id="BtnCancel" value="取消" style="width: 71px; height: 28px"/>
             </center>
                       </td>
              </td>
            </tr>
            <tr>
              <td height="4" valign="top" background="../images/tu shu pai hang3.gif">
                 <%-- <center>
               读者类型编号： <input type="text" id="ReaderNumber" style="width: 163px; height: 26px"/><br /><br />
               读者类型名称： <input type="text" id="ReaderName" style="height: 25px; width: 165px; margin-left: 0px"/><br /><br />
               可借数量：&nbsp;&nbsp;&nbsp; &nbsp;<input type="text" id="number" style="width: 161px; height: 31px; margin-left: 0px;"/><br />
               <br /><input type="button" id="BtnSubmit"  value="新增" style="width: 71px; height: 28px"/>
                      &nbsp;&nbsp;
                      <input type="button" id="BtnCancel" value="取消" style="width: 71px; height: 28px"/>
             </center>
                       </td>--%>
            </tr>
            
          </table>
</asp:Content>
