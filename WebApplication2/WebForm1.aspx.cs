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
using System.Web.Services;
using Newtonsoft.Json;
namespace WebApplication2
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        //clsdata objclsdata = new clsdata();

       
        [WebMethod]
        public static void function_Add(clsdata objclsdata)
        {
            objclsdata.function_Add();

        }
        
        [WebMethod]
        public static string function_View_OutputParameter(clsdata objclsdata)
        {
            return objclsdata.function_Get_OutputParameter();
        }

        [WebMethod]
        public static string function_GridView(clsdata objclsdata)
        {
            return JsonConvert.SerializeObject(objclsdata.function_BindGrid());
        }


    }
}