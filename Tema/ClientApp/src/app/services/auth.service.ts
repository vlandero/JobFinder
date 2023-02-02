import { Injectable } from '@angular/core';
import * as jwt from 'jsonwebtoken'

const secret = 'qwertyuiopasdfghjklzxcvbnm123456'

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  isLoggedIn() {
    const token = localStorage.getItem('token');
    return token != null;
  }

  logout() {
    localStorage.removeItem('token');
  }

  async JWTDecode(token: string) {
    try{
      const tk = jwt.verify(token, secret);
      return tk;
    }catch(e){
      return null;
    }
  }
}
