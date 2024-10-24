import { Component } from '@angular/core';

@Component({
  selector: 'app-signup-or-login',
  templateUrl: './signup-or-login.component.html',
  styleUrls: ['./signup-or-login.component.css']
})
export class SignupOrLoginComponent {

  signupUsers: any[] = [];
  signupObj: any = {
    
  }

  constructor() { }
  ngOnInit(): void {
    
  }

}
