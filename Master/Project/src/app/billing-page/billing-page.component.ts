import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Router,ActivatedRoute } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { PurchaseOrderService } from '../Service/purchase-order.service';
const alertify = require('alertifyjs');



  interface POMaster{
  POID:number;
  Date:any;
  SupplierID:any;
  ItemMaster:ItemMaster[];

}
  interface ItemMaster{
  id:number;
  poid:any;
  itemID:any;
  quantity:any;
  unitPrice:any;
  totalPrice:any;
}
 interface GetSupplierDetails {
  supplierID:any;
  supplierName:any;
  phoneNumber:any;
  address:any;
 }

@Component({
  selector: 'app-billing-page',
  templateUrl: './billing-page.component.html',
  styleUrls: ['./billing-page.component.css']
})
export class BillingPageComponent {
  ObjPO:POMaster={ POID:0,Date:'',SupplierID:'',ItemMaster:[]}
  ObjItem:ItemMaster={ id:0,poid:0,itemID:0,quantity:0,unitPrice:0,totalPrice:0};
  ObjSupplier:GetSupplierDetails[]=[];
  
  editflag: boolean = false;
  index !:any;
  isEditing: boolean=false;

  constructor(private _http:HttpClient,private router:Router,private Active : ActivatedRoute,
    private service : PurchaseOrderService ) { }

  displayedColumns= ['S.no','ItemID', 'UnitPrice', 'Quantity', 'Total','Action'];
  dataSource:any= new MatTableDataSource([]);

  ngOnInit():void {this.GetSupplierList();
    debugger;
    console.log(this.Active.snapshot.params['POID'])
    if (this.Active.snapshot.params['POID']!=0){
    this.service.fetchPo(this.Active.snapshot.params['POID']).subscribe((result:any)=>
    {
      debugger
      console.log(result)
      {

        this.ObjPO.POID =result.poid;
        this.ObjPO.SupplierID= result.supplierID;
        this.ObjPO.Date = result.date;
        this.ObjPO.ItemMaster=result.itemMaster;
       // this.ObjPO =JSON.parse(JSON.stringify(result[0]));
        
        
        
       // this.objItem.Quantity=result.quantity
        this.ObjPO.ItemMaster = Object.values(this.ObjPO.ItemMaster);
        

        
       
        
       // this.objItem.Id=result.
        this.ObjPO.POID ===0 ? this.isEditing = false : this.isEditing = true;
      }
    }) 
    }

  }
   
  AddItems(){
    
    this.ObjPO.ItemMaster.push(this.generaterow())
  }
  generaterow(){
    return({
      id:0,poid:0,itemID:'',quantity:'',unitPrice:'',totalPrice:''
    })
  }
  Delete(i: any){
    this.ObjPO.ItemMaster.splice(i,1)
  }

 Save() {
  debugger
  this.TotalSave().subscribe( response =>{
    alertify.success('Register Account SuccessFully.'); 
    this.router.navigate(["MainPage"])
    

  });
 }

 TotalSave() {
  var body = this.ObjPO
  console.log(this.ObjPO)
  const headers = new HttpHeaders().set('content-type','application/json');
  return this._http.post('https://localhost:7208/api/POMaster',body,{headers});
 }
   
   
   
  
  
  GetSupplierList(){
    const headers=new HttpHeaders().set('content-type','application/json');
  return this._http.get<GetSupplierDetails[]>("https://localhost:7208/api/SupplierDetails").subscribe(response=>{
   console.log(response)
   this.ObjSupplier=response;
   
  });
  }

Update(){
  alertify.confirm("Do you want to Update Your Account",  ()=>{
    this.service.EditPo(this.ObjPO).subscribe(response=>{
      alertify.success('Account Updated Successfully')
      this.router.navigate(['Home'])
    });
}
  )};

}
