import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { PetsComponent } from './pets/pets.component';
import { HeaderComponent } from './header/header.component';
import { NavigationComponent } from './navigation/navigation.component';
import { HomeComponent } from './home/home.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { PetOwnerComponent } from './pet-owner/pet-owner.component';
import { AccomodationComponent } from './accomodation/accomodation.component';
import { FooterComponent } from './footer/footer.component';
import { PetDetailComponent } from './pet-detail/pet-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    PetsComponent,
    HeaderComponent,
    NavigationComponent,
    HomeComponent,
    NotfoundComponent,
    PetOwnerComponent,
    AccomodationComponent,
    FooterComponent,
    PetDetailComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'pets', component: PetsComponent },
      { path: 'pet-detalhe/:id', component: PetDetailComponent},
      { path: 'donos', component: PetOwnerComponent},
      { path: 'alojamentos', component: AccomodationComponent},
      { path: '**' , component: NotfoundComponent },
    ])
  ],
  providers: [],
  bootstrap: [ AppComponent]
})
export class AppModule { }
