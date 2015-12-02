<%@ Page Title="About API" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ASP.About" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>REST API Testing Tool for Tuulari data</h3>
    <section>
        <h4>About API</h4>
        <p>The API is used for our Android app. It uses basic HTTP methods (POST, GET, PUT and DELETE) to create, read, update and delete (CRUD) data from MSSQL database.</p>
        <h4>Endpoints</h4>
        <p><a href="http://tuulari-001-site1.atempurl.com/api/About/Endpoints">Endpoints</a> can be fecthed here.</p>
    </section>
    <section>
        <h4>This tool</h4>
        <p>This tool is a ASP.NET version of our API testing tool. There is also a WPF version.</p>
    </section>
</asp:Content>