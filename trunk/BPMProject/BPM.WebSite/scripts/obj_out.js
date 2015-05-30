$.extend(
    {
        Get_Product_Detail:function(node)
        {
            $("#tb_objmng_model").text(node.Node.model);
            $("#tb_objmng_saler").text(node.Node.dealerId);
            $("#tb_objmng_unit").text(node.Node.quantityUnit);
            $("#tb_objmng_spec").text(node.Node.standard);
            $("#tb_objmng_price").text(node.Node.price);
            $.ajax(
               {
                   url: '/Route/LibraryHandler.ashx',
                   type: 'POST',
                   data: { c: 'assetlibrary', m: 'getproviderbyid', p: node.Node.factoryId },
                   success: function (data) {
                       var Ret = eval('(' + data + ')');
                       var ctlg_json = Ret.Result;
                       $("#tb_objmng_factory").text(ctlg_json.catalogName);
                       return;
                   },
                   error: function (data) {
                       alert(data);
                   }
               });
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'getproviderbyid', p: node.Node.dealerId },
                    success: function (data) {
                        var Ret = eval('(' + data + ')');
                        var ctlg_json = Ret.Result;
                        $("#tb_objmng_saler").text(ctlg_json.catalogName);
                        return;
                    },
                    error: function (data) {
                        alert(data);
                    }
                });
            return;
        },
        Count_Total_Price:function()
        {
            var Amount = $("#tb_objmng_amount").val();
            var Total_Price = parseInt(Amount) * parseFloat($("#tb_objmng_price").text());
            $("#tb_objmng_total").text(Total_Price.toString());
            return;
        },
        InitPage: function () {
            //获取资产品名信息
            $.ajax(
                   {
                       url: '/Route/LibraryHandler.ashx',
                       type: 'POST',
                       data: { c: 'assetlibrary', m: 'getallpingmingtree', p: '' },
                       success: function (data) {
                           var Ret = eval('(' + data + ')');
                           var ctlg_json = Ret.Result;
                           $("#tb_objmng_name").combotree('loadData', ctlg_json);
                       },
                       error: function (data) {
                           alert(data);
                       }
                   }
            );
            return;
        },
        /*
        物资出库时两种方式：
        1、直接读取物资包装上的二维码获取要出库物资的inputid，从数据库中减去相应的出库量
        2、选取物资品名目录，选取品名，系统从数据库中匹配最合适（保质期和零散物资优先）的包装单位出库
        物资出库后提交后，系统返回要出库物资存放的位置（库房和货架）
        */
        Btn_Submit_Click: function(ev) {
            var Objmng_Out_Json = { ProductInputId: '', ProductId: '', Quantity: '' };
            Objmng_Out_Json.ProductInputId = '';//从二维码扫描枪中读取二维码对应的ID
            Objmng_Out_Json.ProductId=$("#tb_objmng_name").combotree('getValue');
            Objmng_Out_Json.Quantity = $("#tb_objmng_amount").val();
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'saveproductlog', p: JSON.stringify(Objmng_Out_Json) },
                    success: function (data) {
                        alert(data);
                    },
                    error: function (data) {
                        alert(data);
                    }
                });
            return;
        },
        Btn_Cancel_Click: function(ev) {
            location.reload();
            return;
        },
        Btn_Scan_Click: function(ev) {
            return;
        }
    });
$(document).ready(function() {
    var MyDate = new Date();
    $("#tb_objmng_out_time").text(MyDate.toLocaleString());
    $("#btn_objmng_submit").click($.Btn_Submit_Click);
    $("#btn_objmng_cancel").click($.Btn_Cancel_Click);
    $("#btn_objmng_scan").click($.Btn_Scan_Click);
    $.InitPage();
    $("#tb_objmng_name").combotree({ onSelect: function (node) { $.Get_Product_Detail(node) } });
    $("input", $("#tb_objmng_amount").next("span")).blur(function () { $.Count_Total_Price() });
});
