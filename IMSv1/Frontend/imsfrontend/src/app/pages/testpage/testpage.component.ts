/** this is my test page and my new codes will be test here before adding route as a page*/
import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-testpage',
  templateUrl: './testpage.component.html',
  styleUrls: ['./testpage.component.css']
})
export class TestpageComponent implements OnInit {

  constructor(private modalService: NgbModal) {}

  ngOnInit() {
  }

  openModal(content: any) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }

}

export class AppComponent {
  cities = [];
  districts = [];
  neighborhoods = [];

  selectedCity: number | null = null;
  selectedDistrict: number | null = null;

  newImmovable = {
    block: '',
    parcel: '',
    type: '',
    coordinates: '',
    neighborhoodId: null,
    userId: 1 // Login olan user id.
  };

  constructor(private modalService: NgbModal, private http: HttpClient) {}

  openModal(content: any) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
    this.loadCities();
  }

  loadCities() {
    this.http.get('API_URL_TO_GET_CITIES').subscribe((data: any) => {
      this.cities = data;
    });
  }

  onCityChange(cityId: number) {
    this.selectedCity = cityId;
    this.districts = [];
    this.neighborhoods = [];
    this.http.get(`API_URL_TO_GET_DISTRICTS_BY_CITY/${cityId}`).subscribe((data: any) => {
      this.districts = data;
    });
  }

  onDistrictChange(districtId: number) {
    this.selectedDistrict = districtId;
    this.neighborhoods = [];
    this.http.get(`API_URL_TO_GET_NEIGHBORHOODS_BY_DISTRICT/${districtId}`).subscribe((data: any) => {
      this.neighborhoods = data;
    });
  }

  saveImmovable(formData: any) {
    this.http.post('API_URL_TO_SAVE_IMMOVABLE', { ...formData, userId: this.newImmovable.userId }).subscribe(() => {
      alert('Immovable saved successfully!');
    });
  }
}