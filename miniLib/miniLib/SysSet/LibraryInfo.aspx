<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="LibraryInfo.aspx.cs" Inherits="miniLib.SysSet.LibraryInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#btnSave").click(function () {
                var LibraryName = $("#LbLibraryName").text();
                var txtCurator = $("#txtCurator").val();
                var txtTel = $("#txtTel").val();
                var txtAddress = $("#txtAddress").val();
                var txtEmail = $("#txtEmail").val();
                var txtUrl = $("#txtUrl").val();
                var txtCDate = $("#txtCDate").val();
                var txtIntroduce = $("#txtIntroduce").val();
                $.post("/ajax/ChangeLibraryInfo.ashx", {"LibraryName":LibraryName,"txtCurator":txtCurator,"txtTel":txtTel,"txtAddress":txtAddress,"txtEmail":txtEmail,"txtUrl":txtUrl,"txtCDate":txtCDate,"txtIntroduce":txtIntroduce},postFinish);
            });
            $("#btnCancel").click(function () {
                var bool = confirm("你确定取消吗？");
                if (bool) {
                    window.location = "LibraryInfo.aspx";
                } else {

                }
            });
        });
        var postFinish = function (data) {
            if (data == "ok") {
                alert("修改成功！");
                window.location = "LibraryInfo.aspx";
            } else {
                alert("修改失败！");
            }
        }
    </script>
    <table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
            <form name="form1" method="post" action="">
                <td valign="top" style="width: 767px">
                    <table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="24" colspan="3" align="right" style="width: 921px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td height="45" colspan="3" background="../images/tushuguanxinxi.gif" style="width: 921px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3" background="../images/tu shu pai hang2.gif" style="width: 921px">
                                <table border="0" align="center" cellpadding="0" cellspacing="0" style="width: 899px">
                                    <tr>
                                        <td colspan="4" align="center">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="26" align="right" class="daohang1" style="width: 163px">&nbsp;</td>
                                        <td align="center" class="daohang1" style="width: 106px">图书馆名称：</td>
                                        <td colspan="2">
                                            <label>
                                                <asp:Label ID="LbLibraryName" runat="server" ClientIDMode="Static" Text="Label" Height="26px" Width="167px"></asp:Label>
                                            </label>
                                        </td>
                                        <td width="303" align="center">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="28" align="right" class="daohang1" style="width: 163px">&nbsp;</td>
                                        <td height="28" align="center" class="daohang1" style="width: 106px">馆长：</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtCurator" ClientIDMode="Static" runat="server" Height="26px" Width="167px"></asp:TextBox></td>
                                        <td align="center">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="25" align="right" class="daohang1" style="width: 163px">&nbsp;</td>
                                        <td height="25" align="center" class="daohang1" style="width: 106px">电话：</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtTel" ClientIDMode="Static" runat="server" Height="26px" Width="167px"></asp:TextBox></td>
                                        <td align="center">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="29" align="right" class="daohang1" style="width: 163px">&nbsp;</td>
                                        <td height="29" align="center" class="daohang1" style="width: 106px">地址：</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtAddress" runat="server" ClientIDMode="Static" Height="26px" Width="167px"></asp:TextBox></td>
                                        <td align="center">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="29" align="right" class="daohang1" style="width: 163px">&nbsp;</td>
                                        <td height="29" align="center" class="daohang1" style="width: 106px">E-mail:</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtEmail" ClientIDMode="Static" runat="server" Height="26px" Width="167px"></asp:TextBox></td>
                                        <td align="center">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="25" align="right" class="daohang1" style="width: 163px">&nbsp;</td>
                                        <td height="25" align="center" class="daohang1" style="width: 106px">网址：</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtUrl" ClientIDMode="Static" runat="server" Height="26px" Width="167px"></asp:TextBox></td>
                                        <td align="center">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="27" align="right" class="daohang1" style="width: 163px">&nbsp;</td>
                                        <td height="27" align="center" class="daohang1" style="width: 106px">建馆时间：</td>
                                        <td colspan="2" class="daohang1">
                                            <asp:TextBox ID="txtCDate" runat="server" ClientIDMode="Static" Height="26px" Width="167px"></asp:TextBox></td>
                                        <td align="center" style="text-align: left" class="daohang1">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="88" align="right" class="daohang1" style="width: 163px">&nbsp;</td>
                                        <td height="88" align="center" class="daohang1" style="width: 106px">简介：</td>
                                        <td colspan="2">
                                            <label>
                                                <asp:TextBox ID="txtIntroduce" ClientIDMode="Static" runat="server" Height="282px" TextMode="MultiLine" Width="567px"></asp:TextBox>
                                                <br>
                                            </label>
                                        </td>
                                        <td align="center">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="25" colspan="2" align="center">&nbsp;</td>
                                        <td colspan="2">
                                            <label>
                                            </label>
                                            <label>
                                                <input type="button" id="btnSave" value="保存" style="width: 66px; height: 31px; margin-left: 0px" />
                                                &nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnCancel" value="取消" style="width: 66px; height: 31px; margin-left: 0px" />
                                            </label>
                                        </td>
                                        <td align="center">&nbsp;</td>
                                    </tr>
                                </table>
                                <p>&nbsp;</p>
                            </td>
                        </tr>


                        <tr>
                            <td height="4" colspan="3" valign="top" background="../images/tu shu pai hang3.gif" style="width: 921px"></td>
                        </tr>

                    </table>
                </td>
            </form>
        </tr>
    </table>
</asp:Content>
