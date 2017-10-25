$(function () {
    $(".addfun").click(function () {
        var fun = $(this).attr("id");
        var fun_html = getFunStr(fun);
        $("#div_fun").append(fun_html);
        $(this).parents("li").hide();
    });

    $("#div_fun").on("click", ".fun_del", function () {
        var fun = $(this).attr("funname");
        $(this).parents("li").remove();
        $("#ul_fun_list").find('.' + fun).show();
    });

    

    $("#qssd_open_event").click(function () {
        layer.open({
            title: "历史期数设置",
            type: 1,
            skin: 'custom-pend',        
            content: $('.qssd_layer').html(),
            success: function (layero) {
                $(layero).find("#qssd_save").click(function () {
                    var num = $.trim($(layero).find("#qssd_num").val());
                    if (!num) return;

                    qssd();
                    layer.closeAll();
                });
            }
        });
    });

    $("#div_fun").on("click", ".edit_open_layer", function () {
        var fun = $(this).attr("funname");        
        layer.open({
            title: "历史期数排除",
            type: 1,
            skin: 'custom-pend',      
            content: $('.' + fun+'_layer').html(),
            success: function (layero) {
                switch (fun) {
                    case "qspc":
                        qspc(layero);
                        break;
                }
            }
        });
    });
   
});

function getFunStr(fun) {
    var str = '<li>';
    str += ' <strong>@name@</strong>';
    str += '<span>';
    str += '<a href="javascript:;" class="edit_open_layer" funname="@funname@">编辑</a>';
    str += '<a href="javascript:;" class="fun_del" funname="@funname@">删除</a>';
    str += '</span>';
    str += '<time>17/10/19 13：00</time>';
    str += '</li >';
    var name = '';
    var funname = '';
    switch (fun) {
        case "qspc":
            name = '历史期数排除';
            funname = "qspc"; 
            break;
    }
    str = str.replace("@name@", name);
    str = str.replace(/@funname@/g, funname);
    return str;
}

function qssd(callback) {
    var url = "webservice/Handler.ashx?t=getqssddata&num=" + num + "&sn=";
    $.ajax({
        type: "POST",
        async: true,
        url: url,
        dataType: 'json',
        success: function (result) {
            window.localStorage.setItem("qssd_data", JSON.stringify(result));
            if (callback) {
                callback();
            }
        },
        error: function () {

        }
    });
}


function qspc(layero) {
    var d = JSON.parse(window.localStorage.getItem("qssd_data"));
    if (!d) return;
    $(layero).find("#qssd_num").html(d.count);
    var list = d.list;
    var html = '';
    for (var i in list) {
        var num = list[i].num
        var str = list[i].d.split('|');
        html += ' <li>';
        html += ' <input type="checkbox" name="cbx" value="' + num + '|' + str[0] + '"  val="' + str[0] + '" onchange="choosecbk(this)"/>第' + (parseInt(i) + 1) + '位 <i>' + num + '</i>：' + str[0] + '(+' + str[1] + ')次';
        html += ' </li>   ';
    }
    $(layero).find("#cbx_qs_ul").html(html);

    $(layero).find("#btndel").click(function () {
        var val = ''; var delnum = [];
        var mintime = $.trim($(layero).find("#mintime").val());
        var choosenum = $.trim($(layero).find("#choosenum").val());
        var dllminormax_val = $(layero).find("#dllminormax").val();
        var minormaxnum = $.trim($(layero).find("#minormaxnum").val()) == "" ? 1 : parseInt($.trim($(layero).find("#minormaxnum").val()));

        var arr_del = $.trim($(layero).find("#hdncbx").val()).split(',');
        arr_del.shift();


        if (minormaxnum > arr_del.length) {
            alert("最大位数必须小于勾选数量");
            return;
        }

        var tmp_choose_val = [];
        for (var i = 0; i < arr_del.length; i++) {
            var d = arr_del[i].split('|');
            if (d[1] > mintime) {
                tmp_choose_val.push(d[0]);
            }
        }
        if (mintime) {
            if (tmp_choose_val.length < choosenum) {
                $("#shownum").val("本期不投注");
                return;
            } else {
                if (dllminormax_val == "max") {
                    if (minormaxnum > tmp_choose_val.length) minormaxnum = tmp_choose_val.length;
                    for (var i = 0; i < minormaxnum; i++) {
                        delnum.push(tmp_choose_val[i]);
                    }
                } else {
                    if (minormaxnum > tmp_choose_val.length) minormaxnum = 0;
                    for (var i = tmp_choose_val.length - 1; i >= (minormaxnum - 1); i--) {
                        delnum.push(tmp_choose_val[i]);
                    }
                }

            }
        } else {
            delnum = tmp_choose_val;
        }

        var rdoorder = $(layero).find("[name='rdoorder']:checked").val();
        var delposition = $.trim($(layero).find("#delposition").val()) == "" ? 0 : parseInt($.trim($(layero).find("#delposition").val()));


        var ordernum = GetMaxOrMin(rdoorder, delposition);
        if (ordernum) {
            delnum.push(ordernum);
        }
        //delnum.shift();
        for (var i = 0; i <= 999; i++) {
            var isindex = false;
            for (var n = 0; n < delnum.length; n++) {
                var m = delnum[n];
                if (m.indexOf(i.toString()) >= 0) {
                    isindex = true;
                    break;
                }

                if (i.toString().indexOf(m) >= 0) {
                    isindex = true;
                    break;
                }

            }
            if (isindex) continue;

            var innum = PrefixInteger(i, 3);
            val += innum + "\t";

        }
        $("#shownum").val(val);;
    });
}