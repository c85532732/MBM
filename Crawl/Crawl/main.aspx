<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Crawl.main" %>
<%@ Register TagPrefix="uc" TagName="ucHeader" Src="~/Control/header.ascx" %>
<%@ Register TagPrefix="uc" TagName="ucTop" Src="~/Control/top.ascx" %>
<%@ Register TagPrefix="uc" TagName="ucLeft" Src="~/Control/left.ascx" %>
<%@ Register TagPrefix="uc" TagName="ucBottom" Src="~/Control/bottom.ascx" %>
<%@ Register TagPrefix="uc" TagName="ucLayerMain" Src="~/Layer/main.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<%=WebExtensions.CombresLink("siteCss") %>
<link href="Scripts/layer/theme/default/layer.css" rel="stylesheet" />
<%--<%=WebExtensions.CombresLink("indexJs") %>--%>
<script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/common.js"></script>
<script src="Scripts/base.js"></script>
<script src="Scripts/webjs/main.js"></script>
<script src="Scripts/layer/layer.js"></script>
</head>
<body>
<uc:ucLayerMain ID="ucLayerMain" runat="server" />
<uc:ucHeader ID="ucHeader" runat="server" />
<div class="w100 page_main clearfix">
    <uc:ucLeft ID="ucLeft" runat="server" />
    <div class="page_con">
        <div class="external_reference" style="display:none;">
            <div class="top_header clearfix">
            <div class="the_lottery" >
                <span class="item_01">
	        					<a href="">
	        						<img src="images/logo_02.png" alt="" />
	        					</a>
	        					<i></i>
	        				</span>
                <span class="item_02">
	        					<div>合乐分分彩</div>
	        					<p>下期开奖还剩：<time>3:22</time></p>
	        				</span>
                <span class="item_03">
	        					<p>第 <em>0906054</em> 期 开奖：</p>
	        					<ul>
	        						<li>9</li>
	        						<li>7</li>
	        						<li>1</li>
	        						<li>4</li>
	        						<li>0</li>
	        					</ul>
	        				</span>
            </div>
            <div class="bulletin_board clearfix">
                <span class="title">公告栏</span>

                <ul>
                    <li class="on">
                        <a href="">关于免费申请总代账号说明<time>2017-10-20</time></a>
                    </li>
                    <li>
                        <a href="">各平台账号注册总汇(默认最高返点)<time>2017-10-20</time></a>
                    </li>
                    <li>
                        <a href=""></a>
                    </li>
                </ul>
            </div>
        </div>
        </div>
        <div class="external_link_box">
           	<div class="lottery_content">
        			<div class="function_selection">
        				<div class="function_selection_title">
        					<a href="">计划大厅</a>
        					<a class="on" href="">直选三自定义</a>
        				</div>
        				<div class="function_selection_box">
        					<div class="title">
        						<span>功能选择</span>
        					</div>
        					
        					<div class="box">
        						<ul id="ul_fun_list">        							
        							<li class="qspc"><span>历史期数排除</span><a href="javascript:;" id="qspc" class="addfun">添加</a></li>        							
        						</ul>
        						<div class="li_float_con">
									<p>历史期数设定 功能说明：</p>
									<p>根据<i>当前开奖号码的历史同样号码的下一期开奖号</i>进行汽配筛选意思就是历史开出同样号码的下一期开奖号码进行统计</p>
								</div>
        					</div>
        				</div>
        			</div>
        			
        			<div class="content_edit clearfix w100">
        				 <div class="function_edit">
        				 	<div class="title">
        				 		<span>功能编辑</span>
        				 		<ul>
        				 			<li class="btn_1 on"><a href="">GM分析</a></li>
        				 			<li class="btn_2"><a href="">清空</a></li>
        				 			<li class="btn_3"><a href="">开始任务</a></li>
        				 		</ul>
        				 	</div>
        				 	<div class="box" id="div_fun">
        				 		<ul>
        				 			<li>
        				 				<strong>历史期数设定</strong>        				 				
        				 				<span>
        				 					<a href="javascript:;" id="qssd_open_event" >编辑</a>
        				 				</span>
        				 				<time>17/10/19 13：00</time>
        				 			</li>        				 							 			
        				 	</div>
        				 </div>
        				 <div class="number_area">
        				 	<div class="top_box">
        				 		<h2>出号区</h2>
        				 		<div class="box">
        				 			<textarea id="shownum" style=" width:400px; height:300px;"></textarea>
        				 		</div>
        				 		
        				 		<div class="info">
        				 			<span>共计 <em>650</em> 注</span>
        				 			<input type="button" value="复制" />
        				 		</div>
        				 	</div>
        				 	
        				 	
        				 	<div class="bottom_box">
        				 		<h2>概率统计</h2>
        				 		<div class="">
        				 			<ul class="clearfix">
	        				 			<li>第<span>0906054</span>期  前三<em>中</em>中三<em>中</em>后三<i>不中</i></li>
	        				 			<li>第<span>0906054</span>期  前三<em>中</em>中三<em>中</em>后三<i>不中</i></li>
	        				 			<li>第<span>0906054</span>期  前三<em>中</em>中三<em>中</em>后三<i>不中</i></li>
	        				 			<li>第<span>0906054</span>期  前三<em>中</em>中三<em>中</em>后三<i>不中</i></li>
	        				 			<li>第<span>0906054</span>期  前三<em>中</em>中三<em>中</em>后三<i>不中</i></li>
	        				 			<li>第<span>0906054</span>期  前三<em>中</em>中三<em>中</em>后三<i>不中</i></li>
	        				 		</ul>
        				 		</div>
        				 		
        				 		<div class="bth_box">
        				 			<input class="btn" type="button" id="" value="清空" />
        				 		</div>
        				 		
        				 	</div>
        				 </div>
        				 
        			</div>
        		</div>
        </div>
                
    </div>

</div>

<uc:ucBottom ID="ucBottom" runat="server" />
</body>
</html>
