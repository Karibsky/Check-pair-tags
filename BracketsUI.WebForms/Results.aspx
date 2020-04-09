<%@ Page Title="Results History" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="BracketsUI.WebForms.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:ListView runat="server" ID="ResultsHistoryList" DataSourceID="ResultsDataSource">
        <LayoutTemplate>
            <table runat="server" class="table table-bordered table-hover">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Time</th>
                        <th scope="col">Result</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </thead>
                <tbody></tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr runat="server" id="itemPlaceholder">
                <th scope="row"><%# Eval("LogID") %></th>
                <td><%# Eval("Time") %></td>
                <td><i class="fa <%# (bool)Eval("Result") ? "fa-check-circle" : "fa-times-circle" %>"</i></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="ResultsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:BracketsConnectionString %>" SelectCommand="SELECT * FROM [Logs]"></asp:SqlDataSource>
</asp:Content>
