<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RoutePlanner._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <link rel="stylesheet" href="./Content/MapLayout.css">

    <!-- Set up the api for use -->
    <!-- Initialize the map interface -->
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDDtvBH76U9KmJUSaAUTn_AkNxfx2dNGKU&sensor=false"></script>
    <script type="text/javascript" src="./scripts/MapScripts.js"></script>

    <!-- Set up the draggable table -->
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript" src="./scripts/jquery-Events.js"></script>
    
    <table id="Inputs">
        <tr>
            <td>Destination:
                <input id="startvalue" type="text" style="width: 300px"/>
                <input id="Add_Item" type="button" value="Add" /></td>
        </tr>
    </table>

    <table id="control">
        <tr>
            Destination List
        </tr>
        <tr>
            <td>
                <ol id="DestinationList" type="1">
                </ol>
            </td>
            <!-- Trash Can -->
            <td>
                <table>
                    <tr>
                        <td>
                            <div id="TrashCan" class="ui-widget-header">
                                <img src="Trashcan.png" style="width: 100px; height: 100px;" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <!--Calculates the total time and distance between the locations based on the order of the list-->
    <input id="Results" type="button" value="Calculate Route" />
    <!--Calculates the optimal route from the list-->
    <input id="Optimal" type="button" value="Optimal Route" />
    <!--Result Box-->
    <div>
        <p id="Distance">Total Distance: </p>
        <!--<p id="Time">Total Time: </p>-->
    </div>
    <p>Route Summary</p>
    <table>
        <tr>
            <td>
                <div id="directions-panel"></div>
            </td>
            <td>
                <div id="map" style="height: 500px; width: 500px"></div>
            </td>
        </tr>
    </table>
</asp:Content>
