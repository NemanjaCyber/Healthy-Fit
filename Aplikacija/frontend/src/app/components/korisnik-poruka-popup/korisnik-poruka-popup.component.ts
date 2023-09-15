import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PorukaService } from 'src/app/services/poruka.service';
import { faPaperPlane } from '@fortawesome/free-solid-svg-icons';
import { faXmark } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-korisnik-poruka-popup',
  templateUrl: './korisnik-poruka-popup.component.html',
  styleUrls: ['./korisnik-poruka-popup.component.css']
})
export class KorisnikPorukaPopupComponent implements OnInit {
  faXmark=faXmark;
  faPaperPlane=faPaperPlane;

  @Input() strucnoLiceId:any;
  @Input() korisnikId:any;
  public sadrzajPoruke:string="";



  @Output() closePopup = new EventEmitter();

  constructor( private porukaService:PorukaService ) { }

  ngOnInit(): void {
  }

  close(){
    this.closePopup.emit();
   }
 
   onIzmeniPoruku(event : Event): void{
     this.sadrzajPoruke = (event.target as HTMLInputElement).value;
    
    }
 
    posalji(){
     this.porukaService.posaljiPorukuKorisnik(this.sadrzajPoruke,this.strucnoLiceId,this.korisnikId).subscribe()
     window.location.reload();
     alert("Uspešno ste poslali poruku.")
   }

}
