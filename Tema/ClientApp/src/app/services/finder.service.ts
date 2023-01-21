import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

const sub = 'Companies'

@Injectable({
  providedIn: 'root'
})
export class FinderService {

  constructor(private apiService: ApiService) { }

  registerFinder(){
    this.apiService.request('post', `${sub}/register-finder`);
  }

  loginFinder(){
    this.apiService.request('post', `${sub}/login-finder`);
  }

  deleteAllFinders(){
    this.apiService.request('delete', `${sub}/delete-all-finders`);
  }

  deleteFinder(email: string){
    this.apiService.request('delete', `${sub}/delete-finder/${email}`);
  }

  applyToJob(){
    this.apiService.request('post', `${sub}/apply-to-job`);
  }

  modifyFinder(){
    this.apiService.request('post', `${sub}/modify-finder`);
  }

  getFinderByEmail(email: string){
    this.apiService.request('get', `${sub}/get-finder/${email}`);
  }

  getFinderByUrl(url: string){
    this.apiService.request('get', `${sub}/get-finder-url/${url}`);
  }
}
