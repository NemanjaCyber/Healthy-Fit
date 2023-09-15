import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPrijavljivanjeComponent } from './components/admin-prijavljivanje/admin-prijavljivanje.component';
import { AdminComponent } from './components/admin/admin.component';
import { KorisnikListaStrucnihLicaComponent } from './components/korisnik-lista-strucnih-lica/korisnik-lista-strucnih-lica.component';
import { KorisnikPorukaComponent } from './components/korisnik-poruka/korisnik-poruka.component';
import { PlanoviPrikazComponent } from './components/planovi-prikaz/planovi-prikaz.component';
import { PocetnaKorisnikComponent } from './components/pocetna-korisnik/pocetna-korisnik.component';
import { PocetnaPosetilacComponent } from './components/pocetna-posetilac/pocetna-posetilac.component';
import { PocetnaStrucnoLiceComponent } from './components/pocetna-strucno-lice/pocetna-strucno-lice.component';
import { PrijavljivanjeComponent } from './components/prijavljivanje/prijavljivanje.component';
import { ProfilKorisnikComponent } from './components/profil-korisnik/profil-korisnik.component';
import { ProfilStrucnoLiceComponent } from './components/profil-strucno-lice/profil-strucno-lice.component';
import { RegistracijaStrucnoLiceComponent } from './components/registracija-strucno-lice/registracija-strucno-lice.component';
import { RegistracijaComponent } from './components/registracija/registracija.component';
import { StrucnoLiceNapraviPlanComponent } from './components/strucno-lice-napravi-plan/strucno-lice-napravi-plan.component';
import { StrucnoLicePorukaComponent } from './components/strucno-lice-poruka/strucno-lice-poruka.component';

const routes: Routes = [
  { path: 'pocetna', component: PocetnaPosetilacComponent },
  { path: '', redirectTo: '/pocetna', pathMatch: 'full' },
  { path: 'registracija', component: RegistracijaComponent },
  { path: 'prijavljivanje', component: PrijavljivanjeComponent },
  { path: 'pocetna-korisnik', component: PocetnaKorisnikComponent},
  { path: 'pocetna-strucno-lice', component: PocetnaStrucnoLiceComponent},
  { path: 'profil-korisnik', component: ProfilKorisnikComponent},
  { path: 'profil-strucno-lice', component: ProfilStrucnoLiceComponent },
  {path: 'registracija-strucno-lice', component: RegistracijaStrucnoLiceComponent},
  {path: 'admin', component: AdminComponent},
  {path: 'admin-prijavljivanje', component: AdminPrijavljivanjeComponent},
  {path: 'pocetna-korisnik/planovi-prikaz', component: PlanoviPrikazComponent},
  {path: 'pocetna-korisnik/korisnik-lista-strucnih-lica', component: KorisnikListaStrucnihLicaComponent},
  {path: 'pocetna-korisnik/profil-korisnik', component: ProfilKorisnikComponent},
  {path: 'pocetna-strucno-lice/strucno-lice-napravi-plan', component: StrucnoLiceNapraviPlanComponent},
  {path: 'pocetna-strucno-lice/profil-strucno-lice', component: ProfilStrucnoLiceComponent},
  {path: 'pocetna-korisnik/korisnik-poruka', component: KorisnikPorukaComponent}, 
  {path: 'pocetna-strucno-lice/strucno-lice-poruka', component: StrucnoLicePorukaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
