// --AL(lol):210204:Classe di gestione tabella AZIENDA
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
public class AZIENDABLL
{
    private maddant.src.DAL.dsmaddantTableAdapters.AZIENDATableAdapter _Adapter = null;
    protected maddant.src.DAL.dsmaddantTableAdapters.AZIENDATableAdapter Adapter
    {
        get
        {
            if (_Adapter == null)
            {
                _Adapter = new maddant.src.DAL.dsmaddantTableAdapters.AZIENDATableAdapter();
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


    // --leal:210204:Selezione di record 
    // per la tabella AZIENDA 

    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
    public maddant.src.DAL.dsmaddant.AZIENDADataTable GetAZIENDE()
    {
        return Adapter.GetData();
    }



    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, false)]
    public maddant.src.DAL.dsmaddant.AZIENDADataTable GetAZIENDAByID(int A_ID
        )
    {
        return Adapter.GetAZIENDAByID(A_ID);
    }



    // --leal:210204:inserimento di 1 record 
    // per la tabella AZIENDA 
    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public int AddAZIENDA(int A_ID, string A_RAGSOC)
    {
        int rowsAffected = 0;
        if (A_ID <= 0)
            A_ID = GetLastID() + 1;
        maddant.src.DAL.dsmaddant.AZIENDADataTable TAZIENDA = new maddant.src.DAL.dsmaddant.AZIENDADataTable();
        maddant.src.DAL.dsmaddant.AZIENDARow ObjRow = TAZIENDA.NewAZIENDARow();

        {
            var withBlock = ObjRow;
            withBlock.A_ID = A_ID;
            withBlock.A_RAGSOC = A_RAGSOC;
        }
        TAZIENDA.AddAZIENDARow(ObjRow);
        try
        {
            rowsAffected = Adapter.Update(TAZIENDA);
        }
       
        catch (Exception ex)
        {
            Utils.RaiseBllError( ex.Message);
        }
        return A_ID;
    }


    //// --leal:210204:aggiornamento di record 
    //// per la tabella AZIENDA  secondo la chiave primaria

    //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
    //public int UpdAZIENDA(string AZIENDATS, int Original_A_ID, string A_RAGSOC)
    //{
    //    dsmaddant.AZIENDADataTable TAZIENDA = Adapter.GetAZIENDAByID(Original_A_ID);

    //    if (TAZIENDA.Count == 0)
    //        // nessun risultato, ritorno false
    //        raiseBllError(BLL_RESULT_CODE.KEY_NOT_FOUND_ON_UPDATE);
    //    // Dim TS_old As String = Adapter.GetAZIENDATS(Original_A_ID)
    //    // If AZIENDATS = TS_old Then
    //    // stesso ts e quindi posso procedere
    //    dsmaddant.AZIENDARow ObjRow = TAZIENDA(0);
    //    {
    //        var withBlock = ObjRow;
    //        withBlock.A_RAGSOC = A_RAGSOC;
    //    }
    //    int rowsAffected;
    //    try
    //    {
    //        rowsAffected = Adapter.Update(TAZIENDA);
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
    // per la tabella AZIENDA  secondo la chiave primaria

    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public int DelAZIENDAByID( int Original_A_ID
        )
    {

        maddant.src.DAL.dsmaddant.AZIENDADataTable DTAZIENDA = Adapter.GetAZIENDAByID(Original_A_ID);
        if (DTAZIENDA.Count == 0)
            // nessun risultato, ritorno false
            Utils.RaiseBllError(Utils.NON_TROVATO);
        maddant.src.DAL.dsmaddant.AZIENDARow ObjRow = DTAZIENDA[0];
       
        int rowsAffected;

        try
        {
            rowsAffected = Adapter.Delete(Original_A_ID);
        }
       
        catch (Exception ex)
        {
            Utils.RaiseBllError( ex.Message);
        }
        return 0;
    }
}
