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
    public partial class Products : System.Web.UI.Page
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
            DataSet ds = data.GetDataSet("SELECT * FROM Products");
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
                string sql = "INSERT INTO Products (ProductId,ProductName,Isvip) VALUES (@ProductId, @ProductName,@Isvip)";
                SqlCommand sc = new SqlCommand(sql);
                sc.Parameters.AddWithValue("@ProductId", tb_productid.Text);
                sc.Parameters.AddWithValue("@ProductName", txtTitle.Text);
                sc.Parameters.AddWithValue("@Isvip", CbxIsVip.Checked);
                data.ExecuteNonQuery(sql, sc);
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Add Success.');</script>");
            }
            else
            {
                string sql = "UPDATE Products SET ProductName=@ProductName,Isvip=@Isvip WHERE ProductId=@id";
                SqlCommand sc = new SqlCommand(sql);
                sc.Parameters.AddWithValue("@ProductName", txtTitle.Text);
                sc.Parameters.AddWithValue("@Isvip", CbxIsVip.Checked);
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
            tb_productid.Text = String.Empty;
            txtTitle.Text = String.Empty;
            CbxIsVip.Checked = false;
        }
        #endregion

        #region datagrid delete command
        protected void dgPress_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string sql = "delete from Products where ProductId=@id";
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
            string sql = "SELECT * FROM Products WHERE ProductId=@id";
            SqlCommand sc = new SqlCommand(sql);
            sc.Parameters.AddWithValue("@id", dgPress.DataKeys[dgPress.SelectedIndex]);
            SqlDataReader sdr = data.GetDataReader(sql, sc);
            if (sdr.Read())
            {
                tb_productid.Text = sdr["ProductId"].ToString();
                txtTitle.Text = sdr["ProductName"].ToString();
                CbxIsVip.Checked = Convert.ToBoolean(sdr["IsVip"].ToString());
            }
            sdr.Close();

            btnAddOrModify.Text = "Save";
            btnCancel.Visible = true;
        }
        #endregion
    }
}