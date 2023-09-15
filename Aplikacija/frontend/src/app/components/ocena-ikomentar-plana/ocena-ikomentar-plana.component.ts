import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { OcenaKomentarService } from 'src/app/services/ocena-komentar.service';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { faPaperPlane } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-ocena-ikomentar-plana',
  templateUrl: './ocena-ikomentar-plana.component.html',
  styleUrls: ['./ocena-ikomentar-plana.component.css']
})
export class OcenaIKomentarPlanaComponent implements OnInit {
  faPaperPlane=faPaperPlane;
  faXmark=faXmark;

  public ocena:number=1;
  public komentar:string="";

  @Input() idStrungoLica:number=0;
  @Input() idKorisnika:number=0;
 

  @Output() closePopup = new EventEmitter();
  constructor(private komentarOcenaServis: OcenaKomentarService) { }

  ngOnInit(): void {
  }

  close(){
    this.closePopup.emit();
  }

  onIzmeniKomentar(event : Event): void{
    this.komentar = (event.target as HTMLInputElement).value;
   
    
   }
    
   IzaberiOcenu(event : Event){
     
      this.ocena = parseInt((event.target as HTMLInputElement).value);
    
   }

  posaljiKomentarIOcenu(){
    this.komentarOcenaServis.posaljiOcenuKomentar(this.komentar,this.idStrungoLica,this.idKorisnika,this.ocena).subscribe();
    this.close();
    alert("Uspešno ste ocenili stručno lice!");
  }


}
