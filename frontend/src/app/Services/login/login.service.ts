import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICurrentUser } from '../../core/models/user.interface'; 
import { SignOutService } from '../signout/sign-out.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  signOutService:SignOutService = inject(SignOutService);

  constructor(private http: HttpClient) { }
  url =" http://localhost:5228/api/auth/login";
  urlCurrentUser =" http://localhost:5228/api/auth/CurrentUser";


  postLoginUser = (user:ICurrentUser):Observable<any> => {
    const headers={'content-type': 'application/json'}
    const body=JSON.stringify(user);
    console.log(body)
    this.signOutService.setCurrentUser(user);
    console.log(user)
    return this.http.post(this.url, body,{'headers':headers, withCredentials: true})
  }
  getUser = () => {
    return this.http.get(this.urlCurrentUser, {withCredentials : true})
  }
}
