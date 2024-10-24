import { Component, EventEmitter, HostListener, Output } from '@angular/core';
import { navbarData } from './nav-data';

interface SideNavToggle {
  screenWidth: number;
  collapsed: boolean;
}

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent {

  
  @Output() onToggleSideNav: EventEmitter<SideNavToggle> = new EventEmitter();
  collapsed = false;
  screenWidth = 0;
  navData = navbarData;

  profileDetail: any[] =[];
  // sideNavCollapsed = false;

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.screenWidth = window.innerWidth;
    if (this.screenWidth <= 768) {
      this.collapsed = false;
      this.onToggleSideNav.emit({ collapsed: this.collapsed, screenWidth: this.screenWidth });

    }
  }

  // constructor(private profileService: AllServiceService) {}

  ngOnInit(): void {
    this.screenWidth = window.innerWidth;
    
    // this.profileService.getProfileData().subscribe((proData) => {
    //   console.log(proData);
    //   this.profileDetail = proData;
    // })
  }

  toggleCollapse(): void {
    this.collapsed = !this.collapsed;
    this.onToggleSideNav.emit({ collapsed: this.collapsed, screenWidth: this.screenWidth });
  }
  
  closeSidenav(): void {
    this.collapsed = false;
    this.onToggleSideNav.emit({ collapsed: this.collapsed, screenWidth: this.screenWidth });
  }

  userProfile = [
    {
      userName:'Leslie Alexander',
      userEmail: 'alexanderleslie@gmail.com',
      profileImg: '../../assets/Ellipse 1.png'
    }
  ]

}
