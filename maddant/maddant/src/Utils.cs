﻿using maddant.src.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maddant.src
{
   
    public static class Utils
    {
        public const string NON_TROVATO = "NON TROVATO";
        public static bool IsEventActive()
        {
            //  return false;


            //if (DateTime.Now.Second %2 ==0)
            //    return true;
            //else
            //{
            //    return false;
            //}

            EVENTOBLL ev = new EVENTOBLL();
            dsmaddant.EVENTODataTable t;
            DateTime dtNow =DateTime.Now;
            
            t = ev.GetEVENTOAttivo(dtNow);
            
            return (t.Rows.Count == 1);

        }

        //restituisce la stringa di connessione per l'accesso ai dati
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["maddantConnectionString"].ConnectionString;
        }

        //permette di gestire gli errori in maniera centralizzata.
        public static string RaiseBllError(string message)
        {
            throw new Exception(message);
        }
    }
}