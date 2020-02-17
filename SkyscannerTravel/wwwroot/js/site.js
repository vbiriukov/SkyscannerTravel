const latitudeKey = "latidude";
const longitudeKey = "longitude";

function getResponse(url, dataType) {
    return $.ajax({
        url: url,
        method: "GET",
        dataType: dataType,
    });
}

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(SavePosition);
    } else {
        console.log("Geolocation is not supported by this browser.");
    }
}

function SavePosition(position) {
    sessionStorage.setItem(latitudeKey, position.coords.latitude);
    sessionStorage.setItem(longitudeKey, position.coords.longitude);
}

getLocation();