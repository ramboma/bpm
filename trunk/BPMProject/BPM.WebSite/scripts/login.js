$.extend(
    {
        Login: function () {
            var LoginRequest = {};
            LoginRequest.LoginName = $("#tb_login_username").val();
            LoginRequest.UserPwd = $("#tb_login_password").val();
            LoginRequest.AuthCode = "";
            LoginRequest.KeyValue = "";
            if ((LoginRequest.LoginName == null) || (LoginRequest.LoginName == ""))
            {
                alert("用户名为空！");
                return;
            }
            if ((LoginRequest.UserPwd == null) || (LoginRequest.UserPwd == "")) {
                alert("用户名为空！");
                return;
            }
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'sysconfig', m: 'userlogin', p: JSON.stringify(LoginRequest) },
                    success: function (data) {
                        var Ret = eval('(' + data + ')');
                        var Ret_id = Ret.Result;
                        if (Ret_id == "0")    //如果登陆成功
                        {
                            location.href = "../views/index.aspx";
                        }
                        else
                        {
                            alert("用户名或者密码错误！");
                        }

                    }
                });
            return;
        },
        Init_Page: function ()
        {
            return;
        }
    });
$(document).ready(function () {
    $.Init_Page();
});
