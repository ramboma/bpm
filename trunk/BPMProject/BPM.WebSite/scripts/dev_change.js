var Submit_Flag = 0;
var Cur_Selected_Node = new Object();
$.extend(
    {
        Init_Page: function () {
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'getequiementlist', p: '' },
                    success: function (data) {
                        var Ret = eval('(' + data + ')');
                        var ctlg_json = Ret.Result;
                        $("#tb_devmng_name").combotree('loadData', ctlg_json);
                        return;
                    }
            });
            return;
        },
        Get_Product_Detail:function(node)
        {
            /*根据节点信息写入标签*/
            /*
            $("#tb_objmng_unit").text(node.Node.quantityUnit);
            $("#tb_objmng_model").text(node.Node.model);
            $("#tb_objmng_spec").text(node.Node.standard);
            $("#tb_objmng_price").text(node.Node.price);
            */
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'getproviderbyid', p: node.Node.factoryId },
                    success: function (data) {
                        var Ret = eval('(' + data + ')');
                        var ctlg_json = Ret.Result;
                        $("#tb_devmng_factory").text(ctlg_json.catalogName);
                        return;
                    },
                    error: function (data) {
                        alert(data);
                    }
                });
            Cur_Selected_Node = node;
            return;
        },
        Btn_Submit_Click: function (ev)
        {

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
    $("#btn_devmng_scan").click($.Btn_devmng_scan_click);
    $("#tb_devmng_name").combotree({ onSelect: function (node) { $.Get_Product_Detail(node) } });
    $.Init_Page();
});
