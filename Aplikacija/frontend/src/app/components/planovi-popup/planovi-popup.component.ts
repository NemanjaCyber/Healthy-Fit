import { Component, Input,EventEmitter, OnInit, Output } from '@angular/core';
import { KorisnikService } from 'src/app/services/korisnik.service';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { faCartShopping } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-planovi-popup',
  templateUrl: './planovi-popup.component.html',
  styleUrls: ['./planovi-popup.component.css']
})
export class PlanoviPopupComponent implements OnInit {
  faCartShopping=faCartShopping;
  faXmark=faXmark;
  @Input() Naziv = '';
  @Input() Oblast = '';
  @Input() Cena = 0;
  @Input() id = 0;
  @Input() idKorisnika =0;
  @Input() idStrucnogLica= 0;
  @Output() closePopup = new EventEmitter();
  constructor(private korisnikServica: KorisnikService) { }

  ngOnInit(): void {
  }

  close(){
    this.closePopup.emit();
  }
  kupiPlan(naziv:string,idKorisnika:number,idStrucnogLica:number){
    
    this.korisnikServica.kupiPlan(naziv,idKorisnika,idStrucnogLica).subscribe()
    this.close();
    alert("Uspešna kupovina plana.")

  }
}
