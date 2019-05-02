using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace RemaxApplication
{
    static class clsGlobal
    {
        public static OleDbConnection myCon;
        public static OleDbDataAdapter adpHouses, adpTypes, adpRegions, adpAgents;
        public static DataSet mySet;
        public static DataTable tabHouses, tabAgents;
    }
}