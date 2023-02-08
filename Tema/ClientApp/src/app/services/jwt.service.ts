import { Injectable } from '@angular/core';
import jwt from 'jwt-decode'

@Injectable({
  providedIn: 'root'
})
export class JwtService {

  constructor() { }

  JWTDecode(token: string) {
    const tk = jwt(token);
    return tk || null;
  }
}
