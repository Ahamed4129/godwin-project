import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {  Router } from '@angular/router';
const alertify = require('alertifyjs');

interface NewRegister{
  UserName:any;
  Email:any;
  Password:any;
}


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  hide = true;
  ObjNR:NewRegister={UserName:"",Email:"",Password:""}
  
  constructor( private _http:HttpClient,private router:Router) {}
  LetterOnly(event:any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return true;
    }
    return false;
  
  }
  
  
  NewEntry = new FormGroup({
    UserName: new FormControl('',[Validators.required,Validators.pattern(/^[a-zA-Z ]*$/)]),
    Email:new FormControl('',[Validators.required,Validators.email]),
    Password: new FormControl('',[Validators.required,Validators.minLength(5)])
  })
  
  
  
  
  get UserName(){
    return this.NewEntry.get('UserName')
  }
  get Email(){
    return this.NewEntry.get('Email')
  }
  get Password(){
    return this.NewEntry.get('Password')
  }
  
  
  AddRegistration(){
    debugger
    this.SaveRegister().subscribe( response =>{
      alertify.success('Account Created.');
      this.router.navigate(["Logout"])
      
   });
   }
  
   SaveRegister() {
    var body = JSON.stringify(this.ObjNR)
    console.log(this.ObjNR)
    const headers = new HttpHeaders().set('content-type','application/json');
    return this._http.post('https://localhost:7125/api/Login',body,{headers});
   }
   
  
  }
  


