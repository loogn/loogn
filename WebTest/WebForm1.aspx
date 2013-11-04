<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebTest.WebForm1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
    <div>
    k1:<%=Request["k1"] %><br />
    k2:<%=Request["k2"] %><br />
    k3:<%=Request["k3"] %><br />
    
    </div>
    </form>
</body>

</html>
