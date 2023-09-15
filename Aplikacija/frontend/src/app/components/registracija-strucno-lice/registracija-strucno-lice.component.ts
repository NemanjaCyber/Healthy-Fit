import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { StrucnoLice } from 'src/app/models/strucnoLice.models';
import { StrucnoLiceService } from 'src/app/services/strucno-lice.service';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { faArrowRightToBracket } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-registracija-strucno-lice',
  templateUrl: './registracija-strucno-lice.component.html',
  styleUrls: ['./registracija-strucno-lice.component.css']
})
export class RegistracijaStrucnoLiceComponent implements OnInit {
  faArrowRightToBracket=faArrowRightToBracket
  faXmark=faXmark;
  
  exform:FormGroup
  public strucnoLice : StrucnoLice = new StrucnoLice("","","","","","./assets/s4.jpg", "", "", 0,"",  "","", 0,false);
  public strucnoLiceZaProveru:string = "";
  
  constructor(private strucnoLiceService: StrucnoLiceService,private router: Router) { }

  ngOnInit(): void {
    this.exform=new FormGroup({
      'ime':new FormControl(null,[Validators.required,Validators.pattern("^[a-zA-Z0-9]+$")]),
      'prezime':new FormControl(null,[Validators.required,Validators.pattern("^[a-zA-Z0-9]+$")]),
      'datumRodjenja':new FormControl(null,[Validators.required]),
      'korIme':new FormControl(null,[Validators.required,Validators.pattern("^[a-zA-Z0-9]+$")]),
      'email':new FormControl(null,[Validators.required]),
      'lozinka':new FormControl(null,[Validators.required,Validators.pattern("^[a-zA-Z0-9]+$")]),
      'slika':new FormControl(null,Validators.required),
      'oblastStruke':new FormControl(null,Validators.required),
      'obrazovanje':new FormControl(null,Validators.required)
  })
  }

  onIzmeniIme(event : Event): void{
    this.strucnoLice.ime = (event.target as HTMLInputElement).value;
   
   }
   onIzmeniPrezime(event : Event): void{
    this.strucnoLice.prezime = (event.target as HTMLInputElement).value;
   
   }
   onIzmeniDatum(event : Event): void{
    this.strucnoLice.datumRodjenja = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniKorisnickoIme(event : Event): void{
    this.strucnoLice.korisnickoIme = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniPol(event : Event): void{
    this.strucnoLice.pol = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniEmail(event : Event): void{
    this.strucnoLice.email = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniLozinka(event : Event): void{
    this.strucnoLice.sifra = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniPonovi(event : Event): void{
    this.strucnoLice.sifra = (event.target as HTMLInputElement).value;
   
   }
   onIzmeniOblastStruke(event : Event): void{
    this.strucnoLice.oblastStruke = (event.target as HTMLInputElement).value;
   
   }
   onIzmeniObrazovanje(event : Event): void{
    this.strucnoLice.obrazovanje = (event.target as HTMLInputElement).value; 
   
   }
   onChangeSlika(event : Event): void{
    this.strucnoLice.slika = (event.target as HTMLInputElement).value;
    this.strucnoLice.slika = this.strucnoLice.slika.replace("C:\\fakepath\\", "./assets/");
   }
   onRegistracija(){
     
     this.strucnoLiceService.proveriDalIPostoji(this.strucnoLice.korisnickoIme).subscribe((strucnjak:any)=>{
       
       if(strucnjak.length==0){ // ovaj niz uvek ima samo 1 clana ako postoji takav korisnik
         this.strucnoLiceService.postStrucnoLice(this.strucnoLice).subscribe();
         this.router.navigate(['pocetna']);
        }
        else{
         alert("Stručnjak vec postoji!")
        }
       });
    
   }
}
