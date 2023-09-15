import { Component, OnInit,Output,EventEmitter, Input } from '@angular/core';
import { Router } from '@angular/router';
import { KorisnikService } from 'src/app/services/korisnik.service';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { faMoneyBill1Wave } from '@fortawesome/free-solid-svg-icons';
@Component({
  selector: 'app-popup-uplata',
  templateUrl: './popup-uplata.component.html',
  styleUrls: ['./popup-uplata.component.css']
})
export class PopupUplataComponent implements OnInit {
  faMoneyBill1Wave=faMoneyBill1Wave;
  faXmark=faXmark;

  @Output() closePopup=new EventEmitter();
  @Input() idUplata:number=0;
  public novacZaUplatu:number = 0;
  constructor(private korisnikService:KorisnikService,private router: Router) { }

  ngOnInit(): void {
  }

  close(){
    this.closePopup.emit();
  }
  onNovacZaUplatu(event : Event): void{

    this.novacZaUplatu = parseInt((event.target as HTMLInputElement).value);
   
   
   }
  izvrsiteTransakciju(){
    console.log(this.novacZaUplatu)
    this.korisnikService.uplatiNovac(this.idUplata,this.novacZaUplatu).subscribe()
    this.router.navigate(['pocetna']);
  }

}
