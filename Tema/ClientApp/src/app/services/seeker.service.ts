import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import ApiResponse from 'src/models/ApiResponse.model';
import SeekerRequestRegister from 'src/models/SeekerRequestRegister.model';
import UserRequestLogin from 'src/models/UserRequestLogin.model';
import SeekerResponseLogin from 'src/models/SeekerResponseLogin.model';
import Seeker from 'src/models/Seeker.model';
import TransferOwnership from 'src/models/TransferOwnership.model';
import { AuthService } from './auth.service';

const sub = 'Seekers'

@Injectable({
  providedIn: 'root'
})
export class SeekerService {

  constructor(private apiService: ApiService, private authService: AuthService) { }

  async getLoggedIn() : Promise<ApiResponse<Seeker>>{
    const userType = localStorage.getItem('user');
    if(userType !== 'seeker')
      return {status: 401, data: null, message: 'Not logged in as seeker'};
    const token = localStorage.getItem('token')!;
    const tokenInfo: any = this.authService.JWTDecode(token);
    if(!tokenInfo){
      return {status: 401, data: null, message: 'Error while parsing the token'};
    }
    const guid: string = tokenInfo.id;
    const x = await this.getSeekerById(guid);
    return x;
  }

  async registerSeeker(dto: SeekerRequestRegister) : Promise<ApiResponse<void>>{
    return await this.apiService.request('post', `${sub}/register-seeker`, dto, 'Error registering seeker');
  }

  async loginSeeker(dto: UserRequestLogin) : Promise<ApiResponse<SeekerResponseLogin>>{
    const x = await this.apiService.request<SeekerResponseLogin>('post', `${sub}/login-seeker`, dto, 'Error logging in seeker');
    if(x.status === 200){
      localStorage.setItem('token', x.data!.token);
      localStorage.setItem('user', 'seeker');
    }
    return x;
    
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

  async getSeekerById(id: string) : Promise<ApiResponse<Seeker>>{
    return await this.apiService.request('get', `${sub}/get-seeker-id/${id}`, {}, 'Error getting seeker');
  }

}
