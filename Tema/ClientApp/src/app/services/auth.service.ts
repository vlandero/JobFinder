import { Injectable } from '@angular/core';
import jwt from 'jwt-decode'

const secret = 'qwertyuiopasdfghjklzxcvbnm123456'

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  isLoggedIn() {
    const token = localStorage.getItem('token');
    return token !== null;
  }

  whoLoggedIn(){
    return localStorage.getItem('user');
  }

  logout() {
    localStorage.removeItem('token');
  }

  JWTDecode(token: string) {
    try{
      const tk = jwt(token);
      return tk;
    }catch(e){
      return null;
    }
  }
}
