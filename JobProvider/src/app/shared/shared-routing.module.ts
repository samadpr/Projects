import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BodyControlComponent } from './components/body-control/body-control.component';
import { DashboardComponent } from '../pages/dashboard/dashboard.component';
import { MessagesComponent } from '../pages/messages/messages.component';
import { SettingsComponent } from '../pages/settings/settings.component';

const routes: Routes = [

  {
    path:'',
    component:BodyControlComponent,
    children:[
      {
        path:'',
        redirectTo:'dashboard',
        pathMatch:'full'},
      {
        path:'dashboard',
        component:DashboardComponent
      },
      {
        path:'company',
        loadChildren:()=>import('../pages/company/company.module').then(m=>m.CompanyModule)
      },
      {
        path:'jobs',
        loadChildren:()=>import('../pages/jobs/jobs.module').then(m=>m.JobsModule)
      },
      {
        path:'applications',
        loadChildren:()=>import('../pages/application/application.module').then(m=>m.ApplicationModule)
      },
      {
        path:'interview',
        loadChildren:()=>import('../pages/interview/interview.module').then(m=>m.InterviewModule)
      },
      {
        path:'messages',
        component:MessagesComponent
      },
      {
        path:'settings',
        component:SettingsComponent
      }
    ]
  }
  // {path:'',redirectTo:'bodycontrol',pathMatch:'full'},
  // {path:'bodycontrol',component:BodyControlComponent},
  // {path:'sideBar',component:SideBarComponent},
  // {path:'header',component:HeaderComponent},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SharedRoutingModule { }
