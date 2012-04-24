<%@ 
	Page 
	CodeFile="Console.aspx.cs" 
	Inherits="Console" 
	Language="C#"
%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Console</title>
    <style type="text/css">
        body  { font-family: Sans-Serif; }
        #tblConsole tr.headings th  { text-align: left; }
        #tblConsole { width: 95% }
        #tblConsole th.timestamp, #tblConsole th.machineId  { width: 200px; }
    </style>
    <script type="text/javascript" src="Scripts/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="Objectid.js"></script>
</head>
<body>
<table id="tblConsole" style="border:solid;">
<thead>
  <tr><th class="title" colspan="3">Console Messages</th></tr>
  <tr class="headings"><th class="timestamp">TimeStamp</th><th class="machineId">Machine Id</th><th>Message</th></tr>
</thead>
<tbody>
<asp:Repeater id="consoleLines" runat="server"> 
    <ItemTemplate>
      <tr style="color: <%# ((int)Eval("FileHandle")) == 1 ? "#FF0000" : "#000000" %>">
        <td><%# ((MongoDB.Bson.ObjectId) Eval("Id")).CreationTime %></td>
        <td><%# ((MongoDB.Bson.ObjectId) Eval("Id")).Machine %></td>
        <td><%# Eval("Message") %></td>
      </tr>
    </ItemTemplate>
</asp:Repeater>
</tbody>
</table>
<form method="post" action="Console.aspx"><div>
    <span>Message: <input id="txtMessage" type="text" /><input id="btnMessage" type="button" value="Add Message" /></span><br />
</div></form>
<script type="text/javascript">
    $(document).ready(function () {
        $('#btnMessage').click(function () {
            var message = { Id: new ObjectId(), Message: $('#txtMessage').val(), FileHandle: 0 };
            $.ajax({
                url: 'ConsoleService.svc/JSON/WriteMessage',
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ request: message }),
                dataType: "json",
                success: function (data) {
                    location.reload(true);
                },
                error: function (request, status, error) {
                    console.log("Something Broke");
                }
            });
        });
    });
</script>
</body>
</html>
