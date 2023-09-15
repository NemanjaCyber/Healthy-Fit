import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarPosetilacComponent } from './components/nav-bar-posetilac/nav-bar-posetilac.component';
import { NavBarUlogovaniComponent } from './components/nav-bar-ulogovani/nav-bar-ulogovani.component';
import { PocetnaKorisnikComponent } from './components/pocetna-korisnik/pocetna-korisnik.component';
import { PocetnaStrucnoLiceComponent } from './components/pocetna-strucno-lice/pocetna-strucno-lice.component';
import { ProfilKorisnikComponent } from './components/profil-korisnik/profil-korisnik.component';
import { ProfilStrucnoLiceComponent } from './components/profil-strucno-lice/profil-strucno-lice.component';
import { PocetnaPosetilacComponent } from './components/pocetna-posetilac/pocetna-posetilac.component';
import { PrijavljivanjeComponent } from './components/prijavljivanje/prijavljivanje.component';
import { RegistracijaComponent } from './components/registracija/registracija.component';
import { RouterModule } from '@angular/router';
import { PopupUplataComponent } from './components/popup-uplata/popup-uplata.component';
import { PlanoviPrikazComponent } from './components/planovi-prikaz/planovi-prikaz.component';
import { PlanoviPopupComponent } from './components/planovi-popup/planovi-popup.component';
import { HttpClientModule } from '@angular/common/http';
import { RegistracijaStrucnoLiceComponent } from './components/registracija-strucno-lice/registracija-strucno-lice.component';
import { AdminComponent } from './components/admin/admin.component';
import { AdminPrijavljivanjeComponent } from './components/admin-prijavljivanje/admin-prijavljivanje.component';
import { StrucnaLicaPopupComponent } from './components/strucna-lica-popup/strucna-lica-popup.component';
import { StrucnaLicaPrikazComponent } from './components/strucna-lica-prikaz/strucna-lica-prikaz.component';
import { KorisnikListaStrucnihLicaComponent } from './components/korisnik-lista-strucnih-lica/korisnik-lista-strucnih-lica.component';
import { KorisnikStrucnaLicaPopupComponent } from './components/korisnik-strucna-lica-popup/korisnik-strucna-lica-popup.component';
import { KorisnikKupljeniPlanoviPopupComponent } from './components/korisnik-kupljeni-planovi-popup/korisnik-kupljeni-planovi-popup.component';
import { OcenaIKomentarPlanaComponent } from './components/ocena-ikomentar-plana/ocena-ikomentar-plana.component';
import { StrucnoLiceNapraviPlanComponent } from './components/strucno-lice-napravi-plan/strucno-lice-napravi-plan.component';
import { StrucnoLiceAzurirajPlanComponent } from './components/strucno-lice-azuriraj-plan/strucno-lice-azuriraj-plan.component';
import { StrucnoLiceMojiPlanoviPopupComponent } from './components/strucno-lice-moji-planovi-popup/strucno-lice-moji-planovi-popup.component';
import { StrucnoLiceDodajVezbuComponent } from './components/strucno-lice-dodaj-vezbu/strucno-lice-dodaj-vezbu.component';
import { StrucnoLiceDodajObrokComponent } from './components/strucno-lice-dodaj-obrok/strucno-lice-dodaj-obrok.component';
import { KorisnikPorukaComponent } from './components/korisnik-poruka/korisnik-poruka.component';
import { KorisnikPorukaPopupComponent } from './components/korisnik-poruka-popup/korisnik-poruka-popup.component';
import { StrucnoLicePorukaComponent } from './components/strucno-lice-poruka/strucno-lice-poruka.component';
import { StrucnoLicePorukaPopupComponent } from './components/strucno-lice-poruka-popup/strucno-lice-poruka-popup.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [
    AppComponent,
    NavBarPosetilacComponent,
    NavBarUlogovaniComponent,
    PocetnaKorisnikComponent,
    PocetnaStrucnoLiceComponent,
    ProfilKorisnikComponent,
    ProfilStrucnoLiceComponent,
    PocetnaPosetilacComponent,
    PrijavljivanjeComponent,
    RegistracijaComponent,
    PopupUplataComponent,
    PlanoviPrikazComponent,
    PlanoviPopupComponent,
    RegistracijaStrucnoLiceComponent,
    AdminComponent,
    AdminPrijavljivanjeComponent,
    StrucnaLicaPopupComponent,
    StrucnaLicaPrikazComponent,
    KorisnikListaStrucnihLicaComponent,
    KorisnikStrucnaLicaPopupComponent,
    KorisnikKupljeniPlanoviPopupComponent,
    OcenaIKomentarPlanaComponent,
    StrucnoLiceNapraviPlanComponent,
    StrucnoLiceAzurirajPlanComponent,
    StrucnoLiceMojiPlanoviPopupComponent,
    StrucnoLiceDodajVezbuComponent,
    StrucnoLiceDodajObrokComponent,
    KorisnikPorukaComponent,
    KorisnikPorukaPopupComponent,
    StrucnoLicePorukaComponent,
    StrucnoLicePorukaPopupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule,
    ReactiveFormsModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
