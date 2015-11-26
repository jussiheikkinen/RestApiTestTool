<%@ Page Title="Testing Tool" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tool.aspx.cs" Inherits="ASP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form" runat="server">

        <div class="form-group">
            <div class="input-group">
                <select id="connectionProtocol">
                    <option value="http">http://</option>
                    <option value="https" disabled>https://</option>
                </select>
                <input type="url" id="connectionUri" placeholder="selected uri without protocol" />
            </div>
        </div>

        <asp:Table ID="keyValuePairTable" runat="server">
            <asp:TableHeaderRow><asp:TableHeaderCell Text="Key" /><asp:TableHeaderCell Text="Value"></asp:TableHeaderCell></asp:TableHeaderRow>
            <asp:TableFooterRow><asp:TableCell ColumnSpan="2"><asp:Button ID="addKeyValuePair" runat="server" Text="Add new key-value pair" OnClick="addKeyValuePair_Click" /></asp:TableCell></asp:TableFooterRow>
        </asp:Table>

        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="methodList" RepeatDirection="Horizontal">
            <asp:ListItem Value="post">POST</asp:ListItem>
            <asp:ListItem Value="get">GET</asp:ListItem>
            <asp:ListItem Value="put">PUT</asp:ListItem>
            <asp:ListItem Value="delete">DELETE</asp:ListItem>
        </asp:RadioButtonList>

        <div class="row">
            <div class="col-lg-4">Status: <span style="color: green">200 OK</span></div>
            <div class="col-lg-8"><textarea id="result" cols="20" rows="10"></textarea></div>
        </div>

        <asp:Button ID="callApi" runat="server" Text="Call API" /><asp:Button ID="resetForm" runat="server" Text="Reset form" />
    </form>

</asp:Content>
