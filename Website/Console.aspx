<%@ 
	Page 
	CodeFile="EventSummary.aspx.cs" 
	Inherits="admin.EventSummary" 
	Language="C#"
%> <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Console</title>
</head>
<body>

<asp:Repeater id="consoleLines" runat="server"> 
    <ItemTemplate>
      <id><%# Eval("Id") %></id>
    </ItemTemplate>
</asp:Repeater>
</body>
</html>
