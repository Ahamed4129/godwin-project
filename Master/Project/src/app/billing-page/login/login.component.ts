import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Router } from '@angular/router';
const alertify = require('alertifyjs');

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  ObjNR: any = { UserName: "", Password: "",Email:"" }

  usersList: any = [];
  constructor(private _http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.getUserDetails();
  }


  getUserDetailsService() {
    
    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this._http.get("https://localhost:7125/api/Login", { headers })
  }

  getUserDetails() {
    this.getUserDetailsService().subscribe(response => {
      this.usersList = response;
      console.log(response, 'response');
    });
  }

  Login(): void {
    let index = this.usersList.findIndex((i: {
      email: any; 
    }) =>  i.email== this.ObjNR.Email);
    debugger;
    if (index == -1) {
      alertify.set('notifier','position', 'top-right');

      alertify.error('Invalid Email.'); 
    } else  {
      let index1 = this.usersList.findIndex((i: {
        email: any;
        password: any; 
      }) =>( i.email == this.ObjNR.Email) && i.password == this.ObjNR.Password);
      if (index1 == -1) {
        alertify.set('notifier','position', 'top-right');
        alertify.error('Invalid Password.'); 
      } else {
        alertify.set('notifier','position', 'top-right');
        alertify.success('Welcome.');
        this.router.navigate(['Home'])
      }
    }
  }

}
