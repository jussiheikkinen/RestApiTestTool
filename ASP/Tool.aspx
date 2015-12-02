<%@ Page Title="Testing Tool" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tool.aspx.cs" Inherits="ASP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="row">
            <div class="col-lg-6"><asp:TextBox AutoCompleteType="BusinessUrl" CssClass="form-control" id="requestUri" placeholder="requested uri" runat="server" /></div>
            <div class="col-lg-3"><div id="keyValuePairTable">
                <asp:Button class="" id="addKeyValuePair" runat="server" Text="Add new parameter key-value pair" onClientClick="addKeyValuePair(); return false;" CssClass="btn btn-default" />
            </div></div>
            <div class="col-lg-3"><div id="headerKeyValuePairTable">
                <asp:Button class="" id="Button1" runat="server" Text="Add new header key-value pair" onClientClick="addHeaderKeyValuePair(); return false;" CssClass="btn btn-default" />
            </div></div>
        </div>
        <div class="row">
            <div class="col-lg-4"><asp:RadioButtonList ID="method" runat="server" CssClass="methodList" RepeatDirection="Horizontal">
                <asp:ListItem Value="post">POST</asp:ListItem>
                <asp:ListItem Value="get">GET</asp:ListItem>
                <asp:ListItem Value="put">PUT</asp:ListItem>
                <asp:ListItem Value="delete">DELETE</asp:ListItem>
            </asp:RadioButtonList></div>
            <div class="col-lg-8"><asp:Button ID="callApi" runat="server" Text="Call API" CssClass="btn btn-primary" OnClick="callApi_Click" /><asp:Button ID="resetForm" runat="server" Text="Reset form" CssClass="btn" /></div>
        </div>
        <fieldset><legend>Response</legend>
            <div class="row">
                <div class="col-lg-4"><div>Status <span class="label label-success" id="resultStatus" runat="server">200 OK</span></div><div>Response size: <span id="resultSize" runat="server">0b</span></div></div>
                <div class="col-lg-8"><asp:TextBox CssClass="form-control" id="result" TextMode="multiline" Columns="50" Rows="5" runat="server" /></div>
            </div>
        </fieldset>

</asp:Content>
