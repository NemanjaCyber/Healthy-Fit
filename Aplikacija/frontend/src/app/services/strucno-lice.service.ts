import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StrucnoLice } from '../models/strucnoLice.models';


@Injectable({
  providedIn: 'root'
})
export class StrucnoLiceService {
  
  //strucnoLice:any;

  constructor(public httpClient: HttpClient) { 
   //this.uzmiStrucnoLice()
  }

  proveriDalIPostoji(username:string){ /////ZA REGISTRACIJU
    
   
    return this.httpClient.get("https://localhost:5001/StrucnoLice/ProveraRegistracijeStrucnoLice/"+username);
  }
 
  getLogovanoStrucnoLice(){ // LOGIN
    return this.httpClient.get("https://localhost:5001/StrucnoLice/LoginStrucnoLice/"+localStorage.getItem("strucnjak"))
   
  }
  // getLogovanoStrucnoLice(){  //LOGIN
  //   return this.strucnoLice;
  // }

  getStrucnaLica(){
    return this.httpClient.get("https://localhost:5001/StrucnoLice/GetStrucnaLica")
   }
   
   postStrucnoLice(strucnoLice : StrucnoLice ){
    return   this.httpClient.post("https://localhost:5001/StrucnoLice/AddStrucnoLica",strucnoLice)
   }
   isplatiNovac(idStrucnogLica:number,kolicinaNovca:number){
    return this.httpClient.put("https://localhost:5001/StrucnoLice/IsplatiNovac/"+idStrucnogLica+"/"+kolicinaNovca,idStrucnogLica);
  }
  deletePlan(idPlana : number){
    return this.httpClient.delete("https://localhost:5001/Plan/DeletePlan/"+idPlana+"/"+localStorage.getItem("strucnjak"))
  }

  azurirajStrucnoLice(strucnjak : StrucnoLice){
    return this.httpClient.put("https://localhost:5001/StrucnoLice/ChangeStrucnoLice",strucnjak);
   }
   obrisiStrucnoLice(StrucnoLiceKorisnickoIme:string){

    return this.httpClient.delete("https://localhost:5001/StrucnoLice/DeleteStrucnoLiceLicno/"+StrucnoLiceKorisnickoIme)

   }
}
