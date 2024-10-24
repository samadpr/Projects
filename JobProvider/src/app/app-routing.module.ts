import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SideBarComponent } from './shared/components/side-bar/side-bar.component';
import { HeaderComponent } from './shared/components/header/header.component';

const routes: Routes = [
  
  {
    path:'',
    loadChildren:()=>import('./auth/auth.module').then(m=>m.AuthModule)
  },
  // {
  //   path:'shared',
  //   loadChildren:()=>import('./shared/shared.module').then(m=>m.SharedModule),
  // },
  {
    path:'Dashboard',
    loadChildren:()=>import('./pages/pages.module').then(m=>m.PagesModule)
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
