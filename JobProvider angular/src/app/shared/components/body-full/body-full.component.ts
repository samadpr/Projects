import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-body-full',
  templateUrl: './body-full.component.html',
  styleUrls: ['./body-full.component.css']
})
export class BodyFullComponent {

  @Input()collapsed =false;
  @Input()screenWidth = 0;

  getBodyClass():string {

    let styleClass =''
    if(this.collapsed && this.screenWidth > 768){
      styleClass ='body-trimmed';
    }else if(this.collapsed && this.screenWidth <= 786 && this.screenWidth > 0){
      styleClass = 'body-md-screen'
    }
    return styleClass;
  }
}
