using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CatalogCommon;
using System.Data;

namespace PaymentManagement.UserInfoManagement
{
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_all.Text = AccountInfoProvider.Instance.getTotalAccount().Rows.Count.ToString();
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            DataTable dt = AccountInfoProvider.Instance.getPaidAccount(tb_startdate.Text.Trim(), tb_enddate.Text.Trim());
            lbl_paid.Text = dt.Rows.Count.ToString();

            dt = AccountInfoProvider.Instance.GetStatisticsInfo(tb_startdate.Text.Trim(), tb_enddate.Text.Trim());
            dgPress.DataSource = dt;
            dgPress.DataBind();
        }
    }
}