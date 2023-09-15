import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faCoins } from '@fortawesome/free-solid-svg-icons';
import { faDoorOpen } from '@fortawesome/free-solid-svg-icons';
import { PrijavljivanjeService } from 'src/app/services/prijavljivanje.service';
@Component({
  selector: 'app-nav-bar-ulogovani',
  templateUrl: './nav-bar-ulogovani.component.html',
  styleUrls: ['./nav-bar-ulogovani.component.css']
})
export class NavBarUlogovaniComponent implements OnInit {
  faDoorOpen=faDoorOpen;
  faCoins=faCoins;
  @Input() novac = 0;
  @Input() id = 0;
  isUplati=false;

  constructor( public prijavljivanjeService : PrijavljivanjeService,
    private router: Router) { }

  ngOnInit(): void {
  }

  uplati(){
    this.isUplati=true;
  }
  close(){
    this.isUplati=false;
  }
  odjaviSe(){
    this.prijavljivanjeService.odjaviKorisnika().subscribe();
    localStorage.clear()
    this.router.navigate(['pocetna']);
  }

}
