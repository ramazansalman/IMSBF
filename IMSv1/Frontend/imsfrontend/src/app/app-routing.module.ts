import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MapComponent } from './pages/map/map.component';
import { ImmovableComponent } from './pages/immovable/immovable.component';
import { TestpageComponent } from './pages/testpage/testpage.component';


const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' }, // Ana sayfa yönlendirme
  { path: 'map', component: MapComponent }, // Map sayfası rotası
  { path: 'immovable', component: ImmovableComponent }, // Immovable sayfası];
  { path: 'testpage', component: TestpageComponent }, // Testpage sayfası];

  //{ path: '**', redirectTo: '' }, // Hatalı path'leri anasayfaya yönlendir
  //{ path: '', component: ImmovableComponent }, // Anasayfayı Immovable'a yönlendir
  //{ path: 'home', component: HomeComponent }, // Ana sayfa bileşeni

]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
