import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MapComponent } from './pages/map/map.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; // FormsModule'u ekleyin
import { ImmovableComponent } from './pages/immovable/immovable.component';
import { TestpageComponent } from './pages/testpage/testpage.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { ImmovableAddComponent } from './pages/immovable-add/immovable-add.component';
import { ImmovableEditComponent } from './pages/immovable-edit/immovable-edit.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MapComponent,
    NavbarComponent,
    ImmovableComponent,
    TestpageComponent,
    MainPageComponent,
    ImmovableAddComponent,
    ImmovableEditComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
