var view = new ol.View({
    center: [52.439056, -4.277868],
    zoom: 2
});

var layer = new ol.layer.Tile({
    source: new ol.source.OSM()
});

var map = new ol.Map({
    target: 'map',
    layers: [layer],
    view: view
});