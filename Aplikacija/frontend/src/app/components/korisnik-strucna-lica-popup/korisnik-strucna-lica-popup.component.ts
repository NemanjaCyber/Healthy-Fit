import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faXmark } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-korisnik-strucna-lica-popup',
  templateUrl: './korisnik-strucna-lica-popup.component.html',
  styleUrls: ['./korisnik-strucna-lica-popup.component.css']
})
export class KorisnikStrucnaLicaPopupComponent implements OnInit {
  faXmark=faXmark;

  @Input() strucnoLice:any;



  @Output() closePopup = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }

 
  close(){
    
    this.closePopup.emit();
   
  }
}
