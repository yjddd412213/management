using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PaymentManagement.CommonCode;
using System.Data;
using System.Data.SqlClient;

namespace PaymentManagement
{
    public partial class Terms : System.Web.UI.Page
    {
        DataAccess data = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            AccessMatrix matrix = new AccessMatrix(this.Page);
            //matrix.CheckAdmin();
            if (!IsPostBack)
            {
                if (Session["LoginAdmin"] != null)
                {
                    Bind();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        #region 绑定数据
        public void Bind()
        {
            DataSet ds = data.GetDataSet("SELECT * FROM Terms");
            if (ds.Tables[0].Rows.Count != 0)
            {
                dgPress.Visible = true;
                lblAlert.Visible = false;
                dgPress.DataSource = ds;
                dgPress.DataBind();
            }
            else
            {
                dgPress.Visible = false;
                lblAlert.Visible = true;
            }
        }
        #endregion

        #region add button click
        protected void btnAddOrModify_Click(object sender, EventArgs e)
        {
            if (!btnCancel.Visible)
            {//Add a record
                string sql = "INSERT INTO Terms (Type,Description) VALUES (@Type,@Description)";
                SqlCommand sc = new SqlCommand(sql);
                sc.Parameters.AddWithValue("@Type", tbxType.Text);
                sc.Parameters.AddWithValue("@Description",tbxDescription.Text);
                data.ExecuteNonQuery(sql, sc);
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Add Success.');</script>");
            }
            else
            {
                string sql = "UPDATE Terms SET Type=@Type,Description=@Description WHERE TermId=@id";
                SqlCommand sc = new SqlCommand(sql);
                sc.Parameters.AddWithValue("@Type", tbxType.Text);
                sc.Parameters.AddWithValue("@Description", tbxDescription.Text);
                sc.Parameters.AddWithValue("@id", dgPress.DataKeys[dgPress.SelectedIndex]);

                data.ExecuteNonQuery(sql, sc);
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Modify Success.');</script>");
            }
            Bind();
            btnCancel_Click(null, null);
        }
        #endregion

        #region cancel button click
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnAddOrModify.Text = "Add";
            tbxDescription.Text = "";
            tbxType.Text = "";
        }
        #endregion

        #region datagrid delete command
        protected void dgPress_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string sql = "delete from Terms where TermId=@id";
            SqlCommand sc = new SqlCommand(sql);
            sc.Parameters.AddWithValue("@id", dgPress.DataKeys[e.Item.ItemIndex]);
            data.ExecuteNonQuery(sql, sc);
            btnCancel_Click(null, null);
            try
            {
                Bind();
            }
            catch
            {
                dgPress.CurrentPageIndex = dgPress.PageCount - 1;
                Bind();
            }
        }
        #endregion

        #region pageIndexchanged
        protected void dgPress_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            try
            {
                dgPress.CurrentPageIndex = e.NewPageIndex;
            }
            catch
            {
                dgPress.CurrentPageIndex = 0;
            }
            try
            {
                Bind();
            }
            catch
            {
                Bind();
            }
        }
        #endregion

        #region selected changed
        protected void dgPress_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Terms WHERE TermId=@id";
            SqlCommand sc = new SqlCommand(sql);
            sc.Parameters.AddWithValue("@id", dgPress.DataKeys[dgPress.SelectedIndex]);
            SqlDataReader sdr = data.GetDataReader(sql, sc);
            if (sdr.Read())
            {

                tbxType.Text = sdr["Type"].ToString();
                tbxDescription.Text = sdr["Description"].ToString();
            }
            sdr.Close();

            btnAddOrModify.Text = "Save";
            btnCancel.Visible = true;
        }
        #endregion
    }
}