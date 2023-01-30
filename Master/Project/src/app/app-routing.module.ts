import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BillingPageComponent } from './billing-page/billing-page.component';
import { LoginComponent } from './billing-page/login/login.component';
import { RegisterComponent } from './billing-page/register/register.component';
import { MainPageComponent } from './main-page/main-page.component';
import { SupplierComponent } from './supplier/supplier.component';

const routes: Routes = [
  {path:'',component:LoginComponent},
  {path:'CreateNew',component:BillingPageComponent},
  {path:'CreateNew/:POID',component:BillingPageComponent},
  {path:'Home',component:MainPageComponent},
  {path:'AddNewSupplier',component:SupplierComponent},
  {path:'Billing',component:BillingPageComponent},
  {path:'MainPage',component:MainPageComponent},
  {path:'NewRegister',component:RegisterComponent},
  {path:'Logout',component:LoginComponent}

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
