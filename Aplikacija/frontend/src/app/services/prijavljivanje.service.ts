import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PrijavljivanjeService {
  //korisnici:any;
 // strucnjaci: any;
 // adminZaLogin:any;
  constructor(public httpClient: HttpClient) {
    //this.osveziKorisnike();
   // this.osveziStrucnjake();
    //this.uzmiAdmina();
   }

  //  getKorisnici(){
  //   return this.korisnici;
  //  }

  posaljiMejliSIfruKorisnik(email:string,password:string){
    return this.httpClient.get("https://localhost:5001/Korisnik/GetKorisnici/"+email+"/"+password)
   }
  //  getStrucnjake(){
  //   return this.strucnjaci;
  //  }

  posaljiMejliSifruStrucnjak(email:string,password:string){
     return this.httpClient.get("https://localhost:5001/StrucnoLice/GetStrucnaLica/"+email+"/"+password);
   }


   uzmiAdmina(){
    return this.httpClient.get("https://localhost:5001/Administrator/AdministratorLogin/"+localStorage.getItem("admin"))
  }
  // getLogovaniAdmin(){
  //   return this.adminZaLogin;
  // }

  /////
  autorizujKorisnika(){ 
    return this.httpClient.put("https://localhost:5001/Korisnik/KorisnikLogovanje/"+localStorage.getItem("korisnik"),localStorage.getItem("korisnik"));
  }
  odjaviKorisnika(){ 
    return this.httpClient.put("https://localhost:5001/Korisnik/KorisnikLogOut/"+localStorage.getItem("korisnik"),localStorage.getItem("korisnik"));
  }
  autorizujStrucnjaka(){ 
    return this.httpClient.put("https://localhost:5001/StrucnoLice/StrucnoLiceLogovanje/"+localStorage.getItem("strucnjak"),localStorage.getItem("korisnik"));
  }
  odjaviStrucnjaka(){ 
    return this.httpClient.put("https://localhost:5001/StrucnoLice/StrucnoLiceLogOut/"+localStorage.getItem("strucnjak"),localStorage.getItem("korisnik"));
  }
}
