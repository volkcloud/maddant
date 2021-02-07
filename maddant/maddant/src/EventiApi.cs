using maddant.src.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Transactions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace maddant.src
{
    
     public class EventiController : ApiController
    {
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "proVA", "test" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "??";
        //}

        [HttpPost]
        // POST api/<controller>
        //public void Post([FromBody] string value)
        public void Post(JObject eventoCompleto )
        {

            int numev;
            int id_az;
            int id_dip;
            int id_ev;
        
            using (TransactionScope scope = new TransactionScope())
            {
                EVENTOBLL ev = new EVENTOBLL();
                //dsmaddant.EVENTODataTable t;
                //t = ev.GetEVENTI();
                //numev = t.Rows.Count;
              
 
                AZIENDABLL az = new AZIENDABLL();
                id_az = az.AddAZIENDA(0,  eventoCompleto["azienda"].ToString());
                if (id_az <= 0)
                {
                    return;
                }

                
                id_ev = ev.AddEVENTO(0, id_az, DateTime.Now.Date, new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0));
                if (id_ev <= 0)
                {
                    return;
                }

                EVENTO_PARTECIPANTIBLL ep = new EVENTO_PARTECIPANTIBLL();

                foreach (var p in eventoCompleto["partecipanti"]["partecipanti"])
                {
                    DIPENDENTIBLL di = new DIPENDENTIBLL();
                    id_dip = di.AddDIPENDENTI(0, id_az, p["nome"].ToString());
                    if (id_dip <= 0)
                    {
                        return;
                    }
                    ep.AddEVENTO_PARTECIPANTI(id_ev, id_dip);
                }

                   

                scope.Complete();
            }
        }

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}