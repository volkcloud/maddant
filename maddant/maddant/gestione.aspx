<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gestione.aspx.cs" Inherits="maddant.gestione1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    

  <div class="container">

      <div class="row">
          
          <div class="col-sm-12">
            <h2>titolo</h2>
          </div>
      
      </div><%--row--%>


      <div class="row">
         <div class="col-sm-12">
             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
         </div>
      </div>  

     <div class="row">
         
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
               
                <asp:Button   class="btn btn-primary" ID="btnCrea" runat="server" Text="Crea" OnClientClick="save();return false;"   />
               
           </div>      
      </div><%--row--%>

  </div><%--container--%>


    <script  type="text/javascript">
        function pUpdate() {
            if ($("#pname").val() != null &&
                $("#pname").val() != '') {
                // Add product to Table
                pAddToTable();

                // Clear form fields
                formClear();

                // Focus to product name field
                $("#pname").focus();
            }
        }

        
        function pAddToTable() {
      
            if ($("#MainContent_tblP tbody").length == 0) {
                $("#MainContent_tblP").append("<tbody></tbody>");
            }

            
            $("#MainContent_tblP tbody").append(
                "<tr>" +
                "<td>" + $("#pname").val() + "</td>" +
                "<td>" +
                "<button type='button' " +
                "onclick='pDelete(this);' " +
                "class='btn btn-default'>" +
                "<span class='glyphicon glyphicon-remove' />" +
                "</button>" +
                "</td>" +
                "</tr>"
            );
        }

        // Clear form fields
        function formClear() {
            $("#pname").val("");
           
        }

        // Delete product from <table>
        function pDelete(ctl) {
            $(ctl).parents("tr").remove();
        }


        function save() {
            var ev = {};
            ev.descrizione = 'bla';
          
            $.ajax({
                url: "/api/Eventi/",
                type: 'POST',
                dataType: 'json',
                contentType:
                    "application/json;charset=utf-8",
                data:ev,
                success: function () {
                    alert('ok');
                },
                error: function (request, message, error) {
                   alert(message);
                }
            });
        }
    </script>
</asp:Content>
