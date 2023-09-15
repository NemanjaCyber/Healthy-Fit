import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { PlanoviService } from 'src/app/services/planovi.service';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { faBan } from '@fortawesome/free-solid-svg-icons';
import { faStar } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-korisnik-kupljeni-planovi-popup',
  templateUrl: './korisnik-kupljeni-planovi-popup.component.html',
  styleUrls: ['./korisnik-kupljeni-planovi-popup.component.css']
})
export class KorisnikKupljeniPlanoviPopupComponent implements OnInit {
  faStar=faStar;
  faBan=faBan;
  faXmark=faXmark;

  @Input() korisnikId:number=0;
  @Input() strucnoLiceId:number=0;
  @Input() opisPlana:string="";
  @Input() nazivPlana:string="";
  @Input() planoviZaPrikaz:any;
  @Output() closePopup = new EventEmitter();
  public ocenaPlanaPrikaz:boolean = false;
  
  constructor(private planoviService: PlanoviService, private router: Router ) { }

  ngOnInit(): void {
  }


  close(){
    this.closePopup.emit();
  }
  otkaziPlan(){
  this.planoviService.otkaziPlan(this.nazivPlana,this.korisnikId).subscribe();
  this.router.navigate(['pocetna']);
  }
  oceniPlan(){


    this.ocenaPlanaPrikaz=true;

  }
  closeKomentarIOcena(){
    this.ocenaPlanaPrikaz=false;
  }
}
