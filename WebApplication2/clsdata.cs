using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace WebApplication2
{
    public class clsdata
    {

        //clsdata obj;
        private SqlDatabase testdatabase;

        private int _intmode { get; set; }
        private int _intID { get; set; }
        private string _strName { get; set; }
        private string _strDesignsation { get; set; }
        private int _intSalary { get; set; }
        private string _strAddress { get; set; }
        private int _intphone { get; set; }
        private string _strOutputparameter { get; set; }


        //public clsdata(clsdata obje)
        //{
        //    this.obj = obje;

        //}

        public int intmode
        {
            get
            {
                return _intmode;
            }

            set
            {
                _intmode = value;
            }
        }



        public int intID
        {
            get
            {
                return _intID;
            }

            set
            {
                _intID = value;
            }
        }


        public string strName
        {
            get
            {
                return _strName;
            }

            set
            {
                _strName = value;
            }
        }


        public string strDesignsation
        {
            get
            {
                return _strDesignsation;
            }

            set
            {
                _strDesignsation = value;
            }
        }

        public int intSalary
        {
            get
            {
                return _intSalary;
            }

            set
            {
                _intSalary = value;
            }
        }


        public string strAddress
        {
            get
            {
                return _strAddress;
            }

            set
            {
                _strAddress = value;
            }
        }


        public int intphone
        {
            get
            {
                return _intphone;
            }

            set
            {
                _intphone = value;
            }
        }


        public string strOutputparameter
        {
            get
            {
                return _strOutputparameter;
            }

            set
            {
                _strOutputparameter = value;
            }
        }



        public void function_Add()
        {
            testdatabase = new SqlDatabase(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            testdatabase.CreateConnection();
            System.Data.Common.DbCommand cmd = testdatabase.GetStoredProcCommand("SP_EmpOperations");
            testdatabase.AddInParameter(cmd, "@intmode", DbType.Int32, intmode);
            testdatabase.AddInParameter(cmd, "@intid", DbType.Int32, intID);
            testdatabase.AddInParameter(cmd, "@vchname", DbType.String, strName);
            testdatabase.AddInParameter(cmd, "@vchDesignation", DbType.String, strDesignsation);
            testdatabase.AddInParameter(cmd, "@intsalary", DbType.Int32, intSalary);
            testdatabase.AddInParameter(cmd, "@vchAddress", DbType.String, strAddress);
            testdatabase.AddInParameter(cmd, "@intphno", DbType.Int32, intphone);
            testdatabase.AddOutParameter(cmd, "@vchstatus", DbType.String, 50);
            testdatabase.ExecuteNonQuery(cmd);
        }

        public string function_Get_OutputParameter()
        {
            testdatabase = new SqlDatabase(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            testdatabase.CreateConnection();
            System.Data.Common.DbCommand cmd = testdatabase.GetStoredProcCommand("SP_EmpOperations");
            testdatabase.AddInParameter(cmd, "@intmode", DbType.Int32, intmode);
            testdatabase.AddInParameter(cmd, "@intid", DbType.Int32, intID);
            testdatabase.AddInParameter(cmd, "@vchname", DbType.String, strName);
            testdatabase.AddInParameter(cmd, "@vchDesignation", DbType.String, strDesignsation);
            testdatabase.AddInParameter(cmd, "@intsalary", DbType.Int32, intSalary);
            testdatabase.AddInParameter(cmd, "@vchAddress", DbType.String, strAddress);
            testdatabase.AddInParameter(cmd, "@intphno", DbType.Int32, intphone);
            testdatabase.AddOutParameter(cmd, "@vchstatus", DbType.String, 50);
            testdatabase.ExecuteNonQuery(cmd);
            strOutputparameter = Convert.ToString(testdatabase.GetParameterValue(cmd, "@vchstatus"));
            return (strOutputparameter);
        }

        public DataSet function_BindGrid()
        {

            testdatabase = new SqlDatabase(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            testdatabase.CreateConnection();
            System.Data.Common.DbCommand cmd = testdatabase.GetStoredProcCommand("SP_EmpOperations");
            testdatabase.AddInParameter(cmd, "@intmode", DbType.Int32, intmode);
            testdatabase.AddInParameter(cmd, "@intid", DbType.Int32, intID);
            testdatabase.AddInParameter(cmd, "@vchname", DbType.String, strName);
            testdatabase.AddInParameter(cmd, "@vchDesignation", DbType.String, strDesignsation);
            testdatabase.AddInParameter(cmd, "@intsalary", DbType.Int32, intSalary);
            testdatabase.AddInParameter(cmd, "@vchAddress", DbType.String, strAddress);
            testdatabase.AddInParameter(cmd, "@intphno", DbType.Int32, intphone);
            testdatabase.AddOutParameter(cmd, "@vchstatus", DbType.String, 50);
            DataSet ds = testdatabase.ExecuteDataSet(cmd);
            ds = testdatabase.ExecuteDataSet(cmd);
            return (ds);
        }

    }
}