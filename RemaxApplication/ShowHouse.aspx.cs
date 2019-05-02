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
    public partial class ShowHouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int refH = Convert.ToInt32(Request.QueryString["refH"]);

                var h = (from DataRow dr in clsGlobal.tabHouses.Rows
                         where dr["RefHouse"].ToString() == refH.ToString()
                         select dr).First<DataRow>();
                lblTitle.Text = h["Address"].ToString() + " For " + h["Contract"].ToString();
                lblType.Text = h["Type"].ToString();
                lblRoom.Text = h["Room"].ToString();
                lblBathroom.Text = h["Bathroom"].ToString();
                lblDescription.Text = h["Description"].ToString();
                lblYear.Text = h["YearBuilt"].ToString();
                lblprice.Text = (h["Contract"].ToString()=="Sales") ? " $ " + h["Price"].ToString() : " $ " + h["Price"].ToString() + " per month";
                lblRegion.Text = h["Region"].ToString();

                var a = (from DataRow dr in clsGlobal.tabAgents.Rows
                         where dr["RefAgent"].ToString() == h["RefAgent"].ToString()
                         select dr).First<DataRow>();

                lblAgent.Text = a["AgentName"].ToString();
                lblPhone.Text = a["Phone"].ToString();
                lblEmail.Text = a["Email"].ToString();
            }
        }
    }
}