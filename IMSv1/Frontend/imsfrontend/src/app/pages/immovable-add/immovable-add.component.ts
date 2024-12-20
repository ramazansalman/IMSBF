import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import OLMap from 'ol/Map';
import View from 'ol/View';
import TileLayer from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';
import { fromLonLat, toLonLat } from 'ol/proj';
import Overlay from 'ol/Overlay';

@Component({
  selector: 'app-immovable-add',
  templateUrl: './immovable-add.component.html',
  styleUrls: ['./immovable-add.component.css'],
})
export class ImmovableAddComponent implements OnInit {
  cities: any[] = [];
  districts: any[] = [];
  neighborhoods: any[] = [];
  selectedCity: number | null = null;
  selectedDistrict: number | null = null;
  newImmovable: any = { block: '', parcel: '', type: '', coordinates: '', neighborhoodId: null };
  map: OLMap | undefined;
  markerOverlay: Overlay | undefined;

  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit() {
    this.loadCities();
    this.initializeMap();
  }

  loadCities() {
    this.http.get<any[]>('https://localhost:5001/api/city').subscribe((data) => {
      this.cities = data;
    });
  }

  onCityChange(cityId: number) {
    this.selectedCity = cityId;
    this.districts = [];
    this.neighborhoods = [];
    this.newImmovable.neighborhoodId = null; // Reset neighborhood selection
    this.http.get<any[]>(`https://localhost:5001/api/district/by-city/${cityId}`).subscribe((data) => {
      this.districts = data;
    });
  }

  onDistrictChange(districtId: number) {
    this.selectedDistrict = districtId;
    this.neighborhoods = [];
    this.newImmovable.neighborhoodId = null; // Reset neighborhood selection
    this.http.get<any[]>(`https://localhost:5001/api/neighborhood/by-district/${districtId}`).subscribe((data) => {
      this.neighborhoods = data;
    });
  }

  initializeMap(): void {
    // Create marker overlay
    const markerElement = document.createElement('div');
    markerElement.style.width = '10px';
    markerElement.style.height = '10px';
    markerElement.style.backgroundColor = 'red';
    markerElement.style.borderRadius = '50%';
    markerElement.style.position = 'absolute';

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
        center: fromLonLat([35.11, 38.50]), // Default coordinates (Turkey center)
        zoom: 7,
        projection: 'EPSG:3857',
      }),
      overlays: [this.markerOverlay], // Add the marker overlay
    });

    this.map.on('click', (event) => {
      const coords = toLonLat(event.coordinate);
      this.newImmovable.coordinates = `${coords[1].toFixed(6)}, ${coords[0].toFixed(6)}`;
      this.markerOverlay.setPosition(event.coordinate); // Set marker position
    });
  }

  save() {
    const payload = {
      block: this.newImmovable.block,
      parcel: this.newImmovable.parcel,
      type: this.newImmovable.type,
      coordinates: this.newImmovable.coordinates,
      neighborhoodId: this.newImmovable.neighborhoodId,
      userId: 1, // Example user ID
    };

    if (!payload.block || !payload.parcel || !payload.type || !payload.coordinates || !payload.neighborhoodId || !payload.userId) {
      alert('All fields are required. Please fill in all the details.');
      return;
    }

    this.http.post('https://localhost:5001/api/immovable', payload).subscribe(
      () => {
        alert('Immovable added successfully');
        this.router.navigate(['/immovable']);
      },
      (error) => {
        console.error('Error adding immovable:', error);
        alert('Failed to add immovable. Please check your data and try again.');
      }
    );
  }

  cancel() {
    this.router.navigate(['/immovable']);
  }

  clearCoordinates(): void {
    this.newImmovable.coordinates = ''; // Clear the textbox
    if (this.markerOverlay) {
      this.markerOverlay.setPosition(undefined); // Remove the red marker
    }
  }
  
}
