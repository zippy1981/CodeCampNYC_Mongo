<%@ 
	Page 
	CodeFile="Console.aspx.cs" 
	Inherits="Console" 
	Language="C#"
%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Console</title>
</head>
<body>
<table style="border:solid;">
<thead>
  <tr><th colspan="2">Console Messages</th></tr>
  <tr><th>TimeStamp</th><th>Message</th></tr>
</thead>
<tbody>
<asp:Repeater id="consoleLines" runat="server"> 
    <ItemTemplate>
      <tr style="color: <%# ((int)Eval("FileHandle")) == 1 ? "#FF0000" : "#000000" %>">
        <td><%# ((MongoDB.Bson.ObjectId) Eval("Id")).CreationTime %>
        </td><td><%# Eval("Message") %></td>
      </tr>
    </ItemTemplate>
</asp:Repeater>
</tbody>
</table>
</body>
</html>
