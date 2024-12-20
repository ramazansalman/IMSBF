import { Component, OnInit } from '@angular/core';
import OLMap from 'ol/Map';
import View from 'ol/View';
import TileLayer from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';
import { fromLonLat, toLonLat } from 'ol/proj';
import Overlay from 'ol/Overlay';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
  map: OLMap;
  clickedCoordinates: string = ''; // Coordinates in string format
  dmsCoordinates: string = ''; // Coordinates in DMS format
  showInfoBox: boolean = false; // Control the visibility of the info box
  showPopup: boolean = false; // Control the visibility of the "Coordinates Copied" popup
  markerOverlay: Overlay; // Overlay for the marker

  ngOnInit() {
    // Initialize the red marker
    const markerElement = document.createElement('div');
    markerElement.style.width = '10px';
    markerElement.style.height = '10px';
    markerElement.style.backgroundColor = 'red';
    markerElement.style.borderRadius = '50%';
    markerElement.style.position = 'absolute';

    // Create marker overlay
    this.markerOverlay = new Overlay({
      element: markerElement,
      positioning: 'center-center',
      stopEvent: false,
    });

    this.map = new OLMap({
      target: 'map',
      layers: [
        new TileLayer({
          source: new OSM(),
        }),
      ],
      view: new View({
        center: fromLonLat([35.11, 38.50]), // Set initial center to Ankara
        zoom: 7,
        projection: 'EPSG:3857',
      }),
      overlays: [this.markerOverlay], // Add the marker overlay to the map
    });

    this.addClickEvent();
  }

  addClickEvent(): void {
    this.map.on('click', (event) => {
      const coords = toLonLat(event.coordinate); // Get clicked coordinates
      this.clickedCoordinates = `${coords[0].toFixed(6)}, ${coords[1].toFixed(6)}`;
      this.dmsCoordinates = this.convertToDMS(coords);
      this.showInfoBox = true; // Show the info box

      // Set marker position
      this.markerOverlay.setPosition(event.coordinate);
    });
  }

  convertToDMS([lon, lat]: [number, number]): string {
    const formatDMS = (deg: number) => {
      const d = Math.floor(deg);
      const min = Math.floor((deg - d) * 60);
      const sec = Math.round(((deg - d) * 60 - min) * 60);
      return `${d}° ${min}' ${sec}"`;
    };

    return `Longitude: ${formatDMS(lon)}, Latitude: ${formatDMS(lat)}`;
  }

  copyToClipboard(value: string): void {
    if ((navigator as any).clipboard && (navigator as any).clipboard.writeText) {
      (navigator as any).clipboard.writeText(value).then(() => {
        this.showPopup = true; // Show "Coordinates Copied" popup
        setTimeout(() => {
          this.showPopup = false; // Hide the popup after 2 seconds
        }, 2000);
      }).catch((err: any) => {
        console.error('Failed to copy:', err);
      });
    } else {
      // Fallback for older browsers
      const textarea = document.createElement('textarea');
      textarea.value = value;
      textarea.style.position = 'fixed'; // Prevent scrolling to bottom
      document.body.appendChild(textarea);
      textarea.focus();
      textarea.select();
      try {
        document.execCommand('copy');
        console.log('Copied to clipboard (fallback):', value);
      } catch (err) {
        console.error('Fallback: Unable to copy', err);
      }
      document.body.removeChild(textarea);
    }
  }
}
