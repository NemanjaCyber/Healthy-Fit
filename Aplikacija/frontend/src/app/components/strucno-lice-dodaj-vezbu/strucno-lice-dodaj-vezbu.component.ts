import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PlanoviService } from 'src/app/services/planovi.service';
import { faDumbbell } from '@fortawesome/free-solid-svg-icons';
import { faXmark } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-strucno-lice-dodaj-vezbu',
  templateUrl: './strucno-lice-dodaj-vezbu.component.html',
  styleUrls: ['./strucno-lice-dodaj-vezbu.component.css']
})
export class StrucnoLiceDodajVezbuComponent implements OnInit {
  faDumbbell=faDumbbell;
  faXmark=faXmark;
  exform:FormGroup

  @Input() planId:number=0;
  @Output() closePopup = new EventEmitter();
  public dan:string="";
  public periodDana:string="";
  public brojPonavljanja:number=0;
  public slikaPutanja:string="slika";
  public opis:string="";
  
  constructor( private planoviService: PlanoviService,private router: Router ) { }

  ngOnInit(): void {
    this.exform=new FormGroup({
      'dan':new FormControl(null,[Validators.required]),
      'period':new FormControl(null,[Validators.required]),
      'ponavljanja':new FormControl(null,[Validators.required,Validators.min(1)]),
      'opis':new FormControl(null,[Validators.required]),
      //'slika':new FormControl(null,[Validators.required]),
    })
  }
  close(){
    this.closePopup.emit();
  }
  onIzmeniDan(event : Event): void{
    this.dan = (event.target as HTMLInputElement).value;
  }
  onIzmeniPeriodDana(event : Event): void{
    this.periodDana = (event.target as HTMLInputElement).value;
  }
  onIzmeniBrojPonavljanja(event : Event): void{
    this.brojPonavljanja = parseInt((event.target as HTMLInputElement).value);
  }
  onIzmeniSliku(event : Event): void{
    this.slikaPutanja = (event.target as HTMLInputElement).value;
  }
  onIzmeniOpis(event : Event): void{
    this.opis = (event.target as HTMLInputElement).value;
  }
  dodajVezbu(){
    
    
    this.planoviService.dodajVezbu(this.planId,this.dan,this.periodDana,this.brojPonavljanja,this.slikaPutanja,this.opis).subscribe();
    alert("Uspešno dodavanje vežbe.");
    this.router.navigate(['pocetna']);
  }

}
