import { Component, OnInit } from '@angular/core';
import { StrucnoLice } from 'src/app/models/strucnoLice.models';
import { StrucnoLiceService } from 'src/app/services/strucno-lice.service';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profil-strucno-lice',
  templateUrl: './profil-strucno-lice.component.html',
  styleUrls: ['./profil-strucno-lice.component.css']
})
export class ProfilStrucnoLiceComponent implements OnInit {
  faTrash=faTrash;
  faXmark=faXmark;

  public strucnjak : StrucnoLice = new StrucnoLice("","","","","","", "", "", 0,"",  "","", 0,true);
  public idLogovanogStrucnogLica:number=0;
  public logovaniStrucnjak:any;
  public autorizacija:string=""
  
  constructor( private strucnoLiceService :StrucnoLiceService, private router: Router ) { }

  ngOnInit(): void {
    this.strucnoLiceService.getLogovanoStrucnoLice().subscribe((strucnjaci:any)=>{
      this.redirect();
      this.logovaniStrucnjak=strucnjaci;
      this.idLogovanogStrucnogLica=strucnjaci[0].id;
      this.strucnjak.email=strucnjaci[0].email;
      this.strucnjak.korisnickoIme=strucnjaci[0].korisnickoIme;
      this.strucnjak.sifra=strucnjaci[0].sifra;
      this.strucnjak.ime=strucnjaci[0].ime;
      this.strucnjak.prezime=strucnjaci[0].prezime;
      this.strucnjak.slika=strucnjaci[0].slika;
      this.strucnjak.datumRodjenja=strucnjaci[0].datumRodjenja;
      this.strucnjak.pol=strucnjaci[0].pol;
      this.strucnjak.kolicinaNovca=strucnjaci[0].kolicinaNovca;
      this.strucnjak.cet=strucnjaci[0].cet;
      this.strucnjak.oblastStruke=strucnjaci[0].oblastStruke;
      this.strucnjak.obrazovanje=strucnjaci[0].obrazovanje;
      this.strucnjak.brojRacuna=strucnjaci[0].brojRacuna;
      this.autorizacija=strucnjaci[0].autorizacija;
      //this.proveraAutorizacije();
    },()=>{
      if(this.redirect()===0)
      this.proveraAutorizacije()
      }
      );
  }

  onIzmeniIme(event : Event): void{
    this.strucnjak.ime = (event.target as HTMLInputElement).value;
   
   }
   onIzmeniPrezime(event : Event): void{
    this.strucnjak.prezime = (event.target as HTMLInputElement).value;
   
   }
   onIzmeniDatum(event : Event): void{
    this.strucnjak.datumRodjenja = (event.target as HTMLInputElement).value;
   
  }
  
  onIzmeniPol(event : Event): void{
    this.strucnjak.pol = (event.target as HTMLInputElement).value;
   
  }
  
  onIzmeniLozinka(event : Event): void{
    this.strucnjak.sifra = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniOblastStruke(event : Event): void{
    this.strucnjak.oblastStruke = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniObrazovanje(event : Event): void{
    this.strucnjak.obrazovanje = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniBrojRacuna(event : Event): void{
    this.strucnjak.brojRacuna = parseInt((event.target as HTMLInputElement).value);
   
  }
  onChangeSlika(event : Event): void{
    this.strucnjak.slika = (event.target as HTMLInputElement).value;
    this.strucnjak.slika = this.strucnjak.slika.replace("C:\\fakepath\\", "./assets/");
    
  }
  
  onIzmeniProfil(){
    this.strucnoLiceService.azurirajStrucnoLice(this.strucnjak).subscribe();
  }
  onIzbrisiProfil(){
    console.log(this.strucnjak.korisnickoIme);
    this.strucnoLiceService.obrisiStrucnoLice(this.strucnjak.korisnickoIme).subscribe();
    alert("Uspešno ste izbisali vas nalog.");
    localStorage.clear();
  }

  proveraAutorizacije(){
  
    if(this.autorizacija!=="StrucnoLice"){
      localStorage.clear();
      this.router.navigate(['pocetna']);
    }
   }
   redirect(){
    if(localStorage.key(0)==="korisnik" || localStorage.key(0)==="admin")
    {
      this.router.navigate(['pocetna']);
      return 1;
    }
    else return 0;
   }

}
