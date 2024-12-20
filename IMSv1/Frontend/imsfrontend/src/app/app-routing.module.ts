import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MapComponent } from './pages/map/map.component';
import { ImmovableComponent } from './pages/immovable/immovable.component';
import { TestpageComponent } from './pages/testpage/testpage.component';
import { MainPageComponent } from './pages/main-page/main-page.component';


const routes: Routes = [
  //{ path: '', redirectTo: 'home', pathMatch: 'full' }, // Ana sayfa yönlendirme
  { path: '', component: MainPageComponent }, // Root route for the main page
  { path: 'map', component: MapComponent }, // Map sayfası rotası
  { path: 'immovable', component: ImmovableComponent }, // Immovable sayfası];
  { path: 'testpage', component: TestpageComponent }, // Testpage sayfası];
  //{ path: '**', redirectTo: '' } // Redirect other routes to the main page if needed
  //{ path: '', component: ImmovableComponent }, // Anasayfayı Immovable'a yönlendir
  //{ path: 'home', component: HomeComponent }, // Ana sayfa bileşeni

]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
