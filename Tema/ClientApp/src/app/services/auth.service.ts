import { Injectable } from '@angular/core';
import jwt from 'jwt-decode'
import Finder from 'src/models/Finder.model';
import Seeker from 'src/models/Seeker.model';
import { FinderService } from './finder.service';
import { SeekerService } from './seeker.service';

const secret = 'qwertyuiopasdfghjklzxcvbnm123456'

interface Logged {
  user: Finder | Seeker | null,
  type: 'finder' | 'seeker' | null
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  loggedUser : Logged = {
    user: null,
    type: null
  }
  async init(){
    if(!this.isLoggedIn())
      return;
    const userType = localStorage.getItem('user');
    const token = localStorage.getItem('token')!;
    const tokenInfo: any = this.JWTDecode(token);
    const guid: string = tokenInfo.id;
    if (!tokenInfo) {
      return;
    }
    switch (userType) {
      case 'seeker':
        const x = await this.seekerService.getSeekerById(guid);
        if(x.status !== 200){
          this.loggedUser.user = null;
          this.loggedUser.type = null;
          return;
        }
        this.loggedUser.user = x.data as Seeker;
        this.loggedUser.type = 'seeker';
        break;
      case 'finder':
        const y = await this.finderService.getFinderById(guid);
        if(y.status !== 200){
          this.loggedUser.user = null;
          this.loggedUser.type = null;
          return;
        }
        this.loggedUser.user = y.data as Finder;
        this.loggedUser.type = 'finder';
        break;
      default:
        this.loggedUser.user = null;
        this.loggedUser.type = null;
        break;
    }
    
  }
  constructor(private finderService: FinderService, private seekerService: SeekerService) {
    this.init();
  }
  isLoggedIn() {
    const token = localStorage.getItem('token');
    return token !== null;
  }

  whoLoggedIn() {
    return localStorage.getItem('user');
  }

  logout() {
    localStorage.removeItem('token');
  }

  JWTDecode(token: string) {
    const tk = jwt(token);
    return tk || null;
  }
}
