import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  
  
  constructor(public httpClient: HttpClient) {
    
    
   }


   posaljiMejliSIfru(email:string,password:string){
    return this.httpClient.get("https://localhost:5001/Administrator/GetAdminstrator/"+email+"/"+password);
  }

   osveziStrucnaLicaZaDozvolu(){
    return this.httpClient.get("https://localhost:5001/StrucnoLice/GetStrucnaLicaZaOdobrenje/"+localStorage.getItem("admin"));
    
   }
   deleteKorisnik(korisnik : any){
    return this.httpClient.delete("https://localhost:5001/Korisnik/DeleteKorisnik/"+korisnik+"/"+localStorage.getItem("admin"))
  }
  deleteStrucnoLice(strucnoLice : any){
    return this.httpClient.delete("https://localhost:5001/StrucnoLice/DeleteStrucnoLice/"+strucnoLice+"/"+localStorage.getItem("admin"))
  }
  //dodao sam ovo iz local storage i ove dve na dole su nove
  odobriStrucnoLice(idStrucnogLica:any){ 
    return this.httpClient.put("https://localhost:5001/Administrator/AdministratorAutentifikacijaStrucnogLica/"+idStrucnogLica+"/"+localStorage.getItem("admin"),idStrucnogLica);
  }
  autorizujAdmina(){ 
    return this.httpClient.put("https://localhost:5001/Administrator/AdministratorLogovanje/"+localStorage.getItem("admin"),localStorage.getItem("admin"));
  }
  odjaviAdmina(){ 
    return this.httpClient.put("https://localhost:5001/Administrator/AdministratorLogOut/"+localStorage.getItem("admin"),localStorage.getItem("admin"));
  }

  osveziKorisnike(){
    return this.httpClient.get("https://localhost:5001/Administrator/GetKorisniciAdmin/"+localStorage.getItem("admin"));
  }
 

  osveziStrucnjake(){
    return this.httpClient.get("https://localhost:5001/Administrator/GetStrucnaLicaAdmin/"+localStorage.getItem("admin"));
  }

  
}
