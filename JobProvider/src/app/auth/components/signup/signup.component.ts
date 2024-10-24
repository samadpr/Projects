import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { LoginService } from 'src/app/core/Service/login.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {

  signupUsers: any = {}

  @ViewChild('signupSubmit') form: NgForm;


  constructor(
    private routing: Router,
    private authservice: LoginService,
    private spinner: NgxSpinnerService
  ) { }

  openSignupSpinner() {
    this.spinner.show();
    setTimeout(() => {
      this.spinner.hide();
    }, 5000);
  }

  SignUpSubmited() {
    console.log(this.form.value);
    this.openSignupSpinner();

    this.signupUsers = this.form.value;

    this.authservice.postSignup(this.signupUsers).subscribe({
      
      next: () => {
        this.routing.navigate(['/Login'])
      },
      error: (err) => console.log(err)
    })
  }
}
