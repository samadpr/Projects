import { Component, HostListener, Input } from '@angular/core';
import { notification, userItems } from './header-dummy-data';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  @Input() collapsed = false;
  @Input() screenWidth = 0;

  canShowSearchAsOverlay = false;

  notifications = notification;
  userItems = userItems;

  constructor() { }

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.checkCanShowSearchAsOverlay(window.innerWidth)
  }


  ngOnInit(): void {
    this.checkCanShowSearchAsOverlay(window.innerWidth)
  }

  getHeadClass(): string {
    let styleClass = '';
    if (this.collapsed && this.screenWidth > 768) {
      styleClass = 'head-trimmed'
    } else {
      styleClass = 'head-md-screen'
    }
    return styleClass;
  }

  checkCanShowSearchAsOverlay(innerWidth: number): void {
    if (innerWidth < 845) {
      this.canShowSearchAsOverlay = true;
    } else {
      this.canShowSearchAsOverlay = false;
    }
  }

}
