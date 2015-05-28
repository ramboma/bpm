$.extend(
    {
        //获取生产厂家信息
        Init_Page: function () {
            //获取生产厂家信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'getsourceinfo', p: '{pageindex:1,pagesize:1000000}' },
                    success: function (data) {

                    }
                });
            //获取保管单位信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'getdeptinfo', p: '{pageindex:1,pagesize:1000000}' },
                    success: function (data) {

                    }
                });
            //获取设备状态信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'getstatusinfo', p: '{pageindex:1,pagesize:1000000}' },
                    success: function (data) {

                    }
                });
            return;
        },
        Btn_Submit_Click: function (ev) {
            //var Devmng_In_Json = { time: '', name: '', factory: '', model: '', spec: '', source: '', price: '', dept: '', owner: '', producttime: '', status: '', docname: '' };
            //Devmng_In_Json.time = new Date();
            return;
        },
        Btn_Cancel_Click: function (ev) {
            location.reload();
            return;
        },
        Btn_bookmng_build_click: function (ev) {
            $("#div_bookmng_qrcode").empty();
            $("#div_bookmng_qrcode").qrcode({
                render: "table",
                width: 200,
                height: 200,
                text: "hello world"
            });
            return;
        },
        Btn_bookmng_print_click: function (ev) {
            alert("请准备打印机");
            return;
        }
    });
$(document).ready(function () {
    var MyDate = new Date();
    $("#tb_bookmng_time").text(MyDate.toLocaleString());
    $("#btn_bookmng_submit").click($.Btn_Submit_Click);
    $("#btn_bookmng_cancel").click($.Btn_Cancel_Click);
    $("#btn_bookmng_build").click($.Btn_bookmng_build_click);
    $("#btn_bookmng_print").click($.Btn_bookmng_print_click);
    $.Init_Page();
});
