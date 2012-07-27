using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CatalogCommon;

namespace PaymentManagement.UserInfoManagement
{
    public partial class TransactionInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoginAdmin"] != null)
                {
                    pl_detail.Visible = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            BindAll(0);
        }

        private void BindAll(int index)
        {
            dgPress.Visible = true;
            if (index != -1)
                dgPress.CurrentPageIndex = index;
            dgPress.DataSource = AccountInfoProvider.Instance.getTransactionInfo(tb_id.Text.Trim(), tb_userid.Text.Trim(), tb_startdate.Text.Trim(), tb_enddate.Text.Trim());
            dgPress.DataBind();
            pl_detail.Visible = false;
        }

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
            BindAll(-1);
        }

        protected void dgPress_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgPress.DataKeys[dgPress.SelectedIndex].ToString();
            Inywhere.PaymentGateway.DataContract.PaymentTransactionData transData = AccountInfoProvider.Instance.GetPaymentTransactionData(id);
            tbxAmount.Text = transData.ProductData.Amount.ToString();
            tbxDate.Text = transData.ChargeDate.ToString();
            tbxInywhereID.Text = transData.InywhereId;
            tbxProductName.Text = transData.ProductData.Product.ProductName;
            tbxTerm.Text = transData.ProductData.Term.TermType;

            tbxaddress1.Text = transData.CustomerData.AddressLine1;
            tbxaddress2.Text = transData.CustomerData.AddressLine2;
            tbxcity.Text = transData.CustomerData.City;
            tbxcompany.Text = transData.CustomerData.Company;
            tbxcompany.Text = transData.CustomerData.Country;
            tbxemail.Text = transData.CustomerData.EmailAddress;
            tbxfax.Text = transData.CustomerData.FaxNumber;
            tbxname.Text = transData.CustomerData.LastName + " " + transData.CustomerData.FirstName;
            tbxphone.Text = transData.CustomerData.PhoneNumber;
            tbxCustomerID.Text = transData.CustomerData.CustomerId;

            pl_detail.Visible = true;
        }
    }
}