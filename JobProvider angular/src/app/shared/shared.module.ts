import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { SideBarComponent } from './components/side-bar/side-bar.component';
import { HeaderComponent } from './components/header/header.component';
import { BodyFullComponent } from './components/body-full/body-full.component';
import { BodyControlComponent } from './components/body-control/body-control.component';

import { OverlayModule } from '@angular/cdk/overlay';
import { CdkMenuModule } from '@angular/cdk/menu';

@NgModule({
  declarations: [
  
    SideBarComponent,
    HeaderComponent,
    BodyFullComponent,
    BodyControlComponent
  ],
  imports: [
    CommonModule,
    SharedRoutingModule,
    OverlayModule,
    CdkMenuModule
  ]
})
export class SharedModule { }
