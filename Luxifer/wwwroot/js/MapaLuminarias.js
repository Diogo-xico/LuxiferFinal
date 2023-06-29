navigator.geolocation.getCurrentPosition(
    function (position) {
        const { latitude } = position.coords;
        const { longitude } = position.coords;

        const coords = [latitude, longitude];

        var map = L.map('map').setView(coords, 13);

        // Adicionar camada de mapeamento
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors',
        }).addTo(map);

        // Iterar sobre a lista de luminárias e adicionar os marcadores ao mapa
        luminarias.forEach(function (luminaria) {
            var latLng = L.latLng(luminaria.latitude, luminaria.longitude);
            L.marker(latLng).addTo(map);
        });
);