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
            //��ȡ�ʲ�Ʒ����Ϣ
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
        ���ʳ���ʱ���ַ�ʽ��
        1��ֱ�Ӷ�ȡ���ʰ�װ�ϵĶ�ά���ȡҪ�������ʵ�inputid�������ݿ��м�ȥ��Ӧ�ĳ�����
        2��ѡȡ����Ʒ��Ŀ¼��ѡȡƷ����ϵͳ�����ݿ���ƥ������ʣ������ں���ɢ�������ȣ��İ�װ��λ����
        ���ʳ�����ύ��ϵͳ����Ҫ�������ʴ�ŵ�λ�ã��ⷿ�ͻ��ܣ�
        */
        Btn_Submit_Click: function(ev) {
            var Objmng_Out_Json = { ProductInputId: '', ProductId: '', Quantity: '' };
            Objmng_Out_Json.ProductInputId = '';//�Ӷ�ά��ɨ��ǹ�ж�ȡ��ά���Ӧ��ID
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
