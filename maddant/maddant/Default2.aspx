<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="maddant.Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

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

   .almostfull {
       height:90%;
        }
   .full {
       height:100%;
        }
   .half {
       height:50%;
        }
  </style>
</head>
<body>
    <form class="almostfull" id="form1" runat="server">
      <asp:Timer ID="tmrLive" runat="server" OnTick="tmrLive_Tick" Interval="5000"></asp:Timer>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                 
                 <asp:Panel ID="pnlNormale"  class="hContent" runat="server" Height="100%">

                     <iframe  class="hContent full" src="Evento.aspx"></iframe>

                 </asp:Panel>

                 <asp:Panel ID="pnlEvento"  runat="server" Height="100%">

                     <iframe class="eContent half" src="Evento.aspx"></iframe>
                     <iframe  class="hContent half" src="http://www.dbinfo.it"></iframe>

                 </asp:Panel>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
