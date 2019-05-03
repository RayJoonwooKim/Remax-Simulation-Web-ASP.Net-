using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
namespace RemaxApplication
{
    public partial class MessageToAgent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int refA = Convert.ToInt32(Request.QueryString["RefA"]);
            Session["RefAgent"] = refA;
            clsGlobal.myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Joonwoo\\source\\repos\\RemaxApplication\\RemaxApplication\\App_Data\\Remax.mdb;Persist Security Info=True");
            clsGlobal.myCon.Open();
            var agt = (from DataRow dr in clsGlobal.tabAgents.Rows
                      where dr["RefAgent"].ToString() == refA.ToString()
                      select dr).First<DataRow>();
 
            lblAgent.Text = agt["AgentName"].ToString();
            lblEmail.Text = agt["Email"].ToString();
            lblPhone.Text = agt["Phone"].ToString();

        }
    }
}