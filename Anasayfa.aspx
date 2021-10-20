<%@ Page Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="YurtdisiTebligat.Anasayfa"  Title="TEBLIGAT Uygulaması"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 50px; width: 998px; font-weight: 700; text-align: center">
        <span style="font-size: large">ÇIKTI ALMA EKRANI</span>
    </div>
    <div style="height: 350px; width: 998px; font-weight: 700; text-align: center; font-size: small; margin-bottom: 18px;">
        
        Lütfen çıktısını almak istediğiniz aralığı giriniz:<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="60px"></asp:TextBox>
&nbsp;-
        <asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="60px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnDokumAl" runat="server" Height="29px" OnClick="BtnDokumAl_Click" Text="DÖKÜM AL (4A)" Width="121px" OnClientClick="document.forms[0].target ='_self';"/>     
        <asp:Button ID="Button1" runat="server" Height="29px" OnClick="BtnDokumAl_Click4B" Text="DÖKÜM AL (4B)" Width="121px" OnClientClick="document.forms[0].target ='_self';"/>
        <asp:Button ID="BtnDokumAl4C0" runat="server" Height="29px" OnClick="BtnDokumAl4C0_Click" Text="DÖKÜM AL (4C)" Width="121px" OnClientClick="document.forms[0].target ='_self';"/>
        <br />
        <br />
        <asp:Button ID="BtnVeriGoruntule" runat="server" Height="29px" OnClick="BtnVeriGoruntule_Click" Text="Aralıktaki Verileri Görüntüle(4A)" Width="210px" OnClientClick="document.forms[0].target ='_blank';"/>
        <asp:Button ID="Button2" runat="server" Height="29px" OnClick="BtnVeriGoruntule_Click4B" Text="Aralıktaki Verileri Görüntüle(4B)" Width="210px" OnClientClick="document.forms[0].target ='_blank';"/>
        <asp:Button ID="BtnTumVerileriGoruntule" runat="server" Height="29px" Text="Aralıktaki Verileri Görüntüle(4C)" Width="210px" OnClick="BtnTumVerileriGoruntule_Click" OnClientClick="document.forms[0].target ='_blank';"/>
        
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Toplam Kişi Sayısı (4A) :"></asp:Label>
          <asp:Label ID="Label2" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Toplam Kayıt Sayısı(4A) :"></asp:Label>
        <asp:Label ID="Label6" runat="server"></asp:Label>     
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="Label10" runat="server" Text="Toplam Kişi Sayısı (4B) :"></asp:Label>
       <asp:Label ID="Label11" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
        <asp:Label ID="Label12" runat="server" Text="Toplam Kayıt Sayısı (4B) :"></asp:Label>
        <asp:Label ID="Label13" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Toplam Kişi Sayısı (4C)  :"></asp:Label>
        <asp:Label ID="Label4" runat="server"></asp:Label>        
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Text="Toplam Kayıt Sayısı (4C)  :"></asp:Label>
        <asp:Label ID="Label8" runat="server"></asp:Label>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:TextBox ID="TextBox3" runat="server" Height="20px" Width="116px" placeHolder="TCKN Girin"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" Height="20px" Width="116px" placeHolder="Tahsis No Girin"></asp:TextBox>
        <br />
             Lütfen çıktı almak istediğiniz TC/Tahsis numarasını giriniz:<br />
        <br />
        <asp:Button ID="Button3" runat="server" Height="29px" OnClick="BtnTekTC_Click" Text="T.C. NO " Width="121px" OnClientClick="document.forms[0].target ='_self';"/>
        <asp:Button ID="Button4" runat="server" Height="29px" OnClick="BtnTekTahsis_Click" Text="TAHSİS NO " Width="121px" OnClientClick="document.forms[0].target ='_self';"/>
    </div>
</asp:Content>
