import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PlanoviService {
 //public sviPlanovi: any;
  constructor(public httpClient: HttpClient) {
   // this.planoviRefresh();
   }


  // getPlanovi(){
  //   return this.sviPlanovi
  //  }

   getPlanovi(){
    return this.httpClient.get("https://localhost:5001/Plan/GetSviPlanovi/"+localStorage.getItem("korisnik"));
    
   }
   
   otkaziPlan(nazivPlana:string,idKorisnika:number){
    return this.httpClient.put("https://localhost:5001/Korisnik/KorisnikOtkaziPlan/"+nazivPlana+"/"+idKorisnika,idKorisnika);
   }

   kreirajPlan(nazivPlana:string,idStrucnogLica:number,oblast:string,cenaPlana:number,opisPlana:string){
    return this.httpClient.post("https://localhost:5001/StrucnoLice/KreiranjePlana/"+nazivPlana+"/"+idStrucnogLica+"/"+oblast+"/"+cenaPlana+"/"+opisPlana,nazivPlana);
   }
   azurirajPlan(idPlana:number,idStrucnjaka:number,nazivPlana:string,opisPlana:string,cena:number){
    return this.httpClient.put("https://localhost:5001/Plan/ChangePlanStrucnjak/"+idPlana+"/"+idStrucnjaka+"/"+nazivPlana+"/"+opisPlana+"/"+cena,idPlana);
    
  }
  dodajObrok(idPlana:number,dan:string,tipObroka:string,slikaPutanja:string,opis:string){
    return this.httpClient.post("https://localhost:5001/Plan/DodajObrok/"+idPlana+"/"+dan+"/"+tipObroka+"/"+slikaPutanja+"/"+opis+"/"+localStorage.getItem("strucnjak"),idPlana);
  }
  dodajVezbu(idPlana:number,dan:string,periodDanaIzvodjenja:string,brojPonavljanja:number,slikaPutanja:string,opis:String){
    return this.httpClient.post("https://localhost:5001/Plan/DodajVezbu/"+idPlana+"/"+dan+"/"+periodDanaIzvodjenja+"/"+brojPonavljanja+"/"+slikaPutanja+"/"+opis+"/"+localStorage.getItem("strucnjak"),idPlana);
  }
}
