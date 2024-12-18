import { TestBed } from '@angular/core/testing';

import { ImmovableService } from './immovable.service';
export interface Immovable {
  id?: number; // id opsiyonel hale getirildi
  block: string;
  parcel: string;
  type: string;
  coordinates: string;
  neighborhoodId: number;
  userId: number;
}

describe('ImmovableService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ImmovableService = TestBed.get(ImmovableService);
    expect(service).toBeTruthy();
  });
});
