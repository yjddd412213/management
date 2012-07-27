using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CommonLib;

namespace PaymentManagement
{
    public partial class Setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            DataTable dt = CommonLib.Setting.Instance.GetSettings();
            if (dt.Rows.Count != 0)
            {
                dgPress.Visible = true;
                lblAlert.Visible = false;
                dgPress.DataSource = dt;
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
            {
                //Add a record
                CommonLib.Setting.Instance.AddSetting(tb_key.Text.Trim(), tb_value.Text.Trim());
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Add Success.');</script>");
            }
            else
            {
                CommonLib.Setting.Instance.UpdateSetting(tb_key.Text.Trim(), tb_value.Text.Trim());
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
            tb_key.Text = String.Empty;
            tb_value.Text = String.Empty;
            tb_key.Enabled = true;
        }
        #endregion

        #region datagrid delete command
        protected void dgPress_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            CommonLib.Setting.Instance.DeleteSetting(dgPress.DataKeys[e.Item.ItemIndex].ToString());
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
            tb_key.Text = dgPress.DataKeys[dgPress.SelectedIndex].ToString();
            tb_key.Enabled = false;
            tb_value.Text = CommonLib.Setting.Instance.GetSetting(dgPress.DataKeys[dgPress.SelectedIndex].ToString());

            btnAddOrModify.Text = "Save";
            btnCancel.Visible = true;
        }
        #endregion
    }
}