<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTerritory.aspx.cs" Inherits="RoutePlanner.AddTerritory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table id="Inputs">
        <tr>
            <td>
                <h1>Add a Territory</h1>
            </td>
        </tr>
        <tr>
            <td>
                <label for="ID">ID: </label>
                <asp:TextBox ID="TerritoryID" runat="server" size="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label for="FullName">Name: </label>
                <asp:TextBox ID="FNameInput" runat="server" size="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label for="ShortName">Abbreviation: </label>
                <asp:TextBox ID="SNameInput" runat="server" size="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" AutoPostBack="true" />
            </td>
        </tr>

    </table>
</asp:Content>
