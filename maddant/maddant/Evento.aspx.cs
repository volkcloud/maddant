using maddant.src.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maddant
{
    public partial class Evento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EVENTOBLL ev = new EVENTOBLL();
                dsmaddant.EVENTODataTable tev;
                DateTime dtNow = DateTime.Now;

                tev = ev.GetEVENTOAttivo(dtNow);

                if (tev.Rows.Count > 0)
                {
                    AZIENDABLL az = new AZIENDABLL();
                    edEvID.Text = tev.Rows[0]["E_ID"].ToString();
                    lblAz.Text = az.GetAZIENDAByID(Convert.ToInt32(tev.Rows[0]["A_ID"])).Rows[0]["A_RAGSOC"].ToString();


                    Repeater1.DataBind();
                }
            }

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (Repeater1.Items.Count < 1)
            {
                Repeater1.Visible = false;
            }
            else
            { 
                Repeater1.Visible = true;

            }
        }
    }
}