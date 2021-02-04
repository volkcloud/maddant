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
            t=ev.GetEVENTO();
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

    }
}
