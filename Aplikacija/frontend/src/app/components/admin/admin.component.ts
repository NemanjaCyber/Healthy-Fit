import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { PrijavljivanjeService } from 'src/app/services/prijavljivanje.service';
import { faDoorOpen } from '@fortawesome/free-solid-svg-icons';
import { faBan } from '@fortawesome/free-solid-svg-icons';
import { faCheck } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  faDoorOpen=faDoorOpen;
  faBan=faBan;
  faCheck=faCheck;
  public ime:string = "";
  public prezime:string ="";
  public autorizacija:string ="";
  public korisniciIliStrucnaLica:boolean=true;
  logovaniAdmin: any;
  sviKorisnici:any;
  sviStrucnjaci:any;
  strucnjaciZaDozvolu:any;
  constructor(private adminService :AdminService, private router: Router,
     private prijavljivanjeService: PrijavljivanjeService) {
   
    
   }

  ngOnInit(): void {
    
    this.prijavljivanjeService.uzmiAdmina().subscribe((admini:any)=>{
      
      this.redirect();
      this.logovaniAdmin=admini;
      this.ime=admini[0].ime;
      this.prezime=admini[0].prezime;
      this.autorizacija=admini[0].autorizacija;
      
     
      
     
      
    },(error:any)=>{
      
       if(this.redirect()===0){
        //if(error.status===401)
       this.proveraAutorizacije()
    }
    }
    );

    this.adminService.osveziKorisnike().subscribe((korisnici:any)=>{ // OVO je da vidis sve korisnike
      this.sviKorisnici=korisnici;})

    this.adminService.osveziStrucnjake().subscribe((strucnjaci:any)=>{
      this.sviStrucnjaci=strucnjaci;
    })

    this.adminService.osveziStrucnaLicaZaDozvolu().subscribe((zaDozvolu:any)=>{
      this.strucnjaciZaDozvolu=zaDozvolu;
    })

    
    
  }


 
  korisnici(){
    this.korisniciIliStrucnaLica=true;
  }

  strucnaLica(){
    this.korisniciIliStrucnaLica=false;
  }
  odjaviMe(){
    this.adminService.odjaviAdmina().subscribe();
    localStorage.clear();
    this.router.navigate(['pocetna']);
  }

 obrisiKorisnika(zaBrisanje:string){
  this.adminService.deleteKorisnik(zaBrisanje).subscribe();
  alert("Uspešno ste obrisali korisnika");
  this.router.navigate(['pocetna']);
 }
 obrisiStrucnoLice(zaBrisanje:string){
  this.adminService.deleteStrucnoLice(zaBrisanje).subscribe();
  alert("Uspešno ste obrisali stručno lice");
  this.router.navigate(['pocetna']);
 }
 dozvolaZaStrucnoLice(idZaDozvolu:number){
  this.adminService.odobriStrucnoLice(idZaDozvolu).subscribe();
  alert("Stručno lice je dobilo dozvolu");
  this.router.navigate(['pocetna']);
 }
 proveraAutorizacije(){
  
  if(this.autorizacija!=="Admin"){
    localStorage.clear();
    this.router.navigate(['pocetna']);
  }
 }
 redirect(){
  if(localStorage.key(0)==="strucnjak" || localStorage.key(0)==="korisnik")
    {
      this.router.navigate(['pocetna']);
      return 1;
    }
    else return 0;
 }
 
}
