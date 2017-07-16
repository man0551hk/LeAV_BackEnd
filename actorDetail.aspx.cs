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

public partial class actorDetail : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LeAvServer"].ConnectionString);
    int actor_id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["actor_id"] != null)
        {
            actor_id = Convert.ToInt32(Request.QueryString["actor_id"]);
            LoadData();
            GetCategory();
        }
    }

    public void GetCategory()
    {
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetCategory", cn);
            cmd.CommandType = CommandType.StoredProcedure;
          
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            ad.Fill(ds);

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                ListItem li = new ListItem();
                li.Value = dr["cat_id"].ToString();
                li.Text = dr["cat_name"].ToString();
                catList.Items.Add(li);
            }
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
    }

    public void LoadData()
    {
        
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("ActorDetail", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@actor_id", SqlDbType.Int).Value = actor_id;
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            ad.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                actor_name.Text = ds.Tables[0].Rows[0]["actor_name"].ToString();
                actor_image.ImageUrl = ds.Tables[0].Rows[0]["cover_path"].ToString();
            }
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
    }
    protected void updateBtn_Click(object sender, EventArgs e)
    {
        try
        {
            cn.Open();
        
            string path = Server.MapPath("actor") + @"\" + cover.FileName;
            string updatePath = "http://api.le-av.com/actor/" + cover.FileName;
            cover.SaveAs(path);

            SqlCommand cmd = new SqlCommand("UpdateActorPath", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@actor_id", SqlDbType.Int).Value = actor_id;
            cmd.Parameters.Add("@cover_path", SqlDbType.VarChar).Value = updatePath;

            cmd.ExecuteNonQuery();
            
        }
        catch (Exception ex)
        {
            msg.Text = ex.Message;
        }
        finally
        {
            cn.Close();
        }
        LoadData();
    }

    protected void newVideoBtn_Click(object sender, EventArgs e)
    {
        if (video_cover.HasFile && video_name.Text != "" && video.HasFile)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("CreateVideo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@actor_id", SqlDbType.Int).Value = actor_id;
                cmd.Parameters.Add("@video_name", SqlDbType.VarChar).Value = video_name.Text;
                cmd.Parameters.Add("@video_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                int video_id = Convert.ToInt32(cmd.Parameters["video_id"].Value);

            }
            catch (Exception ex)
            { }
            finally
            {
                cn.Close(); 
            }
        }
    }
}