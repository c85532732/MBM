//选项卡 
$(function () {
	$(".change_content .li_box:gt(0)").hide(); 
    $(".jiaocheng_tit_box a").click(function () {
        $(".jiaocheng_tit_box a").removeClass("on");
        $(this).addClass("on");
        var values = $(this).index();
        $(".change_content .li_box").hide();
        $(".change_content .li_box").eq(values).show();
    });

    $(".page_main .page_aside .nav_list dt").click(function () {
        $(this).toggleClass("active");
        $(".page_main .page_aside .nav_list dd").toggle();
    });
});