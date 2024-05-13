<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeFile="UserPage.aspx.cs" Inherits="Account_UserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <h1>Your Bills</h1>
    <link href="~/Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <h3 id="Greeting" runat="server"></h3>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="PaymentBill" 
                AutoGenerateColumns="false"
                AutoGenerateEditButton="true"
                runat="server" 
                DataKeyNames="PaymentBillId"
                OnRowEditing="OnRowEditing"
                OnRowCancelingEdit="OnRowCancelEdit"
                OnRowUpdating="OnRowUpdating" 
                OnRowDataBound="OnRowDataBound"
                OnRowCommand="PayBillCommand"
                Height="223px" Width="1353px">
                <Columns>
                    <asp:BoundField ReadOnly="true" DataField="PaymentBillId" HeaderText="Payment Bill Id" />
                    <asp:BoundField ReadOnly="true" DataField="ServiceName" HeaderText="Service Name" />
                    <asp:BoundField ReadOnly="true" DataField="Amount" HeaderText="Amount" />
                    <asp:BoundField ReadOnly="true" DataField="IssueDate" HeaderText="Issue Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField ReadOnly="true" DataField="DueToDate" HeaderText="Due To Date" DataFormatString="{0:yyyy-MM-dd}" /> 
                    <asp:BoundField ReadOnly="true" DataField="PaymentDate" HeaderText="Payment Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="PaymentReceipt" HeaderText="Payment Receipt"/>
                    <asp:BoundField ReadOnly="true" DataField="PaymentStatus" HeaderText="Payment Status" /> 
                    <asp:TemplateField HeaderText="PaymentButton">
                        <ItemTemplate>
                            <asp:Button 
                                ID="btnPay" 
                                runat="server" 
                                Text="PAY BILL" 
                                Visible="true" 
                                CommandName="PayBill" 
                                CommandArgument='<%# Eval("PaymentBillId")+"," + Eval("PaymentReceipt") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
               </Columns>
            </asp:GridView>
        </div>
    </form>
   
</body>
</html>
