import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { PrijavljivanjeService } from 'src/app/services/prijavljivanje.service';

@Component({
  selector: 'app-prijavljivanje',
  templateUrl: './prijavljivanje.component.html',
  styleUrls: ['./prijavljivanje.component.css']
})
export class PrijavljivanjeComponent implements OnInit {
  faXmark=faXmark;

  exform:FormGroup
 
  korisnikZaLogin:any = null;
  
  strucnjakZaLogin:any = null;
  korisnikIliStrucnja:boolean=true;
  email:string="";
  lozinka:string="";
  provera:string ="";
  constructor(public prijavljivanjeService : PrijavljivanjeService,
            private router: Router) { 
   
  }

  ngOnInit(): void {
    this.exform=new FormGroup({
      'email':new FormControl(null,[Validators.required,Validators.email]),
      'password':new FormControl(null,[Validators.required,Validators.pattern("^[a-zA-Z0-9]+$"),Validators.maxLength(50)])
    });
   
    localStorage.clear();
  }

 prijaviSeKorisnik(){

  this.prijavljivanjeService.posaljiMejliSIfruKorisnik(this.email,this.lozinka).subscribe((korisnici:any)=>{
    this.korisnikZaLogin=korisnici;},
    (error)=>{

    },()=>{

      if(this.korisnikZaLogin[0] !=null)
    {
    
     localStorage.setItem("korisnik",this.email); 
     this.prijavljivanjeService.autorizujKorisnika().subscribe((value)=>{

    },(error)=>{

    },()=>{
     this.router.navigate(['pocetna']);
    }); 
   }
  else{
    alert("Uneli ste pogrešne podatke!");
 } 

    });
 
  }

//   if(this.korisnikZaLogin[0] !=null)
//   {
//     if(this.korisnikZaLogin.sifra===this.lozinka){
//      localStorage.setItem("korisnik",this.email); 
//      this.prijavljivanjeService.autorizujKorisnika().subscribe((value)=>{

//     },(error)=>{

//     },()=>{
//      this.router.navigate(['pocetna']);
//     }); //ovo sam dodao // ovo je dodato
//      //this.router.navigate(['pocetna-korisnik']);
//      //this.router.navigate(['pocetna']);
//     }
//     else{
//        alert("Pogrešna lozinka!");
//     }
//   }
//   else{
//     alert("Nalog ne postoji!");
//  } 
   
//  }

 prijaviSeStrucnjak(){
  
  this.prijavljivanjeService.posaljiMejliSifruStrucnjak(this.email,this.lozinka).subscribe((strucnjak:any)=>{
    this.strucnjakZaLogin=strucnjak;},
    (error)=>{

    },()=>{

  if(this.strucnjakZaLogin[0] !=null)
  {
    // if(this.strucnjakZaLogin.sifra===this.lozinka){
     localStorage.setItem("strucnjak",this.email); 
     this.prijavljivanjeService.autorizujStrucnjaka().subscribe((value)=>{

    },(error)=>{

    },()=>{
     this.router.navigate(['pocetna']);
    });  // ovo je dodato
     //this.router.navigate(['pocetna-strucno-lice']);
    // this.router.navigate(['pocetna']);
    // }
    // else{
    //    alert("Pogresna lozinka!")
    // }
  }
  else{
    alert("Uneli ste pogrešne podatke!")
  } 
  });
 
}

 onIzmeniEmail(event : Event): void{
  this.email = (event.target as HTMLInputElement).value;
 
 }
 onIzmeniSifru(event : Event): void{
  this.lozinka = (event.target as HTMLInputElement).value;
 
 }

 onIzmeniEmailStrucnjak(event : Event): void{
  this.email = (event.target as HTMLInputElement).value;
  
 }
 onIzmeniSifruStrucnjak(event : Event): void{
  this.lozinka = (event.target as HTMLInputElement).value;
 
  
 }
  
 IzaberiKoSePrijavljuje(event : Event){
   
   this.provera = (event.target as HTMLInputElement).value
   if(this.provera==="true")
   {
      this.korisnikIliStrucnja=true;
   }
   else{
    this.korisnikIliStrucnja=false;
   }
 }
  

}
