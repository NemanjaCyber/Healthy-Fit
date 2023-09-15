import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PlanoviService } from 'src/app/services/planovi.service';
import { faCarrot, faXmarksLines } from '@fortawesome/free-solid-svg-icons';
import { faXmark } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-strucno-lice-dodaj-obrok',
  templateUrl: './strucno-lice-dodaj-obrok.component.html',
  styleUrls: ['./strucno-lice-dodaj-obrok.component.css']
})
export class StrucnoLiceDodajObrokComponent implements OnInit {
  faCarrot=faCarrot;
  faXmark=faXmark;
  exform:FormGroup

  @Input() planId:number=0;
  @Output() closePopup = new EventEmitter();
  public dan:string="";
  public tipObroka:string="";
  public slikaPutanja:string="slika";
  public opis:string="";
  
  constructor( private planoviService: PlanoviService,private router: Router) { }

  ngOnInit(): void {
    this.exform=new FormGroup({
      'dan':new FormControl(null,[Validators.required]),
      'tip':new FormControl(null,[Validators.required]),//dorucak rucak vecera uzina
      'opis':new FormControl(null,[Validators.required]),
     // 'slika':new FormControl(null,[Validators.required]),
    });
  }
  close(){
    this.closePopup.emit();
  }
  onIzmeniDan(event : Event): void{
    this.dan = (event.target as HTMLInputElement).value;
  }
  onIzmeniTipObroka(event : Event): void{
    this.tipObroka = (event.target as HTMLInputElement).value;
  }
  onIzmeniSliku(event : Event): void{
    this.slikaPutanja = (event.target as HTMLInputElement).value;
  }
  onIzmeniOpis(event : Event): void{
    this.opis = (event.target as HTMLInputElement).value;
  }
  dodajObrok(){
    
    
    this.planoviService.dodajObrok(this.planId,this.dan,this.tipObroka,this.slikaPutanja,this.opis).subscribe();
    alert("Uspešno dodavanje obroka.");
    this.router.navigate(['pocetna']);
  }

}
