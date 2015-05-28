$.extend(
    {
        Init_Page: function () {
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'getallpingming', p: '{pageindex:1,pagesize:1000000}' },
                    success: function (data) {
                        var json_obj = eval('('+data+')');
                        return;
                    }
            });
            return;
        },
        Btn_Submit_Click: function(ev) {
            var str_obj_name;
            var str_obj_amount;
            var str_obj_apply;
            var str_obj_approval;
            var str_param;

            str_obj_id=$("#sl_objmng_name").val();
            str_obj_amount=$("#tb_objmng_amount").val();
            str_obj_apply=$("#tb_objmng_apply").val();
            str_obj_approval=$("#tb_objmng_approval").val();
            str_param="obj_ajax.aspx?type=obj_out&obj_id="+str_obj_id+"&obj_amount="+str_obj_amount+"&obj_apply="+str_obj_apply+"&obj_approval="+str_obj_approval;
            alert(str_param);
            str_param=encodeURI(str_param);
            str_param=encodeURI(str_param);
            $.post
            (
                str_param,
                function(data) {
                    var array=data.split("|");
                    if (array[0]=="0")   //返回结果正确
                    {
                        alert(array[1]);


                    }
                    else           //返回结果不正确
                    {

                    }
                }
            );
            return;
        },
        Btn_Cancel_Click: function(ev) {
            location.reload();
            return;
        },
        Btn_devmng_scan_click:function(ev){
            $("#div_devmng_qrcode").empty();
            $("#div_devmng_qrcode").qrcode({
                render	: "table",
                width:200,
                height:200,
                text	: "hello world"
            });
            return;
        }
    });
$(document).ready(function() {
    var MyDate = new Date();
    $("#tb_devmng_change_time").text(MyDate.toLocaleString());
    $("#btn_devmng_submit").click($.Btn_Submit_Click);
    $("#btn_devmng_cancel").click($.Btn_Cancel_Click);
    $("#tb_devmng_name").click($.tb_devmng_name_click);
    $("#btn_devmng_scan").click($.Btn_devmng_scan_click);
    $.Init_Page();
});
