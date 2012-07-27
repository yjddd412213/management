using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PaymentManagement.CommonCode;
using System.Data.SqlClient;

namespace PaymentManagement
{
    public partial class Login : System.Web.UI.Page
    {
        DataAccess data = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginAdmin"] != null)
                Response.Redirect("Index.aspx");
            if (!MainFun.IsEmptyorNull(Request["action"]))
            {
                if (Request["action"].ToString() == "logout")
                {
                    Session["LoginAdmin"] = null;
                }
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Session["CheckCode"] != null && txtValid.Text != Session["CheckCode"].ToString())
            {

                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('验证码错误.');</script>");
                txtValid.Text = String.Empty;
                return;
            }
            try
            {
                string sqlstring = "SELECT id FROM admin WHERE userName=@userName";
                SqlCommand sc = new SqlCommand(sqlstring);
                sc.Parameters.AddWithValue("@userName", txtUserName.Text);
                SqlDataReader sdr = data.GetDataReader(sqlstring, sc);
                if (sdr.Read())
                {
                    //用户ID存在，检测密码
                    sdr.Close();
                    sqlstring = "select * from admin where userName=@userName and password=@password";
                    sc = new SqlCommand(sqlstring);
                    sc.Parameters.AddWithValue("@userName", txtUserName.Text);
                    //sc.Parameters.AddWithValue("@password", System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPwd.Text, "MD5"));
                    sc.Parameters.AddWithValue("@password", txtPwd.Text);
                    sdr = data.GetDataReader(sqlstring, sc);

                    if (sdr.Read())
                    {
                        //密码匹配成功
                        LoginAdmin admin = new LoginAdmin();
                        admin.userName = txtUserName.Text;
                        admin.id = sdr["id"].ToString();
                        //admin.lastLoginTime = sdr["lastlogintime"].ToString();
                        //admin.loginNum = sdr["loginnum"].ToString();
                        //admin.realName = sdr["realName"].ToString();
                        sdr.Close();

                        Session["LoginAdmin"] = admin;

                        //sqlstring = "update admin set loginNum = loginNum + 1,lastlogintime=@lastlogintime where id=@id";
                        //sc = new SqlCommand(sqlstring);
                        //sc.Parameters.AddWithValue("@id", admin.id);
                        //sc.Parameters.AddWithValue("@lastlogintime", DateTime.Now.ToString());
                        //data.ExecuteNonQuery(sqlstring, sc);
                        if (Request["return"] != null && Request["return"].Length != 0)
                        {
                            Response.Redirect(Request["return"]);
                        }
                        else
                        {
                            Response.Redirect("Index.aspx");
                        }
                    }
                    else
                    {
                        //密码匹配失败
                        txtPwd.Text = String.Empty;
                        txtValid.Text = String.Empty;
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码错误.');</script>");
                    }
                }
                else
                {
                    //用户ID不存在，提示注册
                    txtPwd.Text = String.Empty;
                    txtValid.Text = String.Empty;
                    //ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('" + txtUserName.Text + "，" + "未注册" + "');</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('" + txtUserName.Text + "，" + "未注册" + "');</script>");
                }
            }
            catch (Exception exx)
            {
                Console.Write(exx.Message);
            }
        }
    }
}