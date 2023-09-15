import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pocetna-posetilac',
  templateUrl: './pocetna-posetilac.component.html',
  styleUrls: ['./pocetna-posetilac.component.css']
})
export class PocetnaPosetilacComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
    if(localStorage.key(0)==="korisnik"){
      this.redirectKorisnik();
    }
    if(localStorage.key(0)==="strucnjak"){
      this.redirectStrucnoLice();
      
    }
    if(localStorage.key(0)==="admin"){
      this.redirectAdmin();
    }

  }
  redirectKorisnik(){
    this.router.navigate(['pocetna-korisnik']);
  }
  redirectStrucnoLice(){
    this.router.navigate(['pocetna-strucno-lice']);
  }
  redirectAdmin(){
    this.router.navigate(['admin']);
  }

}
