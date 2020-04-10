<%@ Page Title="Check Expression" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BracketsUI.WebForms._Default" ValidateRequest="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>You can check your expression for the following html tags:</p>
    <asp:BulletedList ID="TagsList" runat="server"></asp:BulletedList>

    <a class="btn btn-primary" href="#file" data-toggle="collapse" data-target="#from_file">Check from file</a>
    <a class="btn btn-primary" href="#database" data-toggle="collapse" data-target="#from_database">Check from database</a>
    <a class="btn btn-primary" href="#ui" data-toggle="collapse" data-target="#from_ui">Check from ui</a>

    <div id="from_file" class="collapse">
        <asp:FileUpload ID="FileUpload" runat="server" multiple="false" />
        <asp:Button ID="File" runat="server" Text="Check Expression" CssClass="btn btn-success" OnClick="FileButton_Click" />
    </div>
    <div id="from_database" class="collapse">
        <asp:Label runat="server" Text="Enter database record id"></asp:Label>
        <asp:TextBox ID="RecordID" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="Database" runat="server" Text="Check Expression" CssClass="btn btn-success" OnClick="DatabaseButton_Click" />
    </div>
    <div id="from_ui" class="collapse">
        <asp:Label runat="server" Text="Enter text to verify"></asp:Label>
        <asp:TextBox ID="Expression" runat="server" CssClass="form-control" TextMode="multiline" Columns="100" Rows="10" style="resize:none"></asp:TextBox>
        <asp:Button ID="UI" runat="server" Text="Check Expression" CssClass="btn btn-success" OnClick="UIButton_Click" />
    </div>
    <hr />
    <asp:Label runat="server" ID="StatusLabel" />

    <script type="text/javascript">
        $('.collapse').on('show.bs.collapse', function () {
            $('.collapse.in').each(function () {
                $(this).collapse('hide');
            });
        });
    </script>
</asp:Content>


