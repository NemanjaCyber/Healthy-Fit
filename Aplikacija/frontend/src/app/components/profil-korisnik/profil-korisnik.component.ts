import { Component, OnInit } from '@angular/core';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { Korisnik } from 'src/app/models/korisnik.models';
import { KorisnikService } from 'src/app/services/korisnik.service';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profil-korisnik',
  templateUrl: './profil-korisnik.component.html',
  styleUrls: ['./profil-korisnik.component.css']
})
export class ProfilKorisnikComponent implements OnInit {
  faTrash=faTrash;
  faXmark=faXmark;
  public korisnik : Korisnik = new Korisnik("","","","","","","","",0,"");
  public idLogovanogKorisnika:number=0;
  public logovaniKorisnik:any;
  public autorizacija:string=""
  
  constructor(private korisnikService :KorisnikService, private router: Router) { }

  ngOnInit(): void {
    this.korisnikService.LoginKorisnika().subscribe((korisnici:any)=>{
      this.redirect();
      this.logovaniKorisnik=korisnici;
      this.idLogovanogKorisnika=korisnici[0].id;
      this.korisnik.email=korisnici[0].email;
      this.korisnik.korisnickoIme=korisnici[0].korisnickoIme;
      this.korisnik.sifra=korisnici[0].sifra;
      this.korisnik.ime=korisnici[0].ime;
      this.korisnik.prezime=korisnici[0].prezime;
      this.korisnik.slika=korisnici[0].slika;
      this.korisnik.datumRodjenja=korisnici[0].datumRodjenja;
      this.korisnik.pol=korisnici[0].pol;
      this.korisnik.kolicinaNovca=korisnici[0].kolicinaNovca;
      this.korisnik.cet=korisnici[0].cet;
      this.autorizacija=korisnici[0].autorizacija;
     
      
    },()=>{
      if(this.redirect()===0)
      this.proveraAutorizacije()
      }
      );
  }

  onIzmeniIme(event : Event): void{
    this.korisnik.ime = (event.target as HTMLInputElement).value;
   
   }
   onIzmeniPrezime(event : Event): void{
    this.korisnik.prezime = (event.target as HTMLInputElement).value;
   
   }
   onIzmeniDatum(event : Event): void{
    this.korisnik.datumRodjenja = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniKorisnickoIme(event : Event): void{
    this.korisnik.korisnickoIme = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniPol(event : Event): void{
    this.korisnik.pol = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniEmail(event : Event): void{
    this.korisnik.email = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniLozinka(event : Event): void{
    this.korisnik.sifra = (event.target as HTMLInputElement).value;
   
  }
  onChangeSlika(event : Event): void{
    this.korisnik.slika = (event.target as HTMLInputElement).value;
    this.korisnik.slika = this.korisnik.slika.replace("C:\\fakepath\\", "./assets/");
    
  }

  onIzmeniProfil(){
    this.korisnikService.azurirajKorisnika(this.korisnik).subscribe();
  }
  onIzbrisiProfil(){
    console.log(this.korisnik.korisnickoIme);
    this.korisnikService.obrisiKorisnika(this.korisnik.korisnickoIme).subscribe();
    alert("Uspešno ste izbisali vas nalog.");
    localStorage.clear();
  }
  proveraAutorizacije(){
  
    if(this.autorizacija!=="Korisnik"){
      localStorage.clear();
      this.router.navigate(['pocetna']);
    }
   }
   redirect(){
    if(localStorage.key(0)==="strucnjak" || localStorage.key(0)==="admin")
    {
      this.router.navigate(['pocetna']);
      return 1;
    }
    else return 0;
   }

}
