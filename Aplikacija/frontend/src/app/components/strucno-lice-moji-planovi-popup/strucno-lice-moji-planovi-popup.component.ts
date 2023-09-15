import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faXmark } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-strucno-lice-moji-planovi-popup',
  templateUrl: './strucno-lice-moji-planovi-popup.component.html',
  styleUrls: ['./strucno-lice-moji-planovi-popup.component.css']
})
export class StrucnoLiceMojiPlanoviPopupComponent implements OnInit {
  faXmark=faXmark

  public opisPlana:string="";
  public nazivPlana:string="";

  @Input() planZaPrikaz:any;
  @Output() closePopup = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }
  close(){
    this.closePopup.emit();
  }

}
