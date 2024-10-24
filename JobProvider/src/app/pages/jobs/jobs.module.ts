import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JobsRoutingModule } from './jobs-routing.module';
import { AllJobsComponent } from './all-jobs/all-jobs.component';


@NgModule({
  declarations: [
    AllJobsComponent
  ],
  imports: [
    CommonModule,
    JobsRoutingModule
  ]
})
export class JobsModule { }
