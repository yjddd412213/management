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
    public partial class ProductsTerm : System.Web.UI.Page
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
                    Product();
                    Terms();
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
            string str = "SELECT h.id,h.IsEffective,p.ProductName FROM ProductsTerm as h inner join Products as p on h.ProductId=p.ProductId";
            DataSet ds = data.GetDataSet(str);
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

        protected void Product()
        {
            DataSet ds = data.GetDataSet("Select * from Products");
            ddlProducts.DataSource = ds;
            ddlProducts.DataBind();
        }

        protected void Terms()
        {
            DataSet ds = data.GetDataSet("Select * from Terms");
            ddlTerms.DataSource = ds;
            ddlTerms.DataBind();
        }

        #endregion

        #region add button click
        protected void btnAddOrModify_Click(object sender, EventArgs e)
        {
            if (!btnCancel.Visible)
            {//Add a record
                string sql = "INSERT INTO ProductsTerm (Id,ProductId,TermId,Amount,IsEffective) VALUES (@ID,@ProductId,@TermId,@Amount,@IsEffective)";
                SqlCommand sc = new SqlCommand(sql);
                sc.Parameters.AddWithValue("@ID", tb_producttermid.Text.Trim());
                sc.Parameters.AddWithValue("@ProductId", ddlProducts.SelectedValue);
                sc.Parameters.AddWithValue("@TermId", ddlTerms.SelectedValue);
                sc.Parameters.AddWithValue("@Amount", tbxAmount.Text);
                sc.Parameters.AddWithValue("@IsEffective", CbxIsEffective.Checked);
                data.ExecuteNonQuery(sql, sc);
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Add Success.');</script>");
            }
            else
            {
                string sql = "UPDATE ProductsTerm SET ProductId=@ProductId,TermId=@TermId,Amount=@Amount,IsEffective=@IsEffective WHERE Id=@id";
                SqlCommand sc = new SqlCommand(sql);
                sc.Parameters.AddWithValue("@ProductId", ddlProducts.SelectedValue);
                sc.Parameters.AddWithValue("@TermId", ddlTerms.SelectedValue);
                sc.Parameters.AddWithValue("@Amount", tbxAmount.Text);
                sc.Parameters.AddWithValue("@IsEffective", CbxIsEffective.Checked);
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
            ddlTerms.SelectedIndex = 0;
            ddlProducts.SelectedIndex = 0;
            tbxAmount.Text = String.Empty;
            tb_producttermid.Text = String.Empty;
            CbxIsEffective.Checked = false;
        }
        #endregion

        #region datagrid delete command
        protected void dgPress_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string sql = "delete from ProductsTerm where Id=@id";
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
            string sql = "SELECT * FROM ProductsTerm WHERE Id=@id";
            SqlCommand sc = new SqlCommand(sql);
            sc.Parameters.AddWithValue("@id", dgPress.DataKeys[dgPress.SelectedIndex]);
            SqlDataReader sdr = data.GetDataReader(sql, sc);
            if (sdr.Read())
            {
                tb_producttermid.Text = sdr["Id"].ToString();
                ddlProducts.SelectedValue = sdr["ProductId"].ToString();
                ddlTerms.SelectedValue = sdr["TermId"].ToString();
                tbxAmount.Text = sdr["Amount"].ToString();
                CbxIsEffective.Checked = Convert.ToBoolean(sdr["IsEffective"].ToString());
            }
            sdr.Close();

            btnAddOrModify.Text = "Save";
            btnCancel.Visible = true;
        }
        #endregion
    }
}