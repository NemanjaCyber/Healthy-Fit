import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Korisnik } from 'src/app/models/korisnik.models';
import { KorisnikService } from 'src/app/services/korisnik.service';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { faArrowRightToBracket } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent implements OnInit {
  faArrowRightToBracket=faArrowRightToBracket
  faXmark=faXmark;
  exform:FormGroup
  public korisnik : Korisnik = new Korisnik("","","","","","./assets/k4.jpg","","",0,"");
  public korisnickoImeZaProveru:string = "";
  public slika2:string="";

  constructor(private korisnikService: KorisnikService,private router: Router) { }

  ngOnInit(): void {
    this.exform=new FormGroup({
      'ime':new FormControl(null,[Validators.required,Validators.pattern("^[a-zA-Z0-9]+$")]),
      'prezime':new FormControl(null,[Validators.required,Validators.pattern("^[a-zA-Z0-9]+$")]),
      'datumRodjenja':new FormControl(null,[Validators.required]),
      'korIme':new FormControl(null,[Validators.required,Validators.pattern("^[a-zA-Z0-9]+$")]),
      'email':new FormControl(null,[Validators.required]),
      'lozinka':new FormControl(null,[Validators.required,Validators.pattern("^[a-zA-Z0-9]+$")]),
      'slika':new FormControl(null,Validators.required)
    })
  }
  onIzmeniIme(event : Event): void{
    this.korisnik.ime = (event.target as HTMLInputElement).value;
   
   }
   onIzmeniPrezime(event : Event): void{
    this.korisnik.prezime = (event.target as HTMLInputElement).value;
   
   }
   onIzmeniDatum(event : Event): void{
    this.korisnik.datumRodjenja = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniKorisnickoIme(event : Event): void{
    this.korisnik.korisnickoIme = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniPol(event : Event): void{
    this.korisnik.pol = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniEmail(event : Event): void{
    this.korisnik.email = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniLozinka(event : Event): void{
    this.korisnik.sifra = (event.target as HTMLInputElement).value;
   
  }
  onIzmeniPonovi(event : Event): void{
    this.korisnik.sifra = (event.target as HTMLInputElement).value;
   
   }
   onChangeSlika(event : Event): void{
    this.korisnik.slika = (event.target as HTMLInputElement).value;
    this.korisnik.slika = this.korisnik.slika.replace("C:\\fakepath\\", "./assets/");
   }
   onRegistracija(){
     
     this.korisnikService.proveriDalIPostoji(this.korisnik.korisnickoIme).subscribe((korisnik:any)=>{
       
       if(korisnik.length==0){ // ovaj niz uvek ima samo 1 clana ako postoji takav korisnik
         this.korisnikService.postKorisnikDodavanje(this.korisnik).subscribe();
         this.router.navigate(['pocetna']);  
        } 
        else{
         alert("Korisnik već postoji!")
        }
       });
    
   }
}

