<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="main.ascx.cs" Inherits="Crawl.Layer.main" %>
<script type="text/html" class="qssd_layer">
    最近<input type="text" id="qssd_num" value="" />期 <br />
    <input type="button" id="qssd_save" value="保存" />
</script>

<script type="text/html" class="qspc_layer">
<div class="title">
    <span>历史二期排除</span>根据<i>当前开奖号码的历史下一期开奖号</i>进行匹配筛选
</div>
<div class="sele">
    <h2>出现次数位置筛选<i>(以下位数是当前<label id="qssd_num"></label> 期出现次数从大到小排列的数字)</i></h2>
    <ul class="clearfix" id="cbx_qs_ul">
                          
    </ul>
</div>
<div class="input_box">
    <input type="hidden" id="hdncbx" value="" />
<input type="radio" name="rdoorder" checked="checked" value="all"/>无<input type="radio" name="rdoorder"  value="max"/>最大<input type="radio" name="rdoorder" value="min"/>最小
删<input type="text" id="delposition"  value=""/> 位（次数相同随机）<br />
最小超过<input type="text" id="mintime"  value=""/>, 大于<input type="text" id="choosenum"  value=""/>
<select id="dllminormax">
    <option value="max">最大</option>
    <option value="min">最小</option>
</select>
<input type="text" id="minormaxnum"  value="1"/>
<input type="button" id="btndel"  value="排除"/><br />
</div>


</script>
