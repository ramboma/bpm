using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_obj_mng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SysAssert.CheckAuthInfo())
        {
            Response.Redirect("../views/Login.aspx");
        }
    }
}