<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTSession.aspx.cs" Inherits="AlphaTechMIS.Areas.Att.Report.RPTSession" %>

<%@ Register namespace="Microsoft.Reporting.WebForms" tagprefix="WebForms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      <table border="0">
          <tr>
              <td width="18%"></td>
              <td width="70%">
                  <form id="form1" runat="server">
                      <asp:ScriptManager ID="ScriptManager1" runat="server">
                      </asp:ScriptManager>
                      <WebForms:ReportViewer ID="ReportViewer1" runat="server" BorderColor="LightGray" BorderStyle="Ridge" BorderWidth="1px" Height="590px" width="100%"></WebForms:ReportViewer>
                  </form>
              </td>
              <td width="12%"></td>

          </tr>
      </table>
</body>
</html>
