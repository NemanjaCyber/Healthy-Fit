import { Component, OnInit } from '@angular/core';
import { PorukaService } from 'src/app/services/poruka.service';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { faEnvelope } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';

@Component({
  selector: 'app-strucno-lice-poruka',
  templateUrl: './strucno-lice-poruka.component.html',
  styleUrls: ['./strucno-lice-poruka.component.css']
})
export class StrucnoLicePorukaComponent implements OnInit {
  faXmark=faXmark;
  faEnvelope=faEnvelope;

  public strucnjak:any
  public idKorisnikaZaSlanje:number=0;
  public korisniciZaPrijemPoruka:any
  public idStrucnogLicaZaSlanje:number=0;
  public slanjePoruke:boolean=false;
  public autorizacija:string=""

  constructor( private porukeService:PorukaService, private router: Router ) { }

  ngOnInit(): void {
    this.porukeService.getStrucnoLiceSaPorukama().subscribe((strucnjaci:any)=>{
      this.redirect();
      this.strucnjak=strucnjaci;
      this.idStrucnogLicaZaSlanje=strucnjaci[0].id;
      strucnjaci[0].strucnaLicaPoruke.reverse();
      this.autorizacija=strucnjaci[0].autorizacija;
     // this.proveraAutorizacije();
     },()=>{
      if(this.redirect()===0)
      this.proveraAutorizacije()
      }
      );

     this.porukeService.getKorisniciZaPrijemPoruka().subscribe((korisnici:any)=>{
      this.korisniciZaPrijemPoruka=korisnici;
     })
  }

  close(){
    this.slanjePoruke=false;
  }

  posaljiPoruku(idKorisnika:number){
    this.idKorisnikaZaSlanje=idKorisnika;
    this.slanjePoruke=true;

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
