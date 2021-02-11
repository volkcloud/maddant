// --AL(lol):210204:Classe di gestione tabella EVENTO
// -------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using maddant.src;
using Microsoft.VisualBasic;

[System.ComponentModel.DataObject()]
public class EVENTOBLL
{
    private maddant.src.DAL.dsmaddantTableAdapters.EVENTOTableAdapter _Adapter = null/* TODO Change to default(_) if this is not a reference type */;
    protected maddant.src.DAL.dsmaddantTableAdapters.EVENTOTableAdapter Adapter
    {
        get
        {
            if (_Adapter == null)
            {
                _Adapter = new maddant.src.DAL.dsmaddantTableAdapters.EVENTOTableAdapter();
                _Adapter.Connection.ConnectionString = Utils.GetConnectionString();
            }
            return _Adapter;
        }
    }

    //ritorna l'ultimo progressivo in tabella oppure 0
    public int GetLastID()
    {
        Nullable<int> lngRes;
        lngRes = Adapter.GetLastId();
        if (!lngRes.HasValue)
            lngRes = 0;
        return lngRes.Value;
    }


  
    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
    public maddant.src.DAL.dsmaddant.EVENTODataTable GetEVENTI()
    {
        return Adapter.GetData();
    }

    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
    public maddant.src.DAL.dsmaddant.EVENTODataTable GetEVENTIFuturi()
    {
        return Adapter.GetEventiFuturi(DateTime.Now);
    }

    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
    public maddant.src.DAL.dsmaddant.EVENTODataTable GetEVENTOAttivo(DateTime dataOra)
    {
        return Adapter.GetEventoAttivo(dataOra);
    }

    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, false)]
    public maddant.src.DAL.dsmaddant.EVENTODataTable GetEVENTOByID(int E_ID
        )
    {
        return Adapter.GetEVENTOByID(E_ID);
    }


    // --leal:210204:inserimento di 1 record 
    // per la tabella EVENTO 
    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public int AddEVENTO(int E_ID, int A_ID, DateTime E_DATA, TimeSpan E_ORAI, TimeSpan E_ORAF)
    {

        if (E_DATA < DateTime.Now.Date)
        {
            throw new Exception("Non è permesso inserire evento nel passato");

        }

        // blocca eventi in data già presente
        maddant.src.DAL.dsmaddant.EVENTODataTable TEVENTOaltro = Adapter.GetEventoByData(E_DATA);
        if (TEVENTOaltro.Count > 0)
        {
            throw new Exception("Un evento è già pianificato per la data");

        }

        int rowsAffected = 0;
        if (E_ID <= 0)
            E_ID = GetLastID() + 1;
        maddant.src.DAL.dsmaddant.EVENTODataTable TEVENTO = new maddant.src.DAL.dsmaddant.EVENTODataTable();
        maddant.src.DAL.dsmaddant.EVENTORow ObjRow = TEVENTO.NewEVENTORow();

        {
            var withBlock = ObjRow;
            withBlock.E_ID = E_ID;
            withBlock.A_ID = A_ID;
            withBlock.E_DATA = E_DATA;
            withBlock.E_ORAI = E_ORAI;
            withBlock.E_ORAF = E_ORAF;
        }
        TEVENTO.AddEVENTORow(ObjRow);
        try
        {
            rowsAffected = Adapter.Update(TEVENTO);
        }
       
        catch (Exception ex)
        {
            Utils.RaiseBllError( ex.Message);
        }
        return E_ID;
    }


    //// --leal:210204:aggiornamento di record 
    //// per la tabella EVENTO  secondo la chiave primaria

    //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
    //public int UpdEVENTO(string EVENTOTS, int Original_E_ID, int A_ID, string E_DATA, string E_ORAI, string E_ORAF)
    //{
    //    dsmaddant.EVENTODataTable TEVENTO = Adapter.GetEVENTOByID(Original_E_ID);

    //    if (TEVENTO.Count == 0)
    //        // nessun risultato, ritorno false
    //        raiseBllError(BLL_RESULT_CODE.KEY_NOT_FOUND_ON_UPDATE);
    //    // Dim TS_old As String = Adapter.GetEVENTOTS(Original_E_ID)
    //    // If EVENTOTS = TS_old Then
    //    // stesso ts e quindi posso procedere
    //    dsmaddant.EVENTORow ObjRow = TEVENTO(0);
    //    {
    //        var withBlock = ObjRow;
    //        withBlock.A_ID = A_ID;
    //        withBlock.E_DATA = E_DATA;
    //        withBlock.E_ORAI = E_ORAI;
    //        withBlock.E_ORAF = E_ORAF;
    //    }
    //    int rowsAffected;
    //    try
    //    {
    //        rowsAffected = Adapter.Update(TEVENTO);
    //    }
    //    catch (Data.SqlClient.SqlException ex)
    //    {
    //        raiseBllError(ex.ErrorCode, ex.Message);
    //    }
    //    catch (Exception ex)
    //    {
    //        raiseBllError(BLL_RESULT_CODE.GENERIC_EXCEPTION, ex.Message);
    //    }
    //    return BLL_RETURN_CODE.OK; // se ci sono errori viene generata una exception
    //}


    // --leal:210204:cancellazione di record 
    // per la tabella EVENTO  secondo la chiave primaria

    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public int DelEVENTOByID( int Original_E_ID
        )
    {
       
        maddant.src.DAL.dsmaddant.EVENTODataTable DTEVENTO = Adapter.GetEVENTOByID(Original_E_ID);
        if (DTEVENTO.Count == 0)
            // nessun risultato, ritorno false
            Utils.RaiseBllError(Utils.NON_TROVATO);
        maddant.src.DAL.dsmaddant.EVENTORow ObjRow = DTEVENTO[0];
       
        int rowsAffected;

        try
        {
            rowsAffected = Adapter.Delete(Original_E_ID);
        }
        
        catch (Exception ex)
        {
            Utils.RaiseBllError( ex.Message);
        }
        return 0;
    }
}
