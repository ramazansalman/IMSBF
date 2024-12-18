import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Immovable {
  id?: number; // id alanı artık opsiyonel
  block: string;
  parcel: string;
  type: string;
  coordinates: string;
  neighborhoodId: number;
  userId: number;
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
}
