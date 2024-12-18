import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface City {
  id: number;
  name: string;
}

export interface District {
  id: number;
  name: string;
  cityId: number;
  city: City;
}

export interface Neighborhood {
  id: number;
  name: string;
  districtId: number;
  district: District;
}

export interface Immovable {
  id?: number; // id alanı artık opsiyonel
  block: string;
  parcel: string;
  type: string;
  coordinates: string;
  neighborhoodId: number;
  neighborhood: Neighborhood;
  userId: number;
  user: {
    id: number;
    name: string;
    surname: string;
    email: string;
    phone: string;
    address: string;
    role: string;
  };
}

@Injectable({
  providedIn: 'root',
})
export class ImmovableService {
  private baseUrl = 'https://localhost:5001/api/immovable';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Immovable[]> {
    return this.http.get<Immovable[]>(this.baseUrl);
  }

  create(immovable: Immovable): Observable<Immovable> {
    return this.http.post<Immovable>(this.baseUrl, immovable);
  }

  update(id: number, immovable: Immovable): Observable<Immovable> {
    return this.http.put<Immovable>(`${this.baseUrl}/${id}`, immovable);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

  deleteMultiple(ids: number[]): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/deleteMultiple`, ids);
  }
  
}
