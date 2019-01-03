var count = 0;
var test = 0;
function InitializeMap() {
    var directionsService = new google.maps.DirectionsService;
    var directionsDisplay = new google.maps.DirectionsRenderer();
    var latlng = new google.maps.LatLng(0, 0);
    var myOptions =
    {
        zoom: 8,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map"), myOptions);

    directionsDisplay.setMap(map);
    directionsDisplay.setPanel(document.getElementById('directionpanel'));

    var control = document.getElementById('control');
    control.style.display = 'block';

    var geocoder = new google.maps.Geocoder();
    document.getElementById('Add').addEventListener('click', function () {
        geocodeAddress(geocoder, map);
    });
    document.getElementById('Results').addEventListener('click', function () {
        totalRoute(directionsService, directionsDisplay);
    });
    document.getElementById('Optimal').addEventListener('click', function () {
        calculateAndDisplayRoute(directionsService, directionsDisplay);
    });
}
function geocodeAddress(geocoder, resultsMap) {
    var address = document.getElementById('address').value;
    var destinationList = document.getElementById('DestinationList');

    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === 'OK') {
            //Add the item
            var listItem = document.createElement("li");
            listItem.appendChild(document.createTextNode(results[0].formatted_address));
            listItem.setAttribute("id", "element" + count); // id
            destinationList.appendChild(listItem);
            count++;
            //Show the item on the screen
            resultsMap.setCenter(results[0].geometry.location);
            var marker = new google.maps.Marker({
                map: resultsMap,
                position: results[0].geometry.location
            });
        } else {
            alert('Geocode was not successful for the following reason: ' + status);
        }
    });
}
/*
function geocodeAddress(geocoder, resultsMap) {
    var address = document.getElementById('address').value;
    var destinationList = document.getElementById('DestinationList');
    
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === 'OK') {
            //Add the item
            var listItem = document.createElement("li");
            listItem.appendChild(document.createTextNode(results[0].formatted_address));
            listItem.setAttribute("id", "element" + count); // id
            destinationList.appendChild(listItem);
            count++;
            //Show the item on the screen
            resultsMap.setCenter(results[0].geometry.location);
            var marker = new google.maps.Marker({
                map: resultsMap,
                position: results[0].geometry.location
            });
        } else {
            alert("Invalid Location");
        }
    });
}
*/
//Calculates the total time and distance of the route
function totalRoute(directionsService, directionsDisplay) {
    var innerlocations = [];
    var ul = document.getElementById("DestinationList");
    var locations = ul.getElementsByTagName("li");
    var totaldistance = 0;
    if (locations.length >= 2) {
        for (var i = 1; i < locations.length - 1; i++) {
            innerlocations.push({
                location: locations[i].textContent,
                stopover: true
            });
        }
        directionsService.route({
            origin: locations[0].textContent,
            destination: locations[locations.length - 1].textContent,
            waypoints: innerlocations,
            travelMode: 'DRIVING'
        }, function (response, status) {
            if (status === 'OK') {
                directionsDisplay.setDirections(response);
                var route = response.routes[0];
                var summaryPanel = document.getElementById('directions-panel');
                summaryPanel.innerHTML = '';
                // For each route, display summary information.
                for (var i = 0; i < route.legs.length; i++) {
                    var routeSegment = i + 1;
                    summaryPanel.innerHTML += '<b>Route Segment: ' + routeSegment +
                        '</b><br> Start:';
                    summaryPanel.innerHTML += route.legs[i].start_address + '<br> End:';
                    summaryPanel.innerHTML += route.legs[i].end_address + '<br>';
                    summaryPanel.innerHTML += route.legs[i].distance.text + '<br><br>';
                    totaldistance += parseFloat(route.legs[i].distance.text);
                }
                document.getElementById("Distance").textContent = "Total Distance: " + totaldistance + " mi";
            } else {
                alert('Directions request failed due to ' + status);
            }

        });
    }
    else
        alert("Please Enter more than one location");
}
//Finds the optimal route
function calculateAndDisplayRoute(directionsService, directionsDisplay) {
    var innerlocations = [];
    var ul = document.getElementById("DestinationList");
    var locations = ul.getElementsByTagName("li");
    var totaldistance = 0;
    if (locations.length >= 2) {
        for (var i = 1; i < locations.length - 1; i++) {
            innerlocations.push({
                location: locations[i].textContent,
                stopover: true
            });
        }
        directionsService.route({
            origin: locations[0].textContent,
            destination: locations[locations.length - 1].textContent,
            waypoints: innerlocations,
            optimizeWaypoints: true,
            travelMode: 'DRIVING'
        }, function (response, status) {
            if (status === 'OK') {
                directionsDisplay.setDirections(response);
                var route = response.routes[0];
                var summaryPanel = document.getElementById('directions-panel');
                summaryPanel.innerHTML = '';
                // For each route, display summary information.
                for (var i = 0; i < route.legs.length; i++) {
                    var routeSegment = i + 1;
                    summaryPanel.innerHTML += '<b>Route Segment: ' + routeSegment +
                        '</b><br> Start:';
                    summaryPanel.innerHTML += route.legs[i].start_address + '<br> End:';
                    summaryPanel.innerHTML += route.legs[i].end_address + '<br>';
                    summaryPanel.innerHTML += route.legs[i].distance.text + '<br><br>';
                    totaldistance += parseFloat(route.legs[i].distance.text);
                }
                document.getElementById("Distance").textContent = "Total Distance: " + totaldistance + " mi";
            } else {
                alert('Directions request failed due to ' + status);
            }

        });
    }
    else
        alert("Please Enter more than one location");
}
//autocomplete the object based on the user's geographical location,
/*
function geolocate() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var geolocation = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            var circle = new google.maps.Circle({
                center: geolocation,
                radius: position.coords.accuracy
            });
            autocomplete.setBounds(circle.getBounds());
        });
    }
}
*/
window.onload = InitializeMap;