import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  url: string = 'http://localhost:3000';
  
  constructor(private http: HttpClient) { }

  postSignup(form: any):Observable<any>{
    return this.http.post(`${this.url}/signupUserData`, form);
  }

  getSignupData():Observable<any>{
    return this.http.get(`${this.url}/signupUserData`);
  }

}
