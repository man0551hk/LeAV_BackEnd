using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Text;
using System.Data;

public partial class actor : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LeAvServer"].ConnectionString); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData(1);
        }
    }

    private void LoadData(int page)
    {
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetAllActor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@page", SqlDbType.Int).Value = page;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            actorRepeater.DataSource = ds.Tables[0];
            actorRepeater.DataBind();
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
    }

}