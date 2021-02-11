using maddant.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maddant
{
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //carica impostazioni(intervallo timer)

                manageFields();

                Int32 intSec = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["sec_refresh"]);
                tmrLive.Interval = intSec * 1000;
            }

        }

        protected void tmrLive_Tick(object sender, EventArgs e)
        {
           // Label1.Text = DateTime.Now.ToString("HH:mm:ss");
            manageFields();

        }

        private void manageFields()
        {
            if (Utils.IsEventActive())
            {
                //visualizzazione pagina "Evento"

                pnlEvento.Visible = true;
            }
            else
            {
                //visualizzazione pagina "Normale"

                pnlEvento.Visible = false;
            }
            pnlNormale.Visible = !pnlEvento.Visible;
        }
    }
}