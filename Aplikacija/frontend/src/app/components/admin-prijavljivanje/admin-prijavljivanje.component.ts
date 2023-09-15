import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { faRightToBracket } from '@fortawesome/free-solid-svg-icons';
import { delay } from 'rxjs';

@Component({
  selector: 'app-admin-prijavljivanje',
  templateUrl: './admin-prijavljivanje.component.html',
  styleUrls: ['./admin-prijavljivanje.component.css']
})
export class AdminPrijavljivanjeComponent implements OnInit {
  faRightToBracket=faRightToBracket;
  faXmark=faXmark;
  exform:FormGroup;
  
  adminZaLogin:any = null;
  email:string="";
  lozinka:string="";
  constructor(private adminService : AdminService,
    private router: Router) { 
      
    }



  ngOnInit(): void {
    this.exform=new FormGroup({
      'email':new FormControl(null,[Validators.required,Validators.email]),
      'lozinka':new FormControl(null,[Validators.required,Validators.pattern("^[a-zA-Z0-9]+$"),Validators.maxLength(50)])
    })

    
 
  }

  prijaviSeAdmin(){

    this.adminService.posaljiMejliSIfru(this.email,this.lozinka).subscribe((admini:any)=>{
      this.adminZaLogin=admini;
    },
      (error)=>{

      },()=>{
       
        if(this.adminZaLogin[0] !=null)
    {
        
       localStorage.setItem("admin",this.email); 
       this.adminService.autorizujAdmina().subscribe((value)=>{

       },(error)=>{

       },()=>{
        this.router.navigate(['pocetna']);
       }); 
       
    } 
    else{
        alert("Uneli ste pogrešne podatke")
      }
        
        
      });
 
   }

   onIzmeniEmail(event : Event): void{
    this.email = (event.target as HTMLInputElement).value;
   
   }
   onIzmeniSifru(event : Event): void{
    this.lozinka = (event.target as HTMLInputElement).value;
   
   }

}
