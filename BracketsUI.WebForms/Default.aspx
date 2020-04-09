<%@ Page Title="Check Expression" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BracketsUI.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>You can check your expression for the following html tags: <%: string.Format("{0} {1}", ConfigurationManager.AppSettings["OpenWords"], ConfigurationManager.AppSettings["CloseWords"]) %></p>
    <div class="container">
        <asp:RadioButtonList runat="server" class="radio">
             <asp:ListItem>Check from file</asp:ListItem>
             <asp:ListItem>Check from database</asp:ListItem>
             <asp:ListItem>Check from UI</asp:ListItem>
        </asp:RadioButtonList>
    </div>
</asp:Content>
