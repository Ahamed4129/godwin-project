import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Observable } from 'rxjs';
//import * as alertify from 'alertifyjs'
const alertify = require('alertifyjs');
import { Router } from '@angular/router';




interface GetCustomerDetails{
  poid:any;
  date:any;
  supplierID:any;
  ItemMaster:ItemMaster[];

}
  interface ItemMaster{
  ID:number;
  POID:any;
  ItemID:any;
  Quantity:any;
  UnitPrice:any;
  TotalPrice:any;
}

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {
  constructor( private _http:HttpClient,private router: Router,){}
  
  GetCustomerDetails:any=[];
  displayedColumns= ['CustomerID', 'Date', 'SupplierID','Action'];
  dataSource:any= new MatTableDataSource([]);
 

  ObjPO:GetCustomerDetails={
    poid: 0,
    date: '',
    supplierID: 0,
    ItemMaster:[] 
  }
  ObjItem:ItemMaster ={
    ID:0,
    POID:0,
    ItemID:0,
    Quantity:0,
    UnitPrice:0,
    TotalPrice:0
  }
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) _sort!:MatSort;
  


  

  ngOnInit():void {this.GetCustomerList()

  }
  
  GetCustomerList(){
    
  return this._http.get<any>("https://localhost:7208/api/POMaster").subscribe(response=>{
   console.log(response)
   this.dataSource= new MatTableDataSource(response)
   this.GetCustomerDetails=new MatTableDataSource(response);
   this.dataSource.paginator=this.paginator;
   this.dataSource.sort=this._sort;
  });
  }

  Delete(POID:number){
    
    
    
      alertify.confirm("Do you want to Delete Your Account",  ()=>{
        
        return this._http.delete<any>("https://localhost:7208/api/POMaster/"+POID)
        .subscribe(response =>{
      this.GetCustomerList();
       alertify.success('Account Deleted Successfully')
    });
      
    });
    
    
  }
   
    
  Edit(ObjPO:any){
this.edit(ObjPO);
  }
  edit(ObjPO:any){
    this.router.navigate(['CreateNew', ObjPO])
  }
}
