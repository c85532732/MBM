<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Crawl.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%=WebExtensions.CombresLink("siteJs") %>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="格式sn" OnClick="Button1_Click" />
        <hr /><br />
       <%-- 条件：<asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal">
           <asp:ListItem Value="1" Selected="True">天数</asp:ListItem>
           <asp:ListItem Value="2">期数</asp:ListItem>
        </asp:RadioButtonList>--%>
         最近：<asp:DropDownList ID="DropDownList1" runat="server">
         <asp:ListItem Value="1">1</asp:ListItem>
         <asp:ListItem Value="3">3</asp:ListItem>
         <asp:ListItem Value="5">5</asp:ListItem>
         <asp:ListItem Value="10">10</asp:ListItem>
         <asp:ListItem Value="30">30</asp:ListItem>
         <asp:ListItem Value="0">全部</asp:ListItem>
        </asp:DropDownList>天        
        号码：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br /><br />
       <input type="hidden" id="hdncbx" value="" />
    <asp:Button ID="Button2" runat="server" Text="匹配" OnClick="Button2_Click" />
    <br />
        
    匹配数据：<asp:ListBox ID="ListBox2" runat="server"  Width="300" Height="400"></asp:ListBox>--
    匹配数据下一期<asp:ListBox ID="ListBox1" runat="server"  Width="300" Height="400"></asp:ListBox>
        <br /><br />
    <div>
        <%=r.ToString() %>
        <br />
        <input type="radio" name="rdoorder" checked="checked" value="all"/>无<input type="radio" name="rdoorder"  value="max"/>最大<input type="radio" name="rdoorder" value="min"/>最小
        删<input type="text" id="delposition"  value=""/> 位（次数相同随机）<br />
        最小超过<input type="text" id="mintime"  value=""/>, 大于<input type="text" id="choosenum"  value=""/>
        <select id="dllminormax">
            <option value="max">最大</option>
            <option value="min">最小</option>
        </select>
       <input type="checkbox" onchange=""
        <input type="text" id="minormaxnum"  value="1"/>
        <input type="button" id="btndel"  value="排除"/><br />
        <textarea id="shownum" style=" width:400px; height:300px;"></textarea>
    </div>
    </form>
     <hr /><br />
         最近：<input type="text" id="txt3" /> 
        <input type="button" id="btn3" value="匹配" />         
        <table border="1" style="width:600px;" id="data">            
           
        </table>
        <div id="result3"></div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
   <br />
   <%-- 排除数字<input type="text" value="" id="delnum"/><input type="button" id="btndel"  value="排除"/><br />
    <textarea id="shownum" style=" width:400px; height:600px;"></textarea>--%>
</body>
</html>
