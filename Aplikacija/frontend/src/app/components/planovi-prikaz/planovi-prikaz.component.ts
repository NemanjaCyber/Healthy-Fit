import { Component, OnInit } from '@angular/core';
import { KorisnikService } from 'src/app/services/korisnik.service';
import { PlanoviService } from 'src/app/services/planovi.service';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';

@Component({
  selector: 'app-planovi-prikaz',
  templateUrl: './planovi-prikaz.component.html',
  styleUrls: ['./planovi-prikaz.component.css']
})

export class PlanoviPrikazComponent implements OnInit {
  faXmark=faXmark;
  public sviPlanovi: any=[];
  public zaPrikaz: any=[];
  public rezervniPlanovi : any=[];
  
  isLogin = false;
  
  nazivZaSLanje:string="";
  idZaSlanje:number=0;
  oblastZaSlanje:string="";
  cenaZaSlanje:number=0;

  logovaniKorisnik: any;
  public odKolikoN:number=0;
  public doKolikoN:number=9999999999;
  public imePlanaZaPretragu:string="";
  public idStrucnogLica:number=0;
  public idKorisnika:number=0;
  public autorizacija:string=""

  constructor(public planoviService: PlanoviService , private korisnikService :KorisnikService, 
    private router: Router) { 
    
    
  }

  ngOnInit(): void {
    
    this.korisnikService.LoginKorisnika().subscribe((korisnici:any)=>{
      this.redirect();
      this.logovaniKorisnik=korisnici;
      this.idKorisnika=korisnici[0].id;
      this.autorizacija=korisnici[0].autorizacija;
      
      
      
      
    },()=>{
      if(this.redirect()===0)
      this.proveraAutorizacije()
      }
      );

    this.planoviService.getPlanovi()
    .subscribe((planovi:any) => {
      this.sviPlanovi=planovi;
      this.rezervniPlanovi=planovi;
    });
    
    
  }

  prikaziFitnes(){
    this.zaPrikaz=[];
    this.rezervniPlanovi.forEach((element:any) => {
      
      if(element.oblast==="fitnes" ){
      
      if(!this.zaPrikaz.includes(element)){  
      this.zaPrikaz.push(element);
      }
      }
      this.sviPlanovi=this.zaPrikaz;
      
       });
  }
  prikaziIshranu(){
    this.zaPrikaz=[];
    this.rezervniPlanovi.forEach((element:any) => {
      if(element.oblast ==="ishrana" ){
        if(!this.zaPrikaz.includes(element)){  
          this.zaPrikaz.push(element);
          }
      }
      this.sviPlanovi=this.zaPrikaz;
       });
  }
  prikaziSve(){
    this.sviPlanovi=this.rezervniPlanovi;
  }
    
  login(){
    this.isLogin = true;
  }

  close() {
    this.isLogin =false;
  }
  onSortOpadajuca(){
    
    this.sviPlanovi.sort((n1: any,n2: any) => {
      if (n1.cena > n2.cena) {
        
          return -1;
          
      }
  
      if (n1.cena < n2.cena) {
       
          return 1;
      }
  
      return 0;
       })
       
    }
    onSortRastuca(){
    
      this.sviPlanovi.sort((n1: any,n2: any) => {
        if (n1.cena > n2.cena) {
          
            return 1;
            
        }
    
        if (n1.cena < n2.cena) {
          
            return -1;
        }
    
        return 0;
         })
         
      }

    otvoriPlan(id:number,cena:number,oblast :string, naziv:string,idStrucnogLica:number){
      
      this.cenaZaSlanje=cena;
      this.idZaSlanje=id;
      this.nazivZaSLanje=naziv;
      this.oblastZaSlanje=oblast;
      this.idStrucnogLica=idStrucnogLica;
      this.login();
    }

    odKolikoNovca(event : Event): void{

      this.odKolikoN = parseInt((event.target as HTMLInputElement).value);
     }
     
     doKolikoNovca(event : Event): void{

      this.doKolikoN = parseInt((event.target as HTMLInputElement).value);
     }
     nazivPlanaZaPret(event : Event): void{

      this.imePlanaZaPretragu = (event.target as HTMLInputElement).value;
     }
     onPretrazi(){
      this.zaPrikaz=[];
      this.rezervniPlanovi.forEach((element:any) => {
        if(element.cena > this.odKolikoN && element.cena < this.doKolikoN ){
          if(!this.zaPrikaz.includes(element)){  
            this.zaPrikaz.push(element);
            }
        }
        this.sviPlanovi=this.zaPrikaz;
         });

     }
     onPretraziImePlana(){
       console.log(this.imePlanaZaPretragu)
      this.zaPrikaz=[];
      this.rezervniPlanovi.forEach((element:any) => {
        if(element.nazivPlana === this.imePlanaZaPretragu ){
          if(!this.zaPrikaz.includes(element)){  
            this.zaPrikaz.push(element);
            }
        }
        this.sviPlanovi=this.zaPrikaz;
         });

     }
    
  

     redirect(){
      if(localStorage.key(0)==="strucnjak" || localStorage.key(0)==="admin")
    {
      this.router.navigate(['pocetna']);
      return 1;
    }
    else return 0;
     }
     proveraAutorizacije(){
  
      
      if(this.autorizacija!=="Korisnik"){
        localStorage.clear();
        this.router.navigate(['pocetna']);
      }
     }
  
}
