$.extend(
    {
        Deal_Data:function(data)
        {
            var Ret = eval('(' + data + ')');
            var ctlg_json = Ret.Result;
            var Json_data = [];
            for (var i = 0; i < ctlg_json.length; i++) {
                var TempNode = { 'id': '', 'text': '' };
                TempNode.id = ctlg_json[i].catalogId;
                TempNode.text = ctlg_json[i].catalogName;
                Json_data.push(TempNode);
            }
            return Json_data;
        },
        Get_Product_Detail:function(node)
        {
            $("#tb_objmng_unit").text(node.Node.quantityUnit);
            $("#tb_objmng_model").text(node.Node.model);
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
        Init_Page:function()
        {
            //获取资产品名信息
            $.ajax(
                   {
                       url: '/Route/LibraryHandler.ashx',
                       type: 'POST',
                       data: { c: 'assetlibrary', m: 'getallpingmingtree', p: ''},
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
            //获取库房信息
            $.ajax(
                   {
                       url: '/Route/LibraryHandler.ashx',
                       type: 'POST',
                       data: { c: 'assetlibrary', m: 'providermng', p: 'kf' },
                       success: function (data) {
                           $("#tb_objmng_warehouse").combobox('loadData',$.Deal_Data(data));
                       },
                       error: function (data) {
                           //alert(data);
                       }
                   }
                    );
            //获取货架信息
            $.ajax(
                   {
                       url: '/Route/LibraryHandler.ashx',
                       type: 'POST',
                       data: { c: 'assetlibrary', m: 'providermng', p: 'hj' },
                       success: function (data) {                      
                           $("#tb_objmng_shelf").combobox('loadData', $.Deal_Data(data));
                       },
                       error: function (data) {
                           //alert(data);
                       }
                   }
                    );
            //获取资产来源信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'providermng', p: 'ly' },
                    success: function (data) {             
                    $('#sl_objmng_source').combobox('loadData', $.Deal_Data(data));
                },
                error: function (data) {
               //alert(data);
           }
       }
        );
            return;
        },
        Btn_Submit_Click: function (ev) {
            var Objmng_In_Json = { Time: '', ProductId: '', Quantity: '', Source: '', ShelfLife:'',StorageNum: '', Shelf: '' };
            Objmng_In_Json.Time = new Date();
            Objmng_In_Json.ProductId = $('#tb_objmng_name').combotree('getValue');
            Objmng_In_Json.Quantity = $("#tb_objmng_amount").val();
            Objmng_In_Json.StorageNum = $("#tb_objmng_warehouse").combobox('getValue');
            Objmng_In_Json.Shelf = $("#tb_objmng_shelf").combobox('getValue');
            Objmng_In_Json.Source = $("#sl_objmng_source").combobox('getValue')
            Objmng_In_Json.ShelfLife = $("#tb_objmng_exp").val();
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'submitlibrary', p: JSON.stringify(Objmng_In_Json) },
                    success: function (data)
                    {
                        var Ret = eval('(' + data + ')');
                        var Ret_id = Ret.Result;
                        $("#div_objmng_qrcode").empty();
                        $("#div_objmng_qrcode").qrcode({
                            render: "table",
                            width: 200,
                            height: 200,
                            text: $.toUtf8(Ret_id.toString())
                        });
                        alert("保存成功,请打印二维码!");
                    }
                });
            return;
        },
        Btn_Cancel_Click: function(ev) {
            location.reload();
            return;
        },
        Btn_Print_Click: function(ev) {
            alert("请准备好打印机，按确定打印！");
            return;
        },
        toUtf8:function(str)
        {
            var out, i,len,c;
            out="";
            len=str.length;
            for (i=0;i<len;i++)
            {
                c=str.charCodeAt(i);
                if ((c>=0x0001) && (c<=0x007f))
                {
                    out=out+str.charAt(i);
                }else if (c>0x07ff)
                {
                    out+=String.fromCharCode(0xe0 | ((c>>12)&0x0f));
                    out+=String.fromCharCode(0x80 | ((c>>6)&0x3f));
                    out+=String.fromCharCode(0x80 | ((c>>0)&0x3f));
                }
                else
                {
                    out+=String.fromCharCode(0xc0 | ((c>>6) & 0x1f));
                    out+=String.fromCharCode(0x80 | ((c>>0) & 0x3f));
                }
            }
            return out;
        }
    });
$(document).ready(function() {
    var MyDate = new Date();
    $("#tb_objmng_in_time").text(MyDate.toLocaleString());
    $("#btn_objmng_submit").click($.Btn_Submit_Click);
    $("#btn_objmng_cancel").click($.Btn_Cancel_Click);
    $("#btn_objmng_print").click($.Btn_Print_Click);
    $("#tb_objmng_name").combotree({ onSelect: function (node) {$.Get_Product_Detail(node)}});
    $.Init_Page();
});
