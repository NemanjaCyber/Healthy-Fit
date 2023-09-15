import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OcenaKomentarService {

  constructor(public httpClient: HttpClient) { }

  posaljiOcenuKomentar(komentar:string,idStruncogLica:number,IdKorisnika:number,ocena:number){
    return this.httpClient.post("https://localhost:5001/KomentariIOcena/KreiranjeKomentaraIOcene/"+komentar+"/"+idStruncogLica+"/"+IdKorisnika+"/"+ocena,komentar);
  }
}
