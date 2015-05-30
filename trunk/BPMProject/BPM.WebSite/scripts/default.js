var str_Selected_index = 0;   //
var str_div = new Array();
str_div[1] = "div_des_jcwx";
str_div[2] = "div_des_zdwx";
str_div[3] = "div_des_xjys";
str_div[4] = "div_des_cgkz";
str_div[5] = "div_des_ylsq";
str_div[6] = "div_des_wzrk";
str_div[7] = "div_des_wzck";
str_div[8] = "div_des_sbsy";
str_div[9] = "div_des_sbpz";
str_div[10] = "div_des_sbwx";
str_div[11] = "div_des_sbbf";
str_div[12] = "div_des_zljy";
str_div[13] = "div_des_wjfy";
str_div[14] = "div_des_zlgd";
function init() {
    var i = parseInt(Current_Step.value, 0);
    if ((i > 0) && (i < 100))
    {
        Open_Step(i);
    }
    else if (i == 0)
    {
        window.parent.location = " ../default.aspx";
    }
}
function btn_click(obj) {
    switch (obj.id)
    {
        case "btn_objmng_in":
            {
                document.getElementById("Iframe_Display").src = "../views/obj_in.aspx";
                break;
            }
        case "btn_objmng_out":
            {
                document.getElementById("Iframe_Display").src = "../views/obj_out.aspx";
                break;
            }
        case "btn_objmng_reg":
            {
                document.getElementById("Iframe_Display").src = "../views/dev_reg.aspx";
                break;
            }
        case "btn_objmng_unreg":
            {
                document.getElementById("Iframe_Display").src = "../views/dev_unreg.aspx";
                break;
            }
        case "btn_docmng_book_in":
            {
                document.getElementById("Iframe_Display").src = "../views/book_in.aspx";
                break;
            }
        case "btn_docmng_doc_in":
            {
                document.getElementById("Iframe_Display").src = "../views/doc_in.aspx";
                break;
            }
        case "btn_docmng_book_reg":
            {
                document.getElementById("Iframe_Display").src = "../views/book_out.aspx";
                break;
            }
        case "btn_docmng_doc_reg":
            {
                document.getElementById("Iframe_Display").src = "../view/doc_out.aspx";
                break;
            }
        case "btn_docmng_setright":
            {
                document.getElementById("Iframe_Display").src = "doc_mng/docmng_setright.aspx";
                break;
            }
        case "btn_process_create":
            {
                document.getElementById("Iframe_Display").src = "process_mng/prs_create.aspx";
                break;
            }
        case "btn_process_promote":
            {
                break;
            }
        case "btn_process_reverse":
            {
                break;
            }
        case "btn_process_deliver":
            {
                break;
            }
        case "btn_process_monitor":
            {
                monitor();
                break;
            }
        case "btn_qrystc_obj":
            {
                document.getElementById("Iframe_Display").src = "../views/query_obj.aspx";
                break;
            }
        case "btn_qrystc_dev":
            {
                document.getElementById("Iframe_Display").src = "query_statics/query_dev.aspx";
                break;
            }
        case "btn_qrystc_doc":
            {
                document.getElementById("Iframe_Display").src = "query_statics/query_doc.aspx";
                break;
            }
        case "btn_qrystc_process":
            {
                document.getElementById("Iframe_Display").src = "query_statics/query_process.aspx";
                break;
            }
        case "btn_qrystc_consume":
            {
                document.getElementById("Iframe_Display").src = "query_statics/statics_consume.aspx";
                break;
            }
        case "btn_qrystc_work":
            {
                document.getElementById("Iframe_Display").src = "query_statics/statics_work.aspx";
                break;
            }
        case "btn_ayalysis_score":
            {
                document.getElementById("Iframe_Display").src = "data_mining/emplyee_mining.aspx";
                break;
            }
        case "btn_analysis_quality":
            {
                document.getElementById("Iframe_Display").src = "data_mining/quality_mining.aspx";
                break;
            }
        case "btn_analysis_reality":
            {
                document.getElementById("Iframe_Display").src = "data_mining/reality_mining.aspx";
                break;
            }
        case "btn_config_dept":
            {
                document.getElementById("Iframe_Display").src = "sys_config/config_dept.aspx";
                break;
            }
        case "btn_config_employee":
            {
                document.getElementById("Iframe_Display").src = "sys_config/config_employee.aspx";
                break;
            }
        case "btn_config_role":
            {
                document.getElementById("Iframe_Display").src = "sys_config/config_role.aspx";
                break;
            }
        case "btn_config_process":
            {
                document.getElementById("Iframe_Display").src = "sys_config/config_process.aspx";
                break;
            }
        case "btn_config_recover":
            {
                document.getElementById("Iframe_Display").src = "sys_config/config_recover.aspx";
                break;
            }
        case "btn_config_quit":
            {
                window.close();
                break;
            }
        default:
            {
                break;
            }
            
    }
}
function Return_main() {
    window.location = " ../default.aspx";
}
function Change_MenuState(i) {
    var obj;
    if (i == 0) {
        obj = document.getElementById("div_objmng_container");
        if (obj.style.display == "none") {
            obj.style.display = "block";
            obj = document.getElementById("div_objmng_menu");
            obj.style.backgroundImage = "url(./images/obj_mng_close.png)";
        }
        else {
            obj.style.display = "none";
            obj = document.getElementById("div_objmng_menu");
            obj.style.backgroundImage = "url(./images/obj_mng_open.png)";
        }
    }
    else if (i == 1) {
        obj = document.getElementById("div_processrun_container");
        if (obj.style.display == "none") {
            obj.style.display = "block";
            obj = document.getElementById("div_processrun_menu");
            obj.style.backgroundImage = "url(./images/process_run_close.png)";
        }
        else {
            obj.style.display = "none";
            obj = document.getElementById("div_processrun_menu");
            obj.style.backgroundImage = "url(./images/process_run_open.png)";
        }
    }
    else if (i == 2) {
        obj = document.getElementById("div_dataanalysis_Container");
        if (obj.style.display == "none") {
            obj.style.display = "block";
            obj = document.getElementById("div_dataanysis_nemu");
            obj.style.backgroundImage = "url(./images/data_analysis_close.png)";
        }
        else {
            obj.style.display = "none";
            obj = document.getElementById("div_dataanysis_nemu");
            obj.style.backgroundImage = "url(./images/data_analysis_open.png)";
        }
    }
    else if (i == 3) {
        obj = document.getElementById("div_config_Container");
        if (obj.style.display == "none") {
            obj.style.display = "block";
            obj = document.getElementById("div_config_nemu");
            obj.style.backgroundImage = "url(./images/config_close.png)";
        }
        else {
            obj.style.display = "none";
            obj = document.getElementById("div_config_nemu");
            obj.style.backgroundImage = "url(./images/config_open.png)";
        }
    }
    else if (i == 4) {
        obj = document.getElementById("div_qrystc_container");
        if (obj.style.display == "none") {
            obj.style.display = "block";
            obj = document.getElementById("div_qrystc_menu");
            obj.style.backgroundImage = "url(./images/query_statics_close.png)";
        }
        else {
            obj.style.display = "none";
            obj = document.getElementById("div_qrystc_menu");
            obj.style.backgroundImage = "url(./images/query_statics_open.png)";
        }
    }
    else if (i == 5) {
            obj = document.getElementById("div_docmng_container");
            if (obj.style.display == "none") {
            obj.style.display = "block";
            obj = document.getElementById("div_docmng_menu");
            obj.style.backgroundImage = "url(./images/doc_mng_close.png)";
        }
        else {
            obj.style.display = "none";
            obj = document.getElementById("div_docmng_menu");
            obj.style.backgroundImage = "url(./images/doc_mng_open.png)";
        }
    }
    else { 
    }    
}
function SelectedMenu(i) {
    var obj_BG_disp;
    var obj_Disp;
    var href_array = new Array("./mng/mng_employee.aspx", "./mng/mng_area.aspx", "./mng/mng_room.aspx", "./mng/mng_card.aspx", "./mng/mng_base.aspx", "./mng/mng_dept.aspx");

    obj_BG_disp = document.getElementById("Div_Dispay");
    obj_Disp = document.getElementById("Iframe_Display");
    obj_BG_disp.style.display = "block";
    obj_Disp.src = href_array[i - 1];
}
/*显示选中的流程图*/
function Display_Descript(i) {
    var obj;
    if (str_Selected_index != 0) {
        obj = document.getElementById(str_div[str_Selected_index]);
        obj.style.display = "none";
        obj = document.getElementById(str_div[i]);
        obj.style.display = "block";
        str_Selected_index = i;
    }
    else {
        str_Selected_index = i;
        obj = document.getElementById(str_div[str_Selected_index]);
        obj.style.display = "block";
    }

}
function Prs_Create() {
    document.getElementById("Iframe_Display").src = "process_mng/prs_create.aspx";
}
function Analysis(i) {
    if (i == 1) {
        document.getElementById("Iframe_Display").src = "data_mining/emplyee_mining.aspx";
    }
    else if (i == 2) {
    document.getElementById("Iframe_Display").src = "data_mining/quality_mining.aspx";
    }
    else if (i == 3) {
    document.getElementById("Iframe_Display").src = "data_mining/reality_mining.aspx";
    }
}
function Create_Process() {
    parent.document.getElementById("Iframe_Display").src = "process_mng/process1.aspx?type=create&id=0";
}
function Open_Step(i) {
    var str_img_id = "img_step";
    var str_div_id = "div_step_";
    str_img_id = str_img_id + i.toString();
    str_div_id = str_div_id + i.toString();
    if (document.getElementById(str_img_id).alt == "close") {

            document.getElementById(str_img_id).src = "../images/close.png";
            document.getElementById(str_img_id).alt = "open";
            document.getElementById(str_div_id).style.display = "none";
        }
        else {
            document.getElementById(str_img_id).src = "../images/open.png";
            document.getElementById(str_img_id).alt = "close";
            document.getElementById(str_div_id).style.display = "block";
        }
    }
    function monitor() {
        parent.document.getElementById("Iframe_Display").src = "../monitor.aspx";
    }
