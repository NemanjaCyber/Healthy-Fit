import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Korisnik } from '../models/korisnik.models';

@Injectable({
  providedIn: 'root'
})
export class KorisnikService {
  //korisnik:any;
  constructor(public httpClient: HttpClient) {
    //this.uzmiKorisnika();
   }
   LoginKorisnika(){
    return  this.httpClient.get("https://localhost:5001/Korisnik/LogovaniKorisnik/"+localStorage.getItem("korisnik"))
  }
  // getLogovaniKorisnik(){
  //   return this.korisnik;
  // }

  getKorisnici(){
    return this.httpClient.get("https://localhost:5001/Korisnik/GetKorisnici")
   }
   proveriDalIPostoji(username:string){ /////ZA REGISTRACIJU
    
   
    return this.httpClient.get("https://localhost:5001/Korisnik/ProveraRegistracije/"+username);
  }
  postKorisnikDodavanje(korisnik : Korisnik ){
    return   this.httpClient.post("https://localhost:5001/Korisnik/AddKorisnika",korisnik)
   }

   uplatiNovac(id:number,novac:number){
    return this.httpClient.put("https://localhost:5001/Korisnik/UplatiNovac/"+id+"/"+novac,id);
   }

   kupiPlan(nazivPlana:string,idKorisnika:number,idStrucnogLica:number){
    return this.httpClient.put("https://localhost:5001/Korisnik/KupovinaPlanaKorisniku/"+nazivPlana+"/"+idKorisnika+"/"+idStrucnogLica,nazivPlana);
   }
   azurirajKorisnika(korisnik : Korisnik){
    return this.httpClient.put("https://localhost:5001/Korisnik/ChangeKorisnik",korisnik);
   }
   // i ovde sam malo izmenio
   obrisiKorisnika(korisnickoIme:string){

    return this.httpClient.delete("https://localhost:5001/Korisnik/DeleteKorisnikLicno/"+korisnickoIme) 

   }

   pregledStrucnjakaZaKorisnika(){
    return this.httpClient.get("https://localhost:5001/Korisnik/pregledStrucnihLicaKorisnika/"+localStorage.getItem("korisnik"));
  }
   
}
