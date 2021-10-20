<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="YurtdisiTebligat.header" %>
<div style="text-align: center">
    <table style="width: 648px; height: 49px">
        <tr>
            <td style="width: 100px">
                <img src="Images/header.jpg" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <table width="780" border="0" cellspacing="0" cellpadding="0" align="center" height="25">
                    <tr>
                        <td class="pg9" bgcolor="#F5F5F5">
                            <img src="themes/toolbarLeft.gif" />
                        </td>
                        <td background="Images/toolbarBack.gif" align="left" class="pg9" width="230">
                        </td>
                        <td background="Images/toolbarBack.gif" class="pg9" width="530" align="right">
                            <div style="width: 969px"><asp:LinkButton ID="linkBtnCikis" runat="server" CausesValidation="False" PostBackUrl="~/login.aspx?logout=true">Çýkýþ</asp:LinkButton></div>
                        </td>
                        <td width="7" class="pg9">
                            <img src="Images/toolbarRight.gif">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>