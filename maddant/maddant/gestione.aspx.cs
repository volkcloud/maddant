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
            }
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