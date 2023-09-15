import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { KorisnikService } from 'src/app/services/korisnik.service';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { faInbox } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-pocetna-korisnik',
  templateUrl: './pocetna-korisnik.component.html',
  styleUrls: ['./pocetna-korisnik.component.css']
})
export class PocetnaKorisnikComponent implements OnInit {
  faInbox=faInbox;
  faUser=faUser;
  logovaniKorisnik: any;
  idZaSlanje:number=0;
  public novac:number =0;
  public prikaziPlanove:boolean=false;
  public nazivPlanaZaSlanje:string="";
  public opisPlanaZaSlanje:string=""
  public autorizacija:string=""
  public idStrucnogLicaZaSlanje:number=0;
  public planoviKorisnikaZaSlanje:any;
  constructor(private korisnikService :KorisnikService,private router: Router) {
    
   }

  ngOnInit(): void {
    
    
    this.korisnikService.LoginKorisnika().subscribe((korisnici:any)=>{
      
      this.redirect();
      this.logovaniKorisnik=korisnici;
      this.idZaSlanje=korisnici[0].id;
      this.novac=korisnici[0].kolicinaNovca;
      this.autorizacija=korisnici[0].autorizacija;
      
      
    },()=>{
    if(this.redirect()===0)
    this.proveraAutorizacije()
    }
    );
    
  }

  pregledPlanova(){
    this.router.navigate(['pocetna-korisnik/planovi-prikaz']);
  }
  pregledStrucnihLica(){
    this.router.navigate(['pocetna-korisnik/korisnik-lista-strucnih-lica']); 
  }

  kupljeniPlanoviPrikaz(nazivPlana:string,opis:string,idStrucnogL:number,planoviZaSlanje:any){
    this.nazivPlanaZaSlanje=nazivPlana;
    this.opisPlanaZaSlanje=opis;
    this.idStrucnogLicaZaSlanje=idStrucnogL;
    this.planoviKorisnikaZaSlanje=planoviZaSlanje;
    this.prikaziPlanove=true;
    
  }
  close() {
    this.prikaziPlanove =false;
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
