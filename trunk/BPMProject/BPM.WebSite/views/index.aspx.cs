using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
using BPM.Entity;
public partial class views_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SysAssert.CheckAuthInfo())
        {
            Response.Redirect("../views/Login.aspx");
        }
        if (SysAssert.GetAccessMask() >= 0)
        {
            HttpCookie cookie = new HttpCookie("AccessMask");
            cookie.Value = SysAssert.GetAccessMask().ToString();
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}