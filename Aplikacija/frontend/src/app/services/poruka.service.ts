import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PorukaService {

 // public korisnik:any;
  //public strucnoLice:any;

  constructor( public httpClient: HttpClient ) { 
    //this.uzmiKorisnikaSaPorukama();
   // this.uzmiStrucnoLiceSaPorukama();
  }

  getKorisnikSaPorukama(){
    return this.httpClient.get("https://localhost:5001/Korisnik/PorukaKorisnika/"+localStorage.getItem("korisnik"))
  }
  // getKorisnikSaPorukama(){
  //   return this.korisnik;
  // }
  getKorisniciZaPrijemPoruka(){
    return this.httpClient.get("https://localhost:5001/Korisnik/GetKorisniciZaPrijemPoruka/"+localStorage.getItem("strucnjak"))
   }

  posaljiPorukuKorisnik(porukaSadrzaj:string,idStrucnogLIca:number,idKorisnika:number){
    return this.httpClient.post("https://localhost:5001/Poruka/KreiranjePorukeKorisnik/"+porukaSadrzaj+"/"+idStrucnogLIca+"/"+idKorisnika,porukaSadrzaj);
   }

   getStrucnoLiceSaPorukama(){
    return this.httpClient.get("https://localhost:5001/StrucnoLice/PorukeStrucnoLice/"+localStorage.getItem("strucnjak"))
  }
  // getStrucnoLiceSaPorukama(){
  //   return this.strucnoLice;
  // }
  getStrucnaLicaZaPrijemPoruka(){
    return this.httpClient.get("https://localhost:5001/StrucnoLice/GetStrucnaLicaZaPrijemPoruka/"+localStorage.getItem("korisnik"))
  }
  posaljiPorukuStrucnoLice(porukaSadrzaj:string,idStrucnogLIca:number,idKorisnika:number){
    return this.httpClient.post("https://localhost:5001/Poruka/KreiranjePorukeStrucnoLice/"+porukaSadrzaj+"/"+idStrucnogLIca+"/"+idKorisnika,porukaSadrzaj);
   }
}
