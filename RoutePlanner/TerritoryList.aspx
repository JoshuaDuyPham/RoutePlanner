<%@ Page Title="Territory" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TerritoryList.aspx.cs" Inherits="RoutePlanner.Territory" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="DBCon">
    <Columns>
        <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
        <asp:BoundField DataField="ShortName" HeaderText="ShortName" SortExpression="ShortName" />
        <asp:BoundField DataField="Owner" HeaderText="Owner" SortExpression="Owner" />
        <asp:BoundField DataField="CheckedOut" HeaderText="CheckedOut" SortExpression="CheckedOut" />
    </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="DBCon" runat="server" ConnectionString="<%$ ConnectionStrings:territoryConnectionString %>" SelectCommand="SELECT [FullName], [ShortName], [Owner], [CheckedOut] FROM [Territory]"></asp:SqlDataSource>

</asp:Content>
