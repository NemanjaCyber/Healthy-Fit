import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PlanoviService } from 'src/app/services/planovi.service';
import { StrucnoLiceService } from 'src/app/services/strucno-lice.service';
import { faXmark } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-strucno-lice-napravi-plan',
  templateUrl: './strucno-lice-napravi-plan.component.html',
  styleUrls: ['./strucno-lice-napravi-plan.component.css']
})
export class StrucnoLiceNapraviPlanComponent implements OnInit {
  faXmark=faXmark;
  exform:FormGroup
public idStrucnogLica:number=0;
public nazivPlana:string="";
public oblast:string="ishrana";
public cenaPlana:number=0;
public opisPlana:string="";
public autorizacija:string=""

  constructor(private strucnoLiceService :StrucnoLiceService ,private router: Router, private planoviService:PlanoviService) { }

  ngOnInit(): void {
    this.strucnoLiceService.getLogovanoStrucnoLice().subscribe((strucnjak:any)=>{
      this.redirect();
      this.idStrucnogLica=strucnjak[0].id;
      this.autorizacija=strucnjak[0].autorizacija;
     // this.proveraAutorizacije();
    },()=>{
      if(this.redirect()===0)
      this.proveraAutorizacije()
      }
      );


    
    this.exform=new FormGroup({
      'naziv':new FormControl(null,Validators.required),
      'cena':new FormControl(null,[Validators.required,Validators.min(1)]),
      'opis':new FormControl(null,Validators.required),
      'oblast':new FormControl(null,Validators.required)
    })
  }

  onIzmeniCenu(event : Event): void{
    this.cenaPlana = parseInt((event.target as HTMLInputElement).value);
   
   }
   onIzmeniOpisPlana(event : Event): void{
    this.opisPlana = (event.target as HTMLInputElement).value;
    
   }
   onNazivPlana(event : Event): void{
    this.nazivPlana = (event.target as HTMLInputElement).value;
   
    
   }
    
   IzaberiOblast(event : Event){
     
     this.oblast = (event.target as HTMLInputElement).value
     
   }
   kreirajPlan(){
    
     this.planoviService.kreirajPlan(this.nazivPlana,this.idStrucnogLica,this.oblast,this.cenaPlana,this.opisPlana).subscribe();
     alert("Uspešno kreiran plan!")
     this.router.navigate(['pocetna']);
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
