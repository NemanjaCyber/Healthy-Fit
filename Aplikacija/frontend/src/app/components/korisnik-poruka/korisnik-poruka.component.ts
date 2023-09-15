import { Component, OnInit } from '@angular/core';
import { PorukaService } from 'src/app/services/poruka.service';
import { faEnvelope } from '@fortawesome/free-solid-svg-icons';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';

@Component({
  selector: 'app-korisnik-poruka',
  templateUrl: './korisnik-poruka.component.html',
  styleUrls: ['./korisnik-poruka.component.css']
})
export class KorisnikPorukaComponent implements OnInit {
  faXmark=faXmark
  faEnvelope=faEnvelope;

  public korisnik:any
  public idKorisnikaZaSlanje:number=0;
  public strucnaLicaZaPrijemPoruka:any
  public idStrucnogLicaZaSlanje:number=0;
  public slanjePoruke:boolean=false;
  public autorizacija:string=""
  constructor( private porukeService:PorukaService, private router: Router) { }

  ngOnInit(): void {

    this.porukeService.getKorisnikSaPorukama().subscribe((korisnici:any)=>{
      this.redirect();
      this.korisnik=korisnici;
      this.idKorisnikaZaSlanje=korisnici[0].id;
      korisnici[0].korisniciPoruke.reverse();
      this.autorizacija=korisnici[0].autorizacija;
      this.proveraAutorizacije();
     })

     this.porukeService.getStrucnaLicaZaPrijemPoruka().subscribe((strucnaLica:any)=>{
      this.strucnaLicaZaPrijemPoruka=strucnaLica;
     },()=>{
      if(this.redirect()===0)
      this.proveraAutorizacije()
      }
      );
  }

  close(){
    this.slanjePoruke=false;
  }

  posaljiPoruku(idStrucnjaka:number){
    this.idStrucnogLicaZaSlanje=idStrucnjaka;
    this.slanjePoruke=true;

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
