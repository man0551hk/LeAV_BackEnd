using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Data;
using System.IO;

public partial class uploadActor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LeAvServer"].ConnectionString); 
    protected void addBtn_Click(object sender, EventArgs e)
    {

        if (actorName.Text != "" && cover.HasFile)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("CreateActor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@actor_name", SqlDbType.VarChar).Value = actorName.Text;
                cmd.Parameters.Add("@actor_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                int actor_id = Convert.ToInt32(cmd.Parameters["@actor_id"].Value);
                if (actor_id > 0)
                {
                    string path = Server.MapPath("actor") + @"\" + cover.FileName;
                    string updatePath = "http://api.le-av.com/actor/" + cover.FileName;
                    cover.SaveAs(path);

                    cmd = new SqlCommand("UpdateActorPath", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@actor_id", SqlDbType.Int).Value = actor_id;
                    cmd.Parameters.Add("@cover_path", SqlDbType.VarChar).Value = updatePath;
                   
                    cmd.ExecuteNonQuery();
                }

                actorName.Text = "";
                msg.Text = "";
            }
            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}