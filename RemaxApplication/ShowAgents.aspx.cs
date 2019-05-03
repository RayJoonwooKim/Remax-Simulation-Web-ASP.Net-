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
    public partial class ShowAgents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clsGlobal.mySet = new DataSet();
                clsGlobal.myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Joonwoo\\source\\repos\\RemaxApplication\\RemaxApplication\\App_Data\\Remax.mdb;Persist Security Info=True");
                clsGlobal.myCon.Open();

                OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Agents", clsGlobal.myCon);
                clsGlobal.adpAgents = new OleDbDataAdapter(myCmd);
                clsGlobal.adpAgents.Fill(clsGlobal.mySet, "Agents");
                clsGlobal.tabAgents = clsGlobal.mySet.Tables["Agents"];

                ShowAllAgents();
                FillChkLanguage();
                FillRadGender();
                FillChkCity();
            }
        }

        private void ShowAllAgents()
        {
            foreach (DataRow dr in clsGlobal.tabAgents.Rows)
            {
                litAgents.Text += "<strong>" + dr["AgentName"].ToString() + "</strong><br/><br/>";
                litAgents.Text += "Gender : " + dr["Gender"].ToString() + "<br/>";
                litAgents.Text += "Languages : " + dr["Language"].ToString() + "<br/>";
                litAgents.Text += "City : " + dr["City"].ToString() + "<br/>";
                litAgents.Text += "Phone : " + dr["Phone"].ToString() + "<br/>";
                litAgents.Text += "Email : " + dr["Email"].ToString() + "<br/><br/>";
                litAgents.Text += "<a href='MessageToAgent.aspx?refA=" + dr["RefAgent"].ToString() + "'>Send a message to the agent</a><hr/>";
            }
        }

        private void FillChkLanguage()
        {
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Languages ORDER By [Language]", clsGlobal.myCon);
            OleDbDataReader rd = myCmd.ExecuteReader();

            if (rd!=null)
            {
                chkLanguages.DataTextField = "Language";
                chkLanguages.DataValueField = "Language";
                chkLanguages.DataSource = rd;
                chkLanguages.DataBind();
            }
            
        }
        private void FillRadGender()
        {
            radGender.Items.Add(new ListItem("Male", "Male"));
            radGender.Items.Add(new ListItem("Female", "Female"));
        }
        private void FillChkCity()
        {
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Cities ORDER By City", clsGlobal.myCon);
            OleDbDataReader rd = myCmd.ExecuteReader();

            if (rd != null)
            {
                chkCity.DataTextField = "City";
                chkCity.DataValueField = "City";
                chkCity.DataSource = rd;
                chkCity.DataBind();
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string flag = "";
            string sql = "SELECT * FROM Agents WHERE ";
            bool isAnySelected = chkLanguages.SelectedIndex != -1;
            bool isAnySelected2 = radGender.SelectedIndex != -1;
            bool isAnySelected3 = chkCity.SelectedIndex != -1;
            if (!isAnySelected && !isAnySelected2 && !isAnySelected3)
            {
                litAgents.Text = "";
                ShowAllAgents();
                flag = "none";
            }
            if (isAnySelected)
            {
                sql += " (";
            }
            foreach (ListItem item in chkLanguages.Items)
            {
                if (item.Selected)
                {
                    sql += "[Language] LIKE '%" + item.Text + "%' OR ";
                }
            }
            if (isAnySelected)
            {
                sql = sql.Substring(0, sql.Length - 4);
                sql += ")";
                
            }
            
            isAnySelected = radGender.SelectedIndex != -1;
            if (isAnySelected2)
            {
                if (sql.Substring(sql.Length-1)==")")
                {
                    sql += " AND ";
                }
                
                sql += "Gender='" + radGender.SelectedItem.ToString() + "'";
            }
            isAnySelected = chkCity.SelectedIndex != -1;
            if (isAnySelected3)
            {
                if (sql.Substring(sql.Length-1)=="'")
                {
                    sql += " AND ";
                }
                sql += "(";
                
            } 
            foreach (ListItem item in chkCity.Items)
            {
                if (item.Selected)
                {
                    sql += "City='" + item.Text + "' OR ";
                }
            }
            if (isAnySelected3)
            {
                sql = sql.Substring(0, sql.Length - 4);
                sql += ")";
            }

            
            if (flag != "none")
            {
                litAgents.Text = "";
                OleDbCommand myCmd = new OleDbCommand(sql, clsGlobal.myCon);
                OleDbDataReader rd = myCmd.ExecuteReader();

                while (rd.Read())
                {
                    litAgents.Text += "<strong>" + rd["AgentName"].ToString() + "</strong><br/><br/>";
                    litAgents.Text += "Gender : " + rd["Gender"].ToString() + "<br/>";
                    litAgents.Text += "Languages : " + rd["Language"].ToString() + "<br/>";
                    litAgents.Text += "City : " + rd["City"].ToString() + "<br/>";
                    litAgents.Text += "Phone : " + rd["Phone"].ToString() + "<br/>";
                    litAgents.Text += "Email : " + rd["Email"].ToString() + "<br/><br/>";
                    litAgents.Text += "<a href='MessageToAgent.aspx?refA=" + rd["RefAgent"].ToString() + "'>Send a message to the agent</a><hr/>";

                }
            }
            

        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            litAgents.Text = "";
            ShowAllAgents();
        }
    }
}