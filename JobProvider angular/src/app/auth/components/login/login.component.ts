import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { LoginService } from 'src/app/core/Service/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginUsers: any = {}


  constructor(
    private routing: Router,
    loginservice: LoginService,
    private spinner: NgxSpinnerService
  ) {
    loginservice.getSignupData().subscribe(
      (signUpData) => {
        console.log(signUpData);

        this.loginUsers = signUpData;
      }
    )
  }
  ngOnInit(): void {

  }


  openSpinner() {
    this.spinner.show();
    setTimeout(() => {
      this.spinner.hide();
    }, 5000);
  }
  
  loginSubmited(logindata: NgForm) {
    console.log(logindata.value);

    

    const fileredUser = this.loginUsers.filter(users =>
      logindata.value.email == users.email && logindata.value.password == users.password
    )

    if (fileredUser.length > 0) {
      // localStorage.setItem('user', JSON.stringify(fileredUser[0]))
      this.openSpinner();
      this.routing.navigate(['/shared'])
    } else {
      alert("Invalid Email or Password")
    }

  }

}
