<%@ Title="Results History" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Results.aspx.cs" Inherits="BracketsUI.WebForms.Results" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <asp:ListView runat="server" ID="ResultsHistoryList">
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
            <tr runat="server" id="Tr1">
                <th scope="row"><%# Eval("LogId") %></th>
                <td><%# Eval("Time") %></td>
                <td><i class="fa <%# (bool)Eval("Result") ? "fa-check-circle" : "fa-times-circle" %>"</i></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
