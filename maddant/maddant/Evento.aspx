<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Evento.aspx.cs" Inherits="maddant.Evento" %>
<link href="Content/bootstrap.min.css" rel="stylesheet" />

    <link href="Content/Site.css" rel="stylesheet" />

    <form id="form1" runat="server">

          <div class="container-fluid" style="max-width: none;">
                <div class="container-fluid-side">
                       <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" OnItemDataBound="Repeater1_ItemDataBound">
                         <HeaderTemplate>
                
                                    <div class="list-group">
                                      <a href="#" class="list-group-item list-group-item-action active">
                                        Partecipanti
                                      </a>
                          </HeaderTemplate>
                            <ItemTemplate>
                
                                <a href="#" class="list-group-item list-group-item-action"><%# Eval("D_NOMECOGN") %></a>
                            </ItemTemplate>   
                            <FooterTemplate>

                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                            
                </div><%--side--%>

                <div class="container-fluid-body">
           
                 <div class="nocontainer">

                          <div class="norow">
                  
                              <div class="col-sm-12">
                               <asp:Label ID="lblAz" runat="server" Text="."  style="font-size: 50px;"></asp:Label>
                              </div>
                            
      
                          </div><%--row azienda --%>



                          <div class="norow">
                              <div class="col-sm-12">
                                  <div id="MyClockDisplay" class="clock" onload="showTime()">

                                  </div>

                             </div>
                         </div> <%--row clock--%>
                    </div> <%--container--%>      


                </div><%--body--%>

        </div><%--container-fluid--%>


        


        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:maddantConnectionString %>" SelectCommand="SELECT DIPENDENTI.*, EVENTO_PARTECIPANTI.E_ID FROM EVENTO_PARTECIPANTI INNER JOIN DIPENDENTI ON EVENTO_PARTECIPANTI.D_ID = DIPENDENTI.D_ID WHERE (EVENTO_PARTECIPANTI.E_ID = @e_id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="edEvID" DefaultValue="0" Name="e_id" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:TextBox ID="edEvID" runat="server" Visible="False"></asp:TextBox>

       




        <script type="text/javascript">

            function showTime() {
                var date = new Date();
                var h = date.getHours(); // 0 - 23
                var m = date.getMinutes(); // 0 - 59
                var s = date.getSeconds(); // 0 - 59
                var session = "";

                //if (h == 0) {
                //    h = 12;
                //}

                //if (h > 12) {
                //    h = h - 12;
                //    session = "PM";
                //}

                h = (h < 10) ? "0" + h : h;
                m = (m < 10) ? "0" + m : m;
                s = (s < 10) ? "0" + s : s;

                var time = h + ":" + m + ":" + s + " " + session;
                document.getElementById("MyClockDisplay").innerText = time;
                document.getElementById("MyClockDisplay").textContent = time;

                setTimeout(showTime, 1000);

            }

            showTime();

        </script>

    </form>

