import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';

const routes: Routes = [
  {path:'',redirectTo:'Login',pathMatch:'full'},
  {path:'Login',component:LoginComponent},
  {path:'Signup',component:SignupComponent},
  {
    path:'shared',
    loadChildren:()=>import('../shared/shared.module').then(m=>m.SharedModule),
  },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
