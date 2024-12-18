import { Component, OnInit } from '@angular/core';
import { ImmovableService, Immovable } from '../../services/immovable.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-immovable',
  templateUrl: './immovable.component.html',
  styleUrls: ['./immovable.component.css'],
})
export class ImmovableComponent implements OnInit {
  immovables: Immovable[] = [];
  selectedImmovables: Set<number> = new Set();
  newImmovable: Partial<Immovable> | null = null;

  constructor(private immovableService: ImmovableService, private router: Router) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.immovableService.getAll().subscribe((data) => {
      this.immovables = data;
    });
  }

  openForm() {
    this.newImmovable = {
      block: '',
      parcel: '',
      type: '',
      coordinates: '',
      neighborhoodId: 1,
      userId: 1,
    };
  }

  createImmovable() {
    if (this.newImmovable) {
      this.immovableService.create(this.newImmovable as Immovable).subscribe(() => {
        this.newImmovable = null;
        this.loadData(); // Verileri yeniler
        this.router.navigate(['/immovable']);
      });
    }
  }

  deleteImmovable(id: number) {
    this.immovableService.delete(id).subscribe(() => {
      this.loadData();
    });
  }

  toggleSelection(id: number) {
    if (this.selectedImmovables.has(id)) {
      this.selectedImmovables.delete(id);
    } else {
      this.selectedImmovables.add(id);
    }
  }

  deleteSelected() {
    const ids = Array.from(this.selectedImmovables);
    ids.forEach((id) => {
      this.immovableService.delete(id).subscribe(() => {
        this.loadData();
      });
    });
    this.selectedImmovables.clear();
  }

  cancelForm() {
    this.newImmovable = null;
  }
}