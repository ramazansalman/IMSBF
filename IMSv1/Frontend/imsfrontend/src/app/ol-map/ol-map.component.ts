import { Component, OnInit, AfterViewInit } from '@angular/core';
// Avoid overlapping by using a unique name for the map
import OLMap from 'ol/Map';
import View from 'ol/View';
import TileLayer from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';
import { fromLonLat } from 'ol/proj';

@Component({
  selector: 'app-ol-map',
  templateUrl: './ol-map.component.html',
  styleUrls: ['./ol-map.component.css']
})

export class OlMapComponent implements OnInit {
  map: OLMap;
  ngOnInit() {
    this.map = new OLMap({
      target: 'map',
      layers: [
        new TileLayer({
          source: new OSM()
        })
      ],
      view: new View({
        //center: [3654512.89, 4441163.96], // Turkey (EPSG:3857)
        center: fromLonLat([32.866287, 39.925533]), // Ankara
        zoom: 7,
        projection: 'EPSG:3857'
      })
      
    });
  }
}
console.log(fromLonLat([32.866287, 39.925533]));
/**
export class OlMapComponent implements AfterViewInit {
  map: OLMap;

  ngAfterViewInit() { // DOM yüklendikten sonra çalışır
    setTimeout(() => { // Harita başlatma gecikmesini çözmek için
      this.map = new OLMap({
        target: 'map',
        layers: [
          new TileLayer({
            source: new OSM()
          })
        ],
        view: new View({
          center: fromLonLat([32.866287, 39.925533]), // Ankara koordinatları
          zoom: 7, // Yakınlaştırma seviyesi
          projection: 'EPSG:3857'
        })
      });
    }, 0);
  }
}
*/