import { Component, OnInit } from '@angular/core';
import { ImmovableService, Immovable } from '../../services/immovable.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-immovable',
  templateUrl: './immovable.component.html',
  styleUrls: ['./immovable.component.css'],
})
export class ImmovableComponent implements OnInit {
  immovables: (Immovable & { cityName: string; districtName: string; neighborhoodName: string })[] = [];
  selectedImmovables: Set<number> = new Set();
  newImmovable: Partial<Immovable> | null = null;
  isFormOpen: boolean = false;

  constructor(private immovableService: ImmovableService, private router: Router) {}

  ngOnInit(): void {
    this.loadData();
  }

  // loadData() {
  //   this.immovableService.getAll().subscribe(
  //     (data: Immovable[]) => {
  //       this.immovables = data.map((immovable) => ({
  //         ...immovable,
  //         cityName: immovable.neighborhood.district.city.name,
  //         districtName: immovable.neighborhood.district.name,
  //         neighborhoodName: immovable.neighborhood.name,
  //       }));
  //       this.selectedImmovables = new Set(
  //         Array.from(this.selectedImmovables).filter(id =>
  //           this.immovables.some(immovable => immovable.id === id)
  //         )
  //       );
  //     },
  //     (error) => {
  //       console.error('Error loading immovables:', error);
  //       alert('Failed to load immovables. Please try again later.');
  //     }
  //   );
  // }
  loadData() {
    this.immovableService.getAll().subscribe(
      (data: Immovable[]) => {
        this.immovables = data.map((immovable) => ({
          ...immovable,
          cityName: immovable.neighborhood.district.city.name,
          districtName: immovable.neighborhood.district.name,
          neighborhoodName: immovable.neighborhood.name,
        }));
      },
      (error) => {
        console.error('Error loading immovables:', error);
        alert('Failed to load immovables. Please try again later.');
      }
    );
  }
  

  toggleForm() {
    this.isFormOpen = !this.isFormOpen;
    if (this.isFormOpen) {
      this.newImmovable = {
        block: '',
        parcel: '',
        type: '',
        coordinates: '',
        neighborhoodId: 1,
        userId: 1,
      };
    } else {
      this.newImmovable = null;
    }
  }

  createImmovable() {
    if (this.newImmovable) {
      this.immovableService.create(this.newImmovable as Immovable).subscribe(() => {
        this.newImmovable = null;
        this.isFormOpen = false;
        this.loadData();
        this.router.navigate(['/immovable']);
      });
    }
  }

  deleteImmovable(id: number) {
    this.immovableService.delete(id).subscribe(() => {
      this.loadData();
    });
  }

  toggleSelection(id: number): void {
    if (this.selectedImmovables.has(id)) {
      this.selectedImmovables.delete(id);
    } else {
      this.selectedImmovables.add(id);
    }
  }

  toggleAll(event: Event): void {
    const isChecked = (event.target as HTMLInputElement).checked;

    if (isChecked) {
      this.selectedImmovables = new Set(this.immovables.map(immovable => immovable.id));
    } else {
      this.selectedImmovables.clear();
    }
  }

  deleteSelected() {
    const ids = Array.from(this.selectedImmovables);
    this.immovableService.deleteMultiple(ids).subscribe(
      () => {
        this.loadData();
        this.selectedImmovables.clear();
      },
      (error) => {
        console.error('Error deleting selected immovables:', error);
        alert('Failed to delete selected immovables. Please try again later.');
      }
    );
  }

  cancelForm() {
    this.newImmovable = null;
    this.isFormOpen = false;
  }
}
