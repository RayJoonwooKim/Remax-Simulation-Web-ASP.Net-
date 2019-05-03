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
    public partial class SendMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request.Form["Name"].ToString();
            string email = Request.Form["Email"].ToString();
            string message = Request.Form["Message"].ToString();
            int refagent = Convert.ToInt32(Session["RefAgent"]);

            lblText.Text = refagent.ToString();
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Messages", clsGlobal.myCon);
            clsGlobal.adpMessages = new OleDbDataAdapter(myCmd);
            clsGlobal.adpMessages.Fill(clsGlobal.mySet, "Messages");
            clsGlobal.tabMessages = clsGlobal.mySet.Tables["Messages"];

            DataRow myRow = clsGlobal.tabMessages.NewRow();
            myRow["SenderName"] = name;
            myRow["Email"] = email;
            myRow["Message"] = message;
            myRow["RefAgent"] = refagent;

            clsGlobal.tabMessages.Rows.Add(myRow);

            OleDbCommandBuilder myBuild = new OleDbCommandBuilder(clsGlobal.adpMessages);
            clsGlobal.adpMessages.Update(clsGlobal.tabMessages);


        }
    }
}