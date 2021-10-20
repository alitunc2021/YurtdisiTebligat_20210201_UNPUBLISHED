<%@ Page Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="YurtdisiTebligat.login" Title="TEBLIGAT Uygulamasý - Giriþ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="border: solid 1px #000; margin: 0px auto; padding: 1px; background-color:#F5F5F5">
            <caption>Giriþ</caption>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblHata" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td class="td1">
                    Kullanýcý Adý:
                </td>
                <td class="td2"">
                    <asp:TextBox ID="txtKulAd" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ControlToValidate="txtKulAd" Display="Dynamic"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="td1">
                    Þifre:
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtSifre" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        ControlToValidate="txtSifre" Display="Dynamic"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:Button ID="btnYetkiGiris" runat="server" Text="Giriþ" OnClick="Button1_Click"
                        Width="99px" /></td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>