// --AL(lol):210204:Classe di gestione tabella EVENTO_PARTECIPANTI
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
public class EVENTO_PARTECIPANTIBLL
{
    private maddant.src.DAL.dsmaddantTableAdapters.EVENTO_PARTECIPANTITableAdapter _Adapter = null;
    protected maddant.src.DAL.dsmaddantTableAdapters.EVENTO_PARTECIPANTITableAdapter Adapter
    {
        get
        {
            if (_Adapter == null)
            {
                _Adapter = new maddant.src.DAL.dsmaddantTableAdapters.EVENTO_PARTECIPANTITableAdapter();
                _Adapter.Connection.ConnectionString = Utils.GetConnectionString();
            }
            return _Adapter;
        }
    }


    //// --leal:210204:Selezione di record 
    //// per la tabella EVENTO_PARTECIPANTI 

    //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
    //public maddant.src.DAL.dsmaddant.EVENTO_PARTECIPANTIDataTable GetEVENTO_PARTECIPANTI()
    //{
    //    return Adapter.GetData();
    //}



    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, false)]
    public maddant.src.DAL.dsmaddant.EVENTO_PARTECIPANTIDataTable GetEVENTO_PARTECIPANTIByID(int E_ID, int D_ID
        )
    {
        return Adapter.GetEVENTO_PARTECIPANTIByID(E_ID, D_ID);
    }

    


    // --leal:210204:inserimento di 1 record 
    // per la tabella EVENTO_PARTECIPANTI 
    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public int AddEVENTO_PARTECIPANTI(int E_ID, int D_ID)
    {
        int rowsAffected = 0;

        maddant.src.DAL.dsmaddant.EVENTO_PARTECIPANTIDataTable TEVENTO_PARTECIPANTI = new maddant.src.DAL.dsmaddant.EVENTO_PARTECIPANTIDataTable();
        maddant.src.DAL.dsmaddant.EVENTO_PARTECIPANTIRow ObjRow = TEVENTO_PARTECIPANTI.NewEVENTO_PARTECIPANTIRow();

        {
            var withBlock = ObjRow;
            withBlock.E_ID = E_ID;
            withBlock.D_ID = D_ID;
        }
        TEVENTO_PARTECIPANTI.AddEVENTO_PARTECIPANTIRow(ObjRow);
        try
        {
            rowsAffected = Adapter.Update(TEVENTO_PARTECIPANTI);
        }
       
        catch (Exception ex)
        {
           Utils.RaiseBllError(ex.Message);
        }
        return 0;
    }


    //// --leal:210204:aggiornamento di record 
    //// per la tabella EVENTO_PARTECIPANTI  secondo la chiave primaria

    //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
    //public int UpdEVENTO_PARTECIPANTI(string EVENTO_PARTECIPANTITS, int Original_E_ID, int Original_D_ID)
    //{
    //    dsmaddant.EVENTO_PARTECIPANTIDataTable TEVENTO_PARTECIPANTI = Adapter.GetEVENTO_PARTECIPANTIByID(Original_E_ID, Original_D_ID);

    //    if (TEVENTO_PARTECIPANTI.Count == 0)
    //        // nessun risultato, ritorno false
    //        raiseBllError(BLL_RESULT_CODE.KEY_NOT_FOUND_ON_UPDATE);
    //    // Dim TS_old As String = Adapter.GetEVENTO_PARTECIPANTITS(Original_E_ID, Original_D_ID)
    //    // If EVENTO_PARTECIPANTITS = TS_old Then
    //    // stesso ts e quindi posso procedere
    //    dsmaddant.EVENTO_PARTECIPANTIRow ObjRow = TEVENTO_PARTECIPANTI(0);
    //    {
    //        var withBlock = ObjRow;
    //    }
    //    int rowsAffected;
    //    try
    //    {
    //        rowsAffected = Adapter.Update(TEVENTO_PARTECIPANTI);
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
    // per la tabella EVENTO_PARTECIPANTI  secondo la chiave primaria

    [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public int DelEVENTO_PARTECIPANTIByID( int Original_E_ID, int Original_D_ID
        )
    {

        maddant.src.DAL.dsmaddant.EVENTO_PARTECIPANTIDataTable DTEVENTO_PARTECIPANTI = Adapter.GetEVENTO_PARTECIPANTIByID(Original_E_ID, Original_D_ID);
        if (DTEVENTO_PARTECIPANTI.Count == 0)
            // nessun risultato, ritorno false
            Utils.RaiseBllError(Utils.NON_TROVATO);
        maddant.src.DAL.dsmaddant.EVENTO_PARTECIPANTIRow ObjRow = DTEVENTO_PARTECIPANTI[0];
        
        int rowsAffected;

        try
        {
            rowsAffected = Adapter.Delete(Original_E_ID, Original_D_ID);
        }
        
        catch (Exception ex)
        {
            Utils.RaiseBllError( ex.Message);
        }
        return 0;
    }
}
