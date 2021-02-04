<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="maddant._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>

        
     html, body {
      height: 100%;
      margin: 0;
    }
   .hContent{
    
      width:100%;
       overflow:hidden;height:100%; 
   }
   .eContent {
   
      width:100%;
      
    }
   .full ,.body-content{
       height:100%;
        }
   .half {
       height:50%;
        }
  </style>

        <asp:UpdatePanel  ID="UpdatePanel1" runat="server">

         <ContentTemplate>
                
                <asp:Timer ID="tmrLive" runat="server" OnTick="tmrLive_Tick" Interval="5000"></asp:Timer>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                 
                 <asp:Panel ID="pnlNormale" BorderStyle="Double" class="hContent" runat="server" Height="100%">

                     <iframe  class="hContent full" src="Evento.aspx"></iframe>

                 </asp:Panel>

                 <asp:Panel ID="pnlEvento" BorderStyle="Double" runat="server">

                     <iframe class="eContent half" src="Evento.aspx"></iframe>
                     <iframe  class="hContent half" src="http://www.dbinfo.it"></iframe>

                 </asp:Panel>

         </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>
