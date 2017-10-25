function PrefixInteger(num, length) {
    return (Array(length).join('0') + num).slice(-length);
}

function unique(arr) {
    var tmp = new Array();
    for (var i in arr) {
        if (tmp.indexOf(arr[i]) == -1) {
            tmp.push(arr[i]);
        }
    }
    return tmp;
}


function GetColor(indata, num) {
    if (indata.indexOf(num) >= 0) {
        return 'red';
    }
    return "";
}


function GETZu(l) {
    var r;
    switch (l.length) {
        case 3:
            r = "组六";
            break;
        case 2:
            r = "组三";
            break;
        case 1:
            r = "豹子";
            break;
    }
    return r;
}

function choosecbk(el) {
    var check =el.checked;
    var v = $("#hdncbx").val();
    var val = el.value;
    if (check) {
        v = v + "," + val;
    } else {
        v = v.replace(","+val,"");
    }      
    $("#hdncbx").val(v);

}

function GetMaxOrMin(ty,num) {
    var result = [];
    var arr_num;
    switch (ty) {
        case "all":
            result = "";
            break;
        case "max":
            if (num && num > 1) {
                var val_arr = [];
                var val = $("[name='cbk']:first").attr("val");
                $("[name='cbk']").each(function () {
                    var el_val = $(this).attr("val");
                    var el_key = $(this).val();
                    if (el_val == val) {
                        val_arr.push(el_key);
                    }
                });                
                if (num > val_arr.length) {
                    for (var i = 0; i < val_arr.length; i++) {
                        result.push(val_arr[i]);
                    }
                } else {
                    result=getRandomFromArray(val_arr, num);
                }
            } else {
                arr_num = $("[name='cbk']:first").val();
                result.push(arr_num);
            }
            
            break;
        case "min":
            if (num && num > 1) {
                var val_arr = [];
                var val = $("[name='cbk']:last").attr("val");
                $("[name='cbk']").each(function () {
                    var el_val = $(this).attr("val");
                    var el_key = $(this).val();
                    if (el_val == val) {
                        val_arr.push(el_key);
                    }
                });
                if (num > val_arr.length) {
                    for (var i = 0; i < val_arr.length; i++) {
                        result.push(val_arr[i]);
                    }
                } else {
                    result = getRandomFromArray(val_arr, num);
                }
            } else {
                arr_num = $("[name='cbk']:last").val();
                result.push(arr_num);
            }            
            break;
    }
    return result;

}

function getRandomFromArray(arr, num) {
    var temp_array = new Array();
    for (var index in arr) {
        temp_array.push(arr[index]);
    }
    var return_array = new Array();
    for (var i = 0; i < num; i++) {
        if (temp_array.length > 0) {
            var arrIndex = Math.floor(Math.random() * temp_array.length);
            return_array[i] = temp_array[arrIndex];
            temp_array.splice(arrIndex, 1);
        } else {
            break;
        }
    }
    return return_array;
}