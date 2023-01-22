import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import ApiResponse from 'src/models/ApiResponse.model';
import JobResponse from 'src/models/JobResponse.model';
import SeekerRequestRegister from 'src/models/SeekerRequestRegister.model';
import UserRequestLogin from 'src/models/UserRequestLogin.model';
import SeekerResponseLogin from 'src/models/SeekerResponseLogin.model';
import Seeker from 'src/models/Seeker.model';
import TransferOwnership from 'src/models/TransferOwnership.model';

const sub = 'Seekers'

@Injectable({
  providedIn: 'root'
})
export class SeekerService {

  constructor(private apiService: ApiService) { }

  async registerSeeker(dto: SeekerRequestRegister) : Promise<ApiResponse<void>>{
    return await this.apiService.request('post', `${sub}/register-seeker`, dto, 'Error registering seeker');
  }

  async loginSeeker(dto: UserRequestLogin) : Promise<ApiResponse<SeekerResponseLogin>>{
    return await this.apiService.request('post', `${sub}/login-seeker`, dto, 'Error logging in seeker');
  }

  async deleteAllSeekers() : Promise<ApiResponse<void>>{
    return await this.apiService.request('delete', `${sub}/delete-all-seekers`, {}, 'Error deleting seekers');
  }

  async deleteSeeker(email: string) : Promise<ApiResponse<void>>{
    return await this.apiService.request('delete', `${sub}/delete-seeker`, email, 'Error deleting seeker');
  }

  async modifySeeker(dto: Seeker) : Promise<ApiResponse<void>>{
    return await this.apiService.request('post', `${sub}/modify-seeker`, dto, 'Error modifying seeker');
  }

  async transferOwnership(dto: TransferOwnership) : Promise<ApiResponse<void>>{
    return await this.apiService.request('post', `${sub}/transfer-ownership`, dto, 'Error transferring ownership');
  }

  async getSeekerByEmail(email: string) : Promise<ApiResponse<void>>{
    return await this.apiService.request('get', `${sub}/get-seeker/${email}`, {}, 'Error getting seeker ' + email);
  }

  async getSeekerByUrl(url: string) : Promise<ApiResponse<void>>{
    return await this.apiService.request('get', `${sub}/get-seeker-url/${url}`, {}, 'Error getting seeker');
  }

}
