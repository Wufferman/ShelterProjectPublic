window.initLeafletMap = (element, coordinates, center, zoom) => {
    var map = L.map(element).setView(center, zoom);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    coordinates.forEach(coord => {
        L.marker(coord).addTo(map);
    });
};
