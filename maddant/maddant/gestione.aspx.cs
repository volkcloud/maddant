using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maddant
{
    public partial class gestione1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // edData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //        <asp:LinkButton CssClass="glyphicon glyphicon-remove" ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Elimina" OnClientClick="if (typeof alertify !== 'undefined') {document.getElementById('MainContent_edelimina').value='N';alertify.confirm('-', 'Eliminare', function(){ document.getElementById('MainContent_edelimina').value='S' ;},function(){  });return (document.getElementById('MainContent_edelimina').value=='S');}else {return confirm('Eliminare?');} "></asp:LinkButton>

            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
        }


        //protected void btnCrea_Click(object sender, EventArgs e)
        //{
        //    foreach (TableRow x in tblP.Rows)
        //    {
        //        x.FindControl("");
        //    }
        //    Console.WriteLine(TextBox1.Text);

        //}


    }
}