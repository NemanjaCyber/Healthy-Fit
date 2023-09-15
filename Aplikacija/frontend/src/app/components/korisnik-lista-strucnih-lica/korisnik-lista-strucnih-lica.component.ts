import { Component, OnInit } from '@angular/core';
import { PrijavljivanjeService } from 'src/app/services/prijavljivanje.service';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';
import { KorisnikService } from 'src/app/services/korisnik.service';

@Component({
  selector: 'app-korisnik-lista-strucnih-lica',
  templateUrl: './korisnik-lista-strucnih-lica.component.html',
  styleUrls: ['./korisnik-lista-strucnih-lica.component.css']
})
export class KorisnikListaStrucnihLicaComponent implements OnInit {
  faXmark=faXmark;

  jePretisnuto = false;
  
  public strucnoLiceZaSLanje:any;
  ////////////////////////
  public strucnjaci:any;
  constructor(private korisnikService:KorisnikService, private router: Router) { }

  ngOnInit(): void {
    this.korisnikService.pregledStrucnjakaZaKorisnika().subscribe((strucnjak:any)=>{
      this.redirect();
      this.strucnjaci=strucnjak;
    },(error:any)=>{
      this.redirect();
      if(error.status===401)
      this.pogresnaAutorizacija()
      }
      );
        
  }
  
  open(){
    this.jePretisnuto = true;
  }

  close() {
    this.jePretisnuto =false;
  }

  otvoriStrucnoLice(strucnjak:any){
   
    this.strucnoLiceZaSLanje=strucnjak;
    
    
    this.open();
  }

  redirect(){
    if(localStorage.key(0)!=="korisnik")
    {
      this.router.navigate(['pocetna']);
    }
   }

   pogresnaAutorizacija(){
   
      localStorage.clear();
      this.router.navigate(['pocetna']);
    
   }

   

}
