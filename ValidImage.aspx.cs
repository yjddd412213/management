using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PaymentManagement.CommonCode;

namespace PaymentManagement
{
    public partial class ValidImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateImage.DrawImage();
        }
    }
}