<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gestione.aspx.cs" Inherits="maddant.gestione1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .errorMsg {
        color: #f00;
        font-size:medium;
       
        }

    </style>

  <div class="container">

      <div class="row">
          
          <div class="col-sm-12">
            <h2>Evento</h2>
          </div>
      
      </div><%--row--%>

      <div class="row">
         <div class="col-sm-3">
           <asp:Label CssClass="col-form-label" ID="Label1" runat="server" Text="Azienda"></asp:Label>
         </div>
          <div class="col-sm-1">
          <asp:RequiredFieldValidator ValidationGroup="crea"  ID="RequiredFieldValidator1" runat="server" ControlToValidate="edAzienda" CssClass="errorMsg" ErrorMessage="*"></asp:RequiredFieldValidator>
             
      
         </div>
         <div class="col-sm-8">
             <asp:TextBox ValidationGroup="crea"  CssClass="form-control"  ID="edAzienda" runat="server" Width="400px"></asp:TextBox>
             
               
             
         </div>
      </div>  



       <div class="row">
         <div class="col-sm-3">
           <asp:Label CssClass="control-label" ID="Label2" runat="server" Text="Data"></asp:Label>
         </div>
         <div class="col-sm-1">
             <asp:RequiredFieldValidator ValidationGroup="crea" ID="RequiredFieldValidator2" runat="server" ControlToValidate="edData" CssClass="errorMsg" ErrorMessage="*"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ValidationGroup="crea" ID="RegularExpressionValidator1" runat="server" ControlToValidate="edData" CssClass="errorMsg" ErrorMessage="*" ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$"></asp:RegularExpressionValidator>

         </div>
         <div class="col-sm-8">
            <asp:TextBox ValidationGroup="crea"  CssClass="form-control" ID="edData" runat="server" Width="120px"></asp:TextBox>
          </div>
      </div>  




     <div class="row">
          <div class="col-sm-3">
           <asp:Label CssClass="control-label" ID="Label3" runat="server" Text="Partecipante"></asp:Label>

          </div>    
         <div class="col-sm-1">
             <asp:RequiredFieldValidator ValidationGroup="part" ID="RequiredFieldValidator3" runat="server" ControlToValidate="edPartecipante" CssClass="errorMsg" ErrorMessage="*"></asp:RequiredFieldValidator>
          </div>  
          <div class="col-sm-7">
            <asp:TextBox ValidationGroup="part"  CssClass="form-control" ID="edPartecipante" runat="server" Width="400px"></asp:TextBox>

          </div>  
      
          <div class="col-sm-1">
              <asp:Button  OnClientClick="return pUpdate();" class="btn btn-primary" ID="btnPart" runat="server" Text="Agg."   ValidationGroup="part" />

          </div>           
<%--  
      <div class="col-sm-12">
        <div class="panel panel-primary">
          <div class="panel-heading">
            Par
          </div>
          <div class="panel-body">
            <div class="form-group">
              <label for="pname">
                Nome
              </label>
              <input type="text"
                     class="form-control"
                     value=""
                     id="pname" />

               <button type="button" id="updateButton"
                        class="btn btn-primary"
                        onclick="pUpdate();">
                  Aggiungi
                </button>
            </div>
           
          </div>
          
        </div>
      </div>
         --%>
    </div><%--row--%>



      <div class="row">
           <div class="col-sm-1">
           </div>
          
           <div class="col-sm-10">
                
                <asp:Table ID="tblP" runat="server" EnableViewState="true"  class="table table-bordered table-condensed table-striped">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell Width="80%">Nome</asp:TableHeaderCell>
                        <asp:TableHeaderCell>X</asp:TableHeaderCell>
                    </asp:TableHeaderRow>

                 </asp:Table>

            </div>  
          
           <div class="col-sm-1">
           </div>
      </div><%--container--%>


        <div class="row">
          
           <div class="col-sm-12">
               
                <asp:Button  OnClientClick="return save();" class="btn btn-primary" ID="btnCrea" runat="server" Text="Crea"   ValidationGroup="crea" />
               
           </div>      
      </div><%--row--%>


      <div class="row">
          <div class="col-sm-12">
               <h2>Prossimi eventi</h2> 
           </div>      
      </div><%--row--%>

      <div class="row">
          <div class="col-sm-12">
              <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DelEVENTOByID" InsertMethod="AddEVENTO" OldValuesParameterFormatString="original_{0}" SelectMethod="GetEVENTIFuturi" TypeName="EVENTOBLL">
                  <DeleteParameters>
                      <asp:Parameter Name="Original_E_ID" Type="Int32" />
                  </DeleteParameters>
                  <InsertParameters>
                      <asp:Parameter Name="E_ID" Type="Int32" />
                      <asp:Parameter Name="A_ID" Type="Int32" />
                      <asp:Parameter Name="E_DATA" Type="DateTime" />
                      <asp:Parameter DbType="Time" Name="E_ORAI" />
                      <asp:Parameter DbType="Time" Name="E_ORAF" />
                  </InsertParameters>
              </asp:ObjectDataSource>
              <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:maddantConnectionString %>" DeleteCommand="DELETE FROM EVENTO WHERE (E_ID = @e_id)" SelectCommand="SELECT EVENTO.E_ID, EVENTO.A_ID, EVENTO.E_DATA, EVENTO.E_ORAI, EVENTO.E_ORAF, AZIENDA.A_RAGSOC FROM EVENTO INNER JOIN AZIENDA ON EVENTO.A_ID = AZIENDA.A_ID WHERE (EVENTO.E_DATA = CONVERT (date, GETDATE())) AND (EVENTO.E_ORAF &gt;= CONVERT (time, GETDATE())) OR (EVENTO.E_DATA &gt; CONVERT (date, GETDATE())) ORDER BY EVENTO.E_DATA DESC">
                  <DeleteParameters>
                      <asp:Parameter Name="e_id" />
                  </DeleteParameters>
              </asp:SqlDataSource>
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="E_ID" DataSourceID="SqlDataSource1" OnRowCreated="GridView1_RowCreated" Width="400px">
                  <Columns>
                      <asp:TemplateField ShowHeader="False">
                          <ItemTemplate>
                              <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Elimina" OnClientClick="return confirm('Eliminare?'); "></asp:LinkButton>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField DataField="E_ID" HeaderText="E_ID" SortExpression="E_ID" ReadOnly="True" Visible="False" />
                      <asp:BoundField DataField="E_DATA" DataFormatString="{0:d}" HeaderText="Data" SortExpression="E_DATA" />

                      <asp:BoundField DataField="A_RAGSOC" HeaderText="Azienda" />

                  </Columns>
              </asp:GridView>
          </div>      
      </div><%--row--%>


  </div><%--container--%>
   


    <script src="Scripts/formgestione.js"></script>
   
    <script>
        window.onload = function(){
            formClear();
        }

    </script>
</asp:Content>
