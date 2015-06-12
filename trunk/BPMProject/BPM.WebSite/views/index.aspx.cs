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
        
HttpCookie cookie = new HttpCookie("cookieName");
cookie.Value = "name1";
HttpContext.Current.Response.Cookies.Add(cookie); 
    }
}