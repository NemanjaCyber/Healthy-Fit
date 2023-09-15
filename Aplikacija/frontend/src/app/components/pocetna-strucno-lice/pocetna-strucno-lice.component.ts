import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { StrucnoLiceService } from 'src/app/services/strucno-lice.service';
import { faDumbbell } from '@fortawesome/free-solid-svg-icons';
import { faCarrot } from '@fortawesome/free-solid-svg-icons';
import { faInbox } from '@fortawesome/free-solid-svg-icons';
import { faCoins } from '@fortawesome/free-solid-svg-icons';
import { faDoorOpen } from '@fortawesome/free-solid-svg-icons';
import { faBan } from '@fortawesome/free-solid-svg-icons';
import { faMoneyBill1Wave } from '@fortawesome/free-solid-svg-icons';
import { PrijavljivanjeService } from 'src/app/services/prijavljivanje.service';

@Component({
  selector: 'app-pocetna-strucno-lice',
  templateUrl: './pocetna-strucno-lice.component.html',
  styleUrls: ['./pocetna-strucno-lice.component.css']
})
export class PocetnaStrucnoLiceComponent implements OnInit {
  faMoneyBill1Wave=faMoneyBill1Wave
  faBan=faBan;
  faDoorOpen=faDoorOpen;
  faCoins=faCoins;
  faInbox=faInbox;
  faXmark=faXmark;
  faUser=faUser;
  faDumbbell=faDumbbell;
  faCarrot=faCarrot;

  exform:FormGroup
  logovaniStrucnjak: any;
  public novac:number=0;
  public brojRacuna:number=0;
  public novacZaIsplatu:number=0;
  public idStrucnogLica:number=0;
  public daLiJeFitnes:string="fitnes";
  public daLiJeIshrana:string="ishrana";
  public azurirajPlan:boolean=false;
  public planZaSlanje:any;
  /////
  public prikaziMojPlan:boolean=false;
  public mojPlanZaSlanje:any;
  public prikaziDodajVezbu:boolean=false;
  public prikaziDodajObrok:boolean=false;
  public idPlanaZaDodajVezbuIliObrok:number=0;
  public autorizacija:string=""
  constructor(private strucnoLiceService :StrucnoLiceService ,private router: Router,
    public prijavljivanjeService : PrijavljivanjeService) { }

  ngOnInit(): void {
    this.strucnoLiceService.getLogovanoStrucnoLice().subscribe((strucnjak:any)=>{
      this.redirect();
      this.logovaniStrucnjak=strucnjak;
      this.novac=strucnjak[0].kolicinaNovca;  
      this.brojRacuna=strucnjak[0].brojRacuna;
      this.idStrucnogLica=strucnjak[0].id;
      this.autorizacija=strucnjak[0].autorizacija;
      //this.proveraAutorizacije();
    },()=>{
      if(this.redirect()===0)
      this.proveraAutorizacije()
      }
      );


    this.exform=new FormGroup({
      'isplata':new FormControl(null,[Validators.required,Validators.min(1)])
    })
    }


  odjaviSe(){
    this.prijavljivanjeService.odjaviStrucnjaka().subscribe();
    localStorage.clear()
    this.router.navigate(['pocetna']);
  }

  onIzmeniKolicinuNovca(event : Event): void{
    this.novacZaIsplatu = parseInt((event.target as HTMLInputElement).value);
  }

  onIsplatiMe(){
    
    if(this.brojRacuna!=0)
    {
      if(this.novac>this.novacZaIsplatu)
       {
      
           this.strucnoLiceService.isplatiNovac(this.idStrucnogLica,this.novacZaIsplatu).subscribe();
           alert("Uspešna isplata.")
           this.router.navigate(['pocetna']);
       }
      else{
       alert("Nemate dovoljno novca!");
          }
   
    }
       else{
       alert("Niste uneli broj računa.");
           }
   }

   onObrisiPlan(idPlana:number){
      this.strucnoLiceService.deletePlan(idPlana).subscribe();
      alert("Uspešno obrisan plan.");
      this.router.navigate(['pocetna']);
   }

   onAzurirajPlan(plan:any){
    this.azurirajPlan=true;
    this.planZaSlanje=plan;
  }
  onIskljuciAzuriranje(){
   this.azurirajPlan=false;
  }
  onPrikaziMojPlan(plan:any){
    console.log(plan);
   this.mojPlanZaSlanje=plan;
    this.prikaziMojPlan=true;
  }
  onIskljuciMojPlan(){
    this.prikaziMojPlan=false;
  }
  

  onPrikaziDodajVezbu(idPlana:number){
   console.log(idPlana);
  this.idPlanaZaDodajVezbuIliObrok=idPlana;
   this.prikaziDodajVezbu=true;
 }
 onIskljuciDodajVezbu(){
   this.prikaziDodajVezbu=false;
 }

 onPrikaziDodajObrok(idPlana:number){
   
  this.idPlanaZaDodajVezbuIliObrok=idPlana;
   this.prikaziDodajObrok=true;
 }
 onIskljuciDodajObrok(){
   this.prikaziDodajObrok=false;
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


