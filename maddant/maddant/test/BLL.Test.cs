using System;

using NUnit.Framework;
using maddant.src.DAL;
namespace maddant.Test
{
    public class Utils
    {
        

        [Test]
        public void test_EventoWithData()
        {
            EVENTOBLL ev = new EVENTOBLL();
            dsmaddant.EVENTODataTable t;
            t=ev.GetEVENTI();
            Assert.IsTrue(t.Rows.Count > 0);

        }


        [Test]
        public void test_EventoInRange()
        {
            EVENTOBLL ev = new EVENTOBLL();
            dsmaddant.EVENTODataTable t;
            DateTime d;
            DateTime.TryParse("4/2/2021 10:00",out d);
            t = ev.GetEVENTOAttivo(d);
            Assert.IsTrue(t.Rows.Count == 1);

            DateTime.TryParse("4/2/2021 8:01", out d);
            t = ev.GetEVENTOAttivo(d);
            Assert.IsTrue(t.Rows.Count == 1);

            DateTime.TryParse("4/2/2021 16:59", out d);
            t = ev.GetEVENTOAttivo(d);
            Assert.IsTrue(t.Rows.Count == 1);

        }
        [Test]
        public void test_EventoNotInRange()
        {
            EVENTOBLL ev = new EVENTOBLL();
            dsmaddant.EVENTODataTable t;
            DateTime d;
            DateTime.TryParse("4/2/2021 7:59", out d);
            t = ev.GetEVENTOAttivo(d);
            Assert.IsTrue((t is null) || ( t.Rows.Count == 0));


         
            DateTime.TryParse("4/2/2021 17:10", out d);
            t = ev.GetEVENTOAttivo(d);
            Assert.IsTrue((t is null) || (t.Rows.Count == 0));
        }

        [Test]
        public void test_EventoCompleto()
        {
            int numev;
            int id_az;
            int[] id_dip=new int[2];
            int id_ev;

            EVENTOBLL ev = new EVENTOBLL();
            dsmaddant.EVENTODataTable t;
            t = ev.GetEVENTI();
            numev = t.Rows.Count;

            AZIENDABLL az = new AZIENDABLL();
            id_az=az.AddAZIENDA(0, "Fornitore s.r.l");
            Assert.IsTrue(id_az > 0);

            DIPENDENTIBLL di = new DIPENDENTIBLL();
            id_dip[0] = di.AddDIPENDENTI(0, id_az, "Dipendente 1");
            id_dip[1] = di.AddDIPENDENTI(0, id_az, "Dipendente 2");
            Assert.IsTrue(id_dip[0] > 0);
            Assert.IsTrue(id_dip[1] > id_dip[0]);

            id_ev = ev.AddEVENTO(0, id_az, DateTime.Now.Date, new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0));
            Assert.IsTrue(id_ev > 0);


            EVENTO_PARTECIPANTIBLL ep = new EVENTO_PARTECIPANTIBLL();
            ep.AddEVENTO_PARTECIPANTI(id_ev, id_dip[0]);
            ep.AddEVENTO_PARTECIPANTI(id_ev, id_dip[1]);

            t = ev.GetEVENTI();// legge il numero di eventi per verificare che sia aumentato di 1

            Assert.AreEqual(t.Rows.Count ,numev+1);
        }

    }
}
