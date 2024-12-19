import { Component, OnInit } from '@angular/core';
import OLMap from 'ol/Map';
import View from 'ol/View';
import TileLayer from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';
import { fromLonLat } from 'ol/proj';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
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
        center: fromLonLat([35.11, 38.50]), // Ankara
        zoom: 7,
        projection: 'EPSG:3857'
      })
      
    });
  }
}

