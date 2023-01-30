import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PurchaseOrderService {
  private _POMasterUrl: string = "https://localhost:7208/api/POMaster/";
  constructor(private http :HttpClient) { }

  fetchPo(POID :any){
    return this.http.get<any>(this._POMasterUrl+POID)
  }
  EditPo(POID:any){
    return this.http.put<any>(this._POMasterUrl,POID)
  }
}
