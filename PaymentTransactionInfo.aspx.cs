using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PaymentManagement.CommonCode;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CatalogCommon;

namespace PaymentManagement
{
    public partial class PaymentTransactionInfo : System.Web.UI.Page
    {
        //static RemotePaymentInfoProvider provider = new RemotePaymentInfoProvider("http://192.168.1.120/Inywhere.PaymentGateway.InfoFrontEnd/Service.svc");
        //RemotePaymentInfoProvider provider = new RemotePaymentInfoProvider(ConfigurationManager.AppSettings["PaymentInfoFrontEnd"]);
        DataAccess data = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            AccessMatrix matrix = new AccessMatrix(this.Page);
            //matrix.CheckAdmin();
            if (!IsPostBack)
            {
                DiplayCalender(false);
                BindAll();
            }
        }
       

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
                BindAll();
            }
            catch
            {
                BindAll();
            }
        }
        #endregion

        #region selected changed
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
        }

        
        #endregion

        protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSearch.SelectedIndex == 0)
            {
                DiplayCalender(false);
            }
            else
            {
                DiplayCalender(true);
 
            }
        }
        private void DiplayCalender(bool b)
        {
            if (b)
            {
                ddlresult.Visible = false;
                lblstart.Visible = true;
                lblend.Visible = true;
                tbxstart.Visible = true;
                tbxend.Visible = true;
               
            }
            else
            {
                ddlresult.Visible = true;
                lblstart.Visible = false;
                lblend.Visible = false;
                tbxstart.Visible = false;
                tbxend.Visible = false;
 
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindAll();
        }
        #region 绑定数据
        private void BindAll()
        {
            if (ddlSearch.SelectedIndex == 0)
            {
                bool b = false;
                if (ddlresult.SelectedIndex == 0)
                {
                    b = true;
                }
                BindResult(b);
            }
            else
            {
                BindTime(tbxstart.Text, tbxend.Text);

            }

        }
        private void BindResult(bool b)
        {
            string sql = "SELECT * FROM PaymentTransactionInfo where IsPay=@Ispay";
            SqlCommand sc = new SqlCommand(sql);
            sc.Parameters.AddWithValue("@Ispay", b);
            DataSet ds = data.GetDataSet(sql, sc);
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
        private void BindTime(string start, string end)
        {
            string sql = "SELECT * FROM PaymentTransactionInfo where chargeDate between @start and @end";
            SqlCommand sc = new SqlCommand(sql);
            sc.Parameters.AddWithValue("@start", start);
            sc.Parameters.AddWithValue("@end", end);
            DataSet ds = data.GetDataSet(sql, sc);
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

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

      
      
    }
}