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
          <div class="col-sm-7">
            <asp:TextBox ValidationGroup="part"  CssClass="form-control" ID="edPartecipante" runat="server" Width="120px"></asp:TextBox>

          </div>  
          <div class="col-sm-1">
             <asp:RequiredFieldValidator ValidationGroup="part" ID="RequiredFieldValidator3" runat="server" ControlToValidate="edPartecipante" CssClass="errorMsg" ErrorMessage="*"></asp:RequiredFieldValidator>
          </div>  
          <div class="col-sm-1">
              <asp:Button  OnClientClick="pUpdate();return false;" class="btn btn-primary" ID="btnPart" runat="server" Text="Agg."   ValidationGroup="part" />

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
          
           <div class="col-sm-12">
                
                <asp:Table ID="tblP" runat="server" EnableViewState="true"  class="table table-bordered table-condensed table-striped">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>Nome</asp:TableHeaderCell>
                        <asp:TableHeaderCell>X</asp:TableHeaderCell>
                    </asp:TableHeaderRow>

                 </asp:Table>

            </div>      
      </div><%--container--%>


        <div class="row">
          
           <div class="col-sm-12">
               
                <asp:Button  OnClientClick="save();return false;" class="btn btn-primary" ID="btnCrea" runat="server" Text="Crea"   ValidationGroup="crea" />
               
           </div>      
      </div><%--row--%>

  </div><%--container--%>


    <script src="Scripts/formgestione.js"></script>
</asp:Content>
