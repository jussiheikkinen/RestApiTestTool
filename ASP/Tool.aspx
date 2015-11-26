<%@ Page Title="Testing Tool" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tool.aspx.cs" Inherits="ASP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="row">
            <div class="col-lg-8"><input type="url" name="uri" class="form-control" id="requestUri" placeholder="requested uri" /></div>
            <div class="col-lg-4"><div id="keyValuePairTable">
                <asp:Button class="" id="addKeyValuePair" runat="server" Text="Add new key-value pair" onClientClick="addKeyValuePair(); return false;" CssClass="btn btn-default" />
            </div></div>
        </div>
        <div class="row">
            <div class="col-lg-4">method</div>
            <div class="col-lg-8"><asp:RadioButtonList ID="method" runat="server" CssClass="methodList" RepeatDirection="Horizontal">
                <asp:ListItem Value="post">POST</asp:ListItem>
                <asp:ListItem Value="get">GET</asp:ListItem>
                <asp:ListItem Value="put">PUT</asp:ListItem>
                <asp:ListItem Value="delete">DELETE</asp:ListItem>
            </asp:RadioButtonList></div>
        </div>
        <div class="row"><asp:Button ID="callApi" runat="server" Text="Call API" CssClass="btn btn-primary" OnClick="callApi_Click" /><asp:Button ID="resetForm" runat="server" Text="Reset form" CssClass="btn" /></div>
        <div class="row">
            <div class="col-lg-4"><div>Status: <span style="color: green">200 OK</span></div><div>Response size: <span>0b</span></div></div>
            <div class="col-lg-8"><textarea name="result" id="result" cols="20" rows="10"></textarea></div>
        </div>

</asp:Content>
