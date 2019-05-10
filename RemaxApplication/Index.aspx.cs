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
    public partial class Index : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clsGlobal.mySet = new DataSet();
                clsGlobal.myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Joonwoo\\source\\repos\\RemaxApplication\\RemaxApplication\\App_Data\\Remax.mdb;Persist Security Info=True");
                clsGlobal.myCon.Open();

                OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Houses", clsGlobal.myCon);
                clsGlobal.adpHouses = new OleDbDataAdapter(myCmd);
                clsGlobal.adpHouses.Fill(clsGlobal.mySet, "Houses");
                clsGlobal.tabHouses = clsGlobal.mySet.Tables["Houses"];

                myCmd = new OleDbCommand("SELECT * FROM Agents", clsGlobal.myCon);
                clsGlobal.adpAgents = new OleDbDataAdapter(myCmd);
                clsGlobal.adpAgents.Fill(clsGlobal.mySet, "Agents");
                clsGlobal.tabAgents = clsGlobal.mySet.Tables["Agents"];

                myCmd = new OleDbCommand("SELECT * FROM Regions ORDER BY RegionName", clsGlobal.myCon);
                clsGlobal.adpRegions = new OleDbDataAdapter(myCmd);
                clsGlobal.adpRegions.Fill(clsGlobal.mySet, "Regions");

                chkRegions.DataTextField = "RegionName";
                chkRegions.DataValueField = "RegionName";
                chkRegions.DataSource = clsGlobal.mySet.Tables["Regions"];
                chkRegions.DataBind();

                myCmd = new OleDbCommand("SELECT * FROM Types ORDER BY Description", clsGlobal.myCon);
                clsGlobal.adpTypes = new OleDbDataAdapter(myCmd);
                clsGlobal.adpTypes.Fill(clsGlobal.mySet, "Types");

                chkTypes.DataTextField = "Description";
                chkTypes.DataValueField = "Description";
                chkTypes.DataSource = clsGlobal.mySet.Tables["Types"];
                chkTypes.DataBind();

                ShowAllHouses();
                FillCboPriceFrom();
                FillCboPriceTo();
                FillCboRoom();
                FillCboBathroom();
                FillCboFor();
            }
            
        }

        private void ShowAllHouses()
        {
            litPropertyCount.Text = "All Properties";
            foreach (DataRow dr in clsGlobal.tabHouses.Rows)
            {
                litHouses.Text += "<strong>" + dr["Type"].ToString() + "</strong> for <strong>" + dr["Contract"].ToString() + "</strong><br/>";
                litHouses.Text += "<a href='ShowHouse.aspx?refH=" + dr["RefHouse"].ToString() + "'>" + dr["Address"].ToString() + "</a>" + "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp";
                litHouses.Text += (dr["Contract"].ToString()=="Sale") ? "$ " + dr["Price"].ToString() + "<br/><br/><hr/>" : " $ " + dr["Price"].ToString() + " per month <br/><br/><hr/>";
            }
        }

        private void FillCboPriceFrom()
        {
            int amount = 50000;
            for (int i = 0; i < 20; i++)
            {
                cboPriceFrom.Items.Add(new ListItem("$ " + amount.ToString(), amount.ToString()));
                amount += 50000;
            }
            cboPriceFrom.Items.Insert(0, new ListItem("Undefined", "Undefined"));
            
        }

        private void FillCboPriceTo()
        {
            int amount = 50000;
            for (int i = 0; i < 20; i++)
            {
                cboPriceTo.Items.Add(new ListItem("$ " + amount.ToString(), amount.ToString()));
                amount += 50000;
            }
            cboPriceTo.Items.Insert(0, new ListItem("Undefined", "Undefined"));
        }
        private void FillCboRoom()
        {
            int room = 0;
            for (int i = 0; i < 5; i++)
            {
                cboRooms.Items.Add(new ListItem("+" + room.ToString(), room.ToString()));
                room++;
            }
            cboRooms.Items.Insert(0, new ListItem("Undefined", "Undefined"));
        }

        private void FillCboBathroom()
        {
            int room = 1;
            for (int i = 0; i < 3; i++)
            {
                cboBathrooms.Items.Add(new ListItem("+" + room.ToString(), room.ToString()));
                room++;
            }
            cboBathrooms.Items.Insert(0, new ListItem("Undefined", "Undefined"));
        }
        private void FillCboFor()
        {
            chkFor.Items.Add(new ListItem("Sale", "Sale"));
            chkFor.Items.Add(new ListItem("Rent", "Rent"));

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string flag = "";
            string sql = "SELECT * FROM Houses WHERE ";
            bool isAnySelected = chkTypes.SelectedIndex != -1;
            bool isAnySelected2 = chkRegions.SelectedIndex != -1;
            bool isAnySelected3 = chkFor.SelectedIndex != -1;
            bool isAnySelected4 = cboPriceFrom.Text != "Undefined";
            bool isAnySelected5 = cboPriceTo.Text != "Undefined";
            bool isAnySelected6 = cboRooms.Text != "Undefined";
            bool isAnySelected7 = cboBathrooms.Text != "Undefined";

            if (!isAnySelected && !isAnySelected2 && !isAnySelected3 && !isAnySelected4 && !isAnySelected5 && !isAnySelected6 && !isAnySelected7)
            {
                litHouses.Text = "";
                ShowAllHouses();
                flag = "none";
            }

            //If chkTypes are checked...
            if (isAnySelected)
            {
                sql += "(";
            }
            foreach (ListItem item in chkTypes.Items)
            {
                if (item.Selected)
                {
                    sql += " Type='" + item.Text + "' OR ";
                }

            }

            if (sql.Substring(sql.Length-4)==" OR ")
            {
                sql = sql.Substring(0, sql.Length - 4);
                sql += ")";
            }

            //If chkRegions are checked...
            if (isAnySelected2)
            {
                if (sql.Substring(sql.Length-1)==")")
                {
                    sql += " AND ";
                }
                sql += "(";
                
            }
            
            foreach (ListItem item in chkRegions.Items)
            {
                if (item.Selected)
                {
                    sql += "Region='" + item.Text + "' OR ";
                }
                
            }
            if (sql.Substring(sql.Length - 4) == " OR ")
            {
                sql = sql.Substring(0, sql.Length - 4);
                sql += ")";
            }

            //If chkFor is checked...
            if (isAnySelected3)
            {
                if (sql.Substring(sql.Length-1)==")")
                {
                    sql += " AND ";
                }
                sql += "(";
            }
            
            foreach (ListItem item in chkFor.Items)
            {
                if (item.Selected)
                {
                    sql += "Contract='" + item.Text + "' OR ";
                }
            }
            if (sql.Substring(sql.Length - 4) == " OR ")
            {
                sql = sql.Substring(0, sql.Length - 4);
                sql += ")";
            }
            if (isAnySelected4 || isAnySelected5)
            {
                if (sql.Substring(sql.Length-1)==")")
                {
                    sql += " AND ";
                }
                sql += "(";
            }
            
            if (isAnySelected4 && isAnySelected5)
            {
                
                sql += "Price BETWEEN " + Convert.ToInt32(cboPriceFrom.SelectedValue) + " AND " + Convert.ToInt32(cboPriceTo.SelectedValue) + ")";
            }
            if (isAnySelected4 && !isAnySelected5)
            {

                sql += "Price >= " + Convert.ToInt32(cboPriceFrom.SelectedValue) + ")";
            }
            if (!isAnySelected4 && isAnySelected5)
            {

                sql += "Price <= " + Convert.ToInt32(cboPriceTo.SelectedValue) + ")";
            }

            if (isAnySelected6 || isAnySelected7)
            {
                if (sql.Substring(sql.Length-1)==")")
                {
                    sql += " AND ";
                }
                sql += "(";
            }
            if (isAnySelected6 && isAnySelected7)
            {
                sql += "Room >= " + Convert.ToInt32(cboRooms.SelectedValue) + " AND Bathroom >=" + Convert.ToInt32(cboBathrooms.SelectedValue) + ")";
            }
            if (!isAnySelected6 && isAnySelected7)
            {
                sql += "Bathroom >= " + Convert.ToInt32(cboBathrooms.SelectedValue) + ")";
            }
            if (isAnySelected6 && !isAnySelected7)
            {
                sql += "Room >= " + Convert.ToInt32(cboRooms.SelectedValue) + ")";
            }

            //litSql.Text = sql.ToString();

            if (flag != "none")
            {
                OleDbCommand myCmd = new OleDbCommand(sql, clsGlobal.myCon);
                OleDbDataReader rd = myCmd.ExecuteReader();
                litPropertyCount.Text = "Properties Found";
                litHouses.Text = "";
                while (rd.Read())
                {
                    litHouses.Text += rd["Type"].ToString() + " for " + rd["Contract"].ToString() + "<br/>";
                    litHouses.Text += "<a href='ShowHouse.aspx?refH=" + rd["RefHouse"].ToString() + "'>" + rd["Address"].ToString() + "</a>" + "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp";
                    litHouses.Text += (rd["Contract"].ToString() == "Sale") ? "$ " + rd["Price"].ToString() + "<br/><br/><hr/>" : " $ " + rd["Price"].ToString() + " per month <br/><br/><hr/>";
                }
            }

        }

        protected void btnAllProperties_Click(object sender, EventArgs e)
        {
            litHouses.Text = "";
            ShowAllHouses();
        }
    }
}