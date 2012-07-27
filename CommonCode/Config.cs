using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Collections;

namespace PaymentManagement.CommonCode
{
    public class LoginUser
    {
        public string ID;
        public string UserName;
        public string Email;
        public string RealName;
        public string picture;
        public string intro;
        public string userCategory;
        public string userSubCategory;
        public string groupID;
    }

    public class LoginAdmin
    {
        public string id;
        public string userName;
        public string loginTime;
        public string lastIp;
        public string lastLoginTime;
        public string loginNum;
        public string realName;
    }

    public class MainFun
    {
        public static bool IsEmptyorNull(object obj)
        {
            if (obj == null || obj.ToString().Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ClearHtmlTag(string strText)
        {
            Regex regexTagStart = new Regex("<([^<^>]*)>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            strText = regexTagStart.Replace(strText, "");

            return strText;
        }

        public static bool IsInteger(string strIn)
        {
            bool bolResult = true;
            if (strIn == "")
            {
                bolResult = false;
            }
            else
            {
                foreach (char Char in strIn)
                {
                    if (char.IsNumber(Char))
                        continue;
                    else
                    {
                        bolResult = false;
                        break;
                    }
                }
            }
            return bolResult;
        }

        public static string MakePassword(int pwdlen)
        {
            const string pwdchars = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string tmpstr = String.Empty;
            int iRandNum;
            Random rnd = new Random();
            for (int i = 0; i < pwdlen; i++)
            {
                iRandNum = rnd.Next(pwdchars.Length);
                tmpstr += pwdchars[iRandNum];
            }
            return tmpstr;
        }

        public static string MakeValidCode(int pwdlen)
        {
            const string pwdchars = "abcdefghijklmnopqrstuvwxyz0123456789";
            string tmpstr = String.Empty;
            int iRandNum;
            Random rnd = new Random();
            for (int i = 0; i < pwdlen; i++)
            {
                iRandNum = rnd.Next(pwdchars.Length);
                tmpstr += pwdchars[iRandNum];
            }
            return tmpstr;
        }

        public static string getFileName(string url)
        {
            return url.Substring((url.LastIndexOf("/") + 1), url.Length - url.LastIndexOf("/") - 1);
        }

        public static LoginUser GetUser(System.Web.UI.Page page)
        {
            return (LoginUser)page.Session["LoginUser"];
        }

        public static LoginUser GetUser(System.Web.UI.UserControl control)
        {
            return (LoginUser)control.Session["LoginUser"];
        }

        public static LoginAdmin GetAdmin(System.Web.UI.Page page)
        {
            return (LoginAdmin)page.Session["LoginAdmin"];
        }

        public static LoginAdmin GetAdmin(System.Web.UI.UserControl control)
        {
            return (LoginAdmin)control.Session["LoginAdmin"];
        }
    }


    [Serializable]
    public class ParameterString
    {
        public string Parameter;
        public string Value;
    }

    [Serializable]
    public class Parameters
    {
        private Hashtable _list;
        public Hashtable List
        {
            get
            {
                return _list;
            }
        }
        public Parameters()
        {
            _list = new Hashtable();
        }
        public Parameters(string Parameter, string Value)
        {
            _list = new Hashtable();
            Add(Parameter, Value);
        }
        public void Remove(string Parameter)
        {
            _list.Remove(Parameter);
        }
        public void Add(string Parameter, string Value)
        {
            if (_list.ContainsKey(Parameter))
            {
                ParameterString pstring = (ParameterString)_list[Parameter];
                pstring.Value = Value;
            }
            else
            {
                ParameterString pstring = new ParameterString();
                pstring.Value = Value;
                pstring.Parameter = Parameter;
                _list.Add(Parameter, pstring);
            }
        }
        public void Clear()
        {
            _list.Clear();
        }
    }

    #region Check User
    public class AccessMatrix
    {
        private System.Web.UI.Page m_page;

        public AccessMatrix()
        {

        }

        public AccessMatrix(System.Web.UI.Page page)
        {
            m_page = page;
        }

        public void CheckUser()
        {
            try
            {
                LoginUser loginUser = (LoginUser)m_page.Session["LoginUser"];

                if (loginUser == null)
                {
                    m_page.Response.Redirect(String.Format("login.aspx?return={0}", HttpUtility.HtmlEncode(m_page.Request.RawUrl)));
                }
            }
            catch { }
        }

        public void CheckAdmin()
        {
            try
            {
                LoginAdmin loginAdmin = (LoginAdmin)m_page.Session["LoginAdmin"];

                if (loginAdmin == null)
                {
                    m_page.Response.Redirect(String.Format("login.aspx?return={0}", HttpUtility.HtmlEncode(m_page.Request.RawUrl)));
                }
            }
            catch { }
        }
    }
    #endregion 
}