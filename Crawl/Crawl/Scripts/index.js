$(function () {
    $("#btn3").click(function () {
        var num = $.trim($("#txt3").val());
        if (!num) return;
        var url = "webservice/Handler.ashx?t=getdatanum&num=" + num;
        $.ajax({
            type: "POST",
            async: true,
            url: url,
            dataType: 'json',
            success: function (result) {
                var d = result.list;
                showresult3(d);
            },
            error: function () {

            }
        });

    });

    $("#btndel").click(function () {
        var val = ''; var delnum = [];
        var mintime = $.trim($("#mintime").val());
        var choosenum = $.trim($("#choosenum").val());
        var dllminormax_val = $("#dllminormax").val();
        var minormaxnum = $.trim($("#minormaxnum").val()) == "" ? 1 : parseInt($.trim($("#minormaxnum").val()));
       
        var arr_del = $.trim($("#hdncbx").val()).split(',');
        arr_del.shift();

        
        if (minormaxnum > arr_del.length) {
            alert("最大位数必须小于勾选数量");
            return;
        }

        var tmp_choose_val = []; 
        for (var i = 0; i < arr_del.length; i++){
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

        var rdoorder = $("[name='rdoorder']:checked").val();
        var delposition = $.trim($("#delposition").val()) == "" ? 0 : parseInt($.trim($("#delposition").val()));
        

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

    $("[name='cbk']").on("change", function () {
        choosecbk($(this)[0]);
    });
});


function showresult3(list) {
    var html = '';
    var array = {};
    for (var i = 0; i < list.length; i++){
        var d = list[i];
        html += '<tr>';
        html += '<td>'+d.n+'</td>';
        html += '<td>' + d.r + '</td>';
        html += GetZUHTML(d.r);
       
        for (var n = 0; n <= 9; n++) {
            var color = GetColor(d.sn, n);
            var val = n;
            if (i == 0) {
                if (color) {
                    array["t_" + i + "_" + n] = 0;
                } else {
                    array["t_" + i + "_" + n] = 1;
                    val = array["t_" + i + "_" + n];
                }
            } else {
                if (color) {
                    array["t_" + i + "_" + n] = 0;
                } else {
                    array["t_" + i + "_" + n] = parseInt(array["t_" + (i - 1) + "_" + n]) + 1;
                    val = array["t_" + i + "_" + n];
                }
            }           
            html += '<td style="color:' + color + ';" class="t_' + i + '_' + n + '" >' + val + '</td>';
        }
        html += '</tr >';            
    }

    var result3 = '';
    for (var i = 0; i <= 9; i++){       
        result3 +=i + ':' + array["t_" + (list.length - 1) + "_" + i]+"期\r\n";
    }
    $("#result3").html(result3);
    $("#data").html(html);
}



function GetZUHTML(dr) {
    var html = '';
    var r = dr.split(',');
    var qian = [], zhong = [], hou = [];
    qian.push(r[0]);
    qian.push(r[1]);
    qian.push(r[2]);

    zhong.push(r[1]);
    zhong.push(r[2]);
    zhong.push(r[3]);

    hou.push(r[2]);
    hou.push(r[3]);
    hou.push(r[4]);

    var qianl = unique(qian);
    var zhongl = unique(zhong);
    var houl = unique(hou);

    html += '<td>' + qian.toString() + "--" + GETZu(qianl) + '</td>';
    html += '<td>' + zhong.toString() + "--" + GETZu(zhongl) + '</td>';
    html += '<td>' + hou.toString() + "--" + GETZu(houl) + '</td>';
    return html;
}
