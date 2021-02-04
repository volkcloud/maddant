// --AL(lol):210204:Classe di gestione tabella DIPENDENTI
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
public class DIPENDENTIBLL
{
    private maddant.src.DAL.dsmaddantTableAdapters.DIPENDENTITableAdapter _Adapter = null;
    protected maddant.src.DAL.dsmaddantTableAdapters.DIPENDENTITableAdapter Adapter
    {
        get
        {
            if (_Adapter == null)
            {
                _Adapter = new maddant.src.DAL.dsmaddantTableAdapters.DIPENDENTITableAdapter();
                _Adapter.Connection.ConnectionString = Utils.GetConnectionString();
            }
            return _Adapter;
        }
    }


    // --leal:210204:Selezione di record 
    // per la tabella DIPENDENTI 

    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
    public maddant.src.DAL.dsmaddant.DIPENDENTIDataTable GetDIPENDENTI()
    {
        return Adapter.GetData();
    }



    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, false)]
    public maddant.src.DAL.dsmaddant.DIPENDENTIDataTable GetDIPENDENTIByID(int D_ID
        )
    {
        return Adapter.GetDIPENDENTIByID(D_ID);
    }



    // --leal:210204:inserimento di 1 record 
    // per la tabella DIPENDENTI 
    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public int AddDIPENDENTI(int D_ID, int A_ID, string D_NOMECOGN)
    {
        int rowsAffected = 0;


        maddant.src.DAL.dsmaddant.DIPENDENTIDataTable TDIPENDENTI = new maddant.src.DAL.dsmaddant.DIPENDENTIDataTable();
        maddant.src.DAL.dsmaddant.DIPENDENTIRow ObjRow = TDIPENDENTI.NewDIPENDENTIRow();

        {
            var withBlock = ObjRow;
            withBlock.D_ID = D_ID;
            withBlock.A_ID = A_ID;
            withBlock.D_NOMECOGN = D_NOMECOGN;
        }
        TDIPENDENTI.AddDIPENDENTIRow(ObjRow);
        try
        {
            rowsAffected = Adapter.Update(TDIPENDENTI);
        }
       
        catch (Exception ex)
        {
            Utils.RaiseBllError( ex.Message);
        }
        return 0;
    }


    //// --leal:210204:aggiornamento di record 
    //// per la tabella DIPENDENTI  secondo la chiave primaria

    //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
    //public int UpdDIPENDENTI( int Original_D_ID, int A_ID, string D_NOMECOGN)
    //{
    //    dsmaddant.DIPENDENTIDataTable TDIPENDENTI = Adapter.GetDIPENDENTIByID(Original_D_ID);

    //    if (TDIPENDENTI.Count == 0)
    //        // nessun risultato, ritorno false
    //        raiseBllError(BLL_RESULT_CODE.KEY_NOT_FOUND_ON_UPDATE);
    //    // Dim TS_old As String = Adapter.GetDIPENDENTITS(Original_D_ID)
    //    // If DIPENDENTITS = TS_old Then
    //    // stesso ts e quindi posso procedere
    //    dsmaddant.DIPENDENTIRow ObjRow = TDIPENDENTI(0);
    //    {
    //        var withBlock = ObjRow;
    //        withBlock.A_ID = A_ID;
    //        withBlock.D_NOMECOGN = D_NOMECOGN;
    //    }
    //    int rowsAffected;
    //    try
    //    {
    //        rowsAffected = Adapter.Update(TDIPENDENTI);
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
    // per la tabella DIPENDENTI  secondo la chiave primaria

    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public int DelDIPENDENTIByID( int Original_D_ID
        )
    {
      
        maddant.src.DAL.dsmaddant.DIPENDENTIDataTable DTDIPENDENTI = Adapter.GetDIPENDENTIByID(Original_D_ID);
        if (DTDIPENDENTI.Count == 0)
            // nessun risultato, ritorno false
            Utils.RaiseBllError(Utils.NON_TROVATO);
        maddant.src.DAL.dsmaddant.DIPENDENTIRow ObjRow = DTDIPENDENTI[0];
        
        int rowsAffected;

        try
        {
            rowsAffected = Adapter.Delete(Original_D_ID);
        }
        
        catch (Exception ex)
        {
            Utils.RaiseBllError( ex.Message);
        }
        return 0;
    }
}
