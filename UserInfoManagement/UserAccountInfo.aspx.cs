using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CatalogCommon;

namespace PaymentManagement.UserInfoManagement
{
    public partial class UserAccountInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pl_accountInfo.Visible = false;
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            BindUserAccountInfo();
        }

        private void BindUserAccountInfo()
        {
            DataTable dt = AccountInfoProvider.Instance.GetUserAccountInfoDT(tb_id.Text.Trim(), tb_start.Text, tb_enddate.Text, cb_paid.Checked);
            gv_UserAccountInfo.DataSource = dt;
            gv_UserAccountInfo.DataBind();
            pl_accountInfo.Visible = false;
        }

        protected void gv_UserCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null && e.CommandName == "Detail")
            {
                string userid = gv_UserAccountInfo.DataKeys[Convert.ToInt32(e.CommandArgument)]["UserId"].ToString();
                ViewState["userid"] = userid;
                BindAccountInfo();
            }
        }

        protected void gv_UserPageChange(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gv_UserAccountInfo.PageIndex = e.NewPageIndex;
            }
            catch
            {
                gv_UserAccountInfo.PageIndex = 0;
            }
            BindUserAccountInfo();
        }

        protected void BindAccountInfo()
        {
            if (ViewState["userid"] != null)
            {
                string userid = ViewState["userid"].ToString();
                DataTable dt = AccountInfoProvider.Instance.GetAccountInfoDT(userid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    gv_AccountInfo.DataSource = dt;
                    gv_AccountInfo.DataBind();

                    pl_accountInfo.Visible = true;
                    gv_AccountInfo.Visible = true;
                    lbl_noinfo.Visible = false;
                }
                else
                {
                    pl_accountInfo.Visible = true;
                    gv_AccountInfo.Visible = false;
                    lbl_noinfo.Visible = true;
                }
            }
            else
                pl_accountInfo.Visible = false;
        }

        protected void gv_AccountPageChange(object sender, GridViewPageEventArgs e)
        {
            gv_AccountInfo.PageIndex = e.NewPageIndex;
            BindAccountInfo();
        }

        protected void gv_UserRowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_UserAccountInfo.EditIndex = e.NewEditIndex;
            BindUserAccountInfo();
            DropDownList ddl = gv_UserAccountInfo.Rows[e.NewEditIndex].FindControl("ddl_activated") as DropDownList;
            ddl.SelectedValue = gv_UserAccountInfo.DataKeys[e.NewEditIndex]["Activated"].ToString();
            ddl = gv_UserAccountInfo.Rows[e.NewEditIndex].FindControl("ddl_suspended") as DropDownList;
            ddl.SelectedValue = gv_UserAccountInfo.DataKeys[e.NewEditIndex]["Suspended"].ToString();
        }

        protected void gv_UserRowCanceling(object sender, GridViewCancelEditEventArgs e)
        {
            gv_UserAccountInfo.EditIndex = -1;
            BindUserAccountInfo();
        }

        protected void gv_UserRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DropDownList ddl = gv_UserAccountInfo.Rows[e.RowIndex].FindControl("ddl_activated") as DropDownList;
            string activated = ddl.SelectedValue;
            ddl = gv_UserAccountInfo.Rows[e.RowIndex].FindControl("ddl_suspended") as DropDownList;
            string suspended = ddl.SelectedValue;
            string userid = gv_UserAccountInfo.DataKeys[e.RowIndex]["UserId"].ToString();
            AccountInfoProvider.Instance.UpdateUserAccountInfo(userid, activated, suspended);
            gv_UserAccountInfo.EditIndex = -1;
            BindUserAccountInfo();
        }

        protected void gv_UserDeleting(object sender, GridViewDeleteEventArgs e)
        {
            gv_UserAccountInfo.EditIndex = -1;
            BindUserAccountInfo();
        }


        //gv_accountinfo
        protected void gv_accountEdit(object sender, GridViewEditEventArgs e)
        {
            gv_AccountInfo.EditIndex = e.NewEditIndex;
            BindAccountInfo();
            DropDownList ddl = gv_AccountInfo.Rows[e.NewEditIndex].FindControl("ddl_Locked") as DropDownList;
            ddl.SelectedValue = gv_AccountInfo.DataKeys[e.NewEditIndex]["Locked"].ToString();
        }

        protected void gv_accountCacel(object sender, GridViewCancelEditEventArgs e)
        {
            gv_AccountInfo.EditIndex = -1;
            BindAccountInfo();
        }

        protected void gv_accountUpdate(object sender, GridViewUpdateEventArgs e)
        {
            DropDownList ddl = gv_AccountInfo.Rows[e.RowIndex].FindControl("ddl_Locked") as DropDownList;
            string Locked = ddl.SelectedValue;
            string userid = gv_AccountInfo.DataKeys[e.RowIndex]["UserId"].ToString();
            string appid = gv_AccountInfo.DataKeys[e.RowIndex]["ApplicationID"].ToString();
            AccountInfoProvider.Instance.UpdateAccountInfo(userid, appid, Locked);
            gv_AccountInfo.EditIndex = -1;
            BindAccountInfo();
        }

        protected void gv_accountDelete(object sender, GridViewDeleteEventArgs e)
        {
            gv_AccountInfo.EditIndex = -1;
            BindAccountInfo();
        }
    }
}