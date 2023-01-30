import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
const alertify = require('alertifyjs');

interface SupplierDetails {
  SupplierID:any;
  SupplierName:any;
  MobileNumber:any;
  Address:any;
}

@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css']
})
export class SupplierComponent {
  ObjSupDetails:SupplierDetails={
    SupplierID: 0, SupplierName: "", MobileNumber: "",
    Address:""
  };
  
 
 
   constructor(private _http:HttpClient,private router:Router) { }

  
  
  
  

  
 
   ngOnInit(): void {
   
   }
   
   SaveSupplier() {
    debugger
     this.Supplier().subscribe(response => {
      alertify.success('Supplier Added SuccessFully.'); 
       this.router.navigate(["Billing"])
       
     });
    }
   
    Supplier(){
     var body = (this.ObjSupDetails)
     const headers = new HttpHeaders().set('content-type','application/json');
      return this._http.post("https://localhost:7125/api/Supplier",body,{headers})
   }
 

}
