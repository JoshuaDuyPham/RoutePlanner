//Autocomplete Address
function init() {
    new google.maps.places.Autocomplete(document.getElementById('startvalue'));
}
google.maps.event.addDomListener(window, 'load', init);