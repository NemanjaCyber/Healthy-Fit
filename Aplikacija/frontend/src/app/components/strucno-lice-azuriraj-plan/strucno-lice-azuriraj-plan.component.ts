import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PlanoviService } from 'src/app/services/planovi.service';
import { faXmark } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-strucno-lice-azuriraj-plan',
  templateUrl: './strucno-lice-azuriraj-plan.component.html',
  styleUrls: ['./strucno-lice-azuriraj-plan.component.css']
})
export class StrucnoLiceAzurirajPlanComponent implements OnInit {
  faXmark=faXmark;
  exform:FormGroup

  @Input() plan:any;
  @Input() strucnjakId:number=0;
  public idPlana:number=0;
  public nazivPlana:string="";
  public opisPlana:string="";
  public cena:number=0;

  @Output() closePopup = new EventEmitter();
  
  constructor(private planoviService: PlanoviService , private router: Router) {
    
   }

  ngOnInit(): void {
    this.idPlana=this.plan.id;
    this.exform=new FormGroup({
      'naziv':new FormControl(null, [Validators.required]),
      'opis':new FormControl(null,Validators.required),
      'cena':new FormControl(null,[Validators.required,Validators.min(1)])
    })
  }

  close(){
    this.closePopup.emit();
  }
  onIzmeniNaziv(event : Event): void{
    this.nazivPlana = (event.target as HTMLInputElement).value;
  }
  onIzmeniOpis(event : Event): void{
    this.opisPlana = (event.target as HTMLInputElement).value;
  }
  onIzmeniCenu(event : Event): void{
    this.cena = parseInt((event.target as HTMLInputElement).value);
  }
  azuriraj(){
    this.planoviService.azurirajPlan(this.idPlana,this.strucnjakId,this.nazivPlana,this.opisPlana,this.cena).subscribe()
    alert("Uspešno izmenjen plan.");
    this.router.navigate(['pocetna']);
  }
}
