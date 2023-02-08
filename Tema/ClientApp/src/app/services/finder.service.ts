import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import ApiResponse from 'src/models/ApiResponse.model';
import FinderRequestRegister from 'src/models/FinderRequestRegister.model';
import UserRequestLogin from 'src/models/UserRequestLogin.model';
import Finder from 'src/models/Finder.model';
import FinderResponseLogin from 'src/models/FinderResponseLogin.model';
import Applicant from 'src/models/Applicant.model';
import { AuthService } from './auth.service';
import { JwtService } from './jwt.service';

const sub = 'Finders'

@Injectable({
  providedIn: 'root'
})
export class FinderService {

  constructor(private apiService: ApiService, private jwtService: JwtService) { }

  async getLoggedIn() : Promise<ApiResponse<Finder>>{
    const userType = localStorage.getItem('user');
    if(userType !== 'finder')
      return {status: 401, data: null, message: 'Not logged in as finder'};
    const token = localStorage.getItem('token')!;
    const tokenInfo: any = this.jwtService.JWTDecode(token);
    if(!tokenInfo){
      return {status: 401, data: null, message: 'Error while parsing the token'};
    }
    const guid: string = tokenInfo.id;
    const x = await this.getFinderById(guid);
    return x;
  }

  async registerFinder(dto: FinderRequestRegister) : Promise<ApiResponse<void>>{
    return await this.apiService.request('post', `${sub}/register-finder`, dto, 'Error registering finder');
  }

  async loginFinder(dto: UserRequestLogin) : Promise<ApiResponse<FinderResponseLogin>>{
    const x =  await this.apiService.request<FinderResponseLogin>('post', `${sub}/login-finder`, dto, 'Error logging in');
    if(x.status === 200){
      localStorage.setItem('token', x.data!.token);
      localStorage.setItem('user', 'finder');
    }
    return x;
  }

  async deleteAllFinders() : Promise<ApiResponse<void>>{
    return await this.apiService.request('delete', `${sub}/delete-all-finders`, {}, 'Error deleting all finders');
  }

  async deleteFinder(email: string) : Promise<ApiResponse<void>>{
    return await this.apiService.request('delete', `${sub}/delete-finder`, email, `Error deleting finder ${email}`);
  }

  async applyToJob(dto: Applicant) : Promise<ApiResponse<void>>{
    return await this.apiService.request('post', `${sub}/apply-to-job`, dto, 'Error applying to job');
  }

  async modifyFinder(dto: Finder) : Promise<ApiResponse<void>>{
    return await this.apiService.request('post', `${sub}/modify-finder`, dto, 'Error modifying finder');
  }

  async getFinderByEmail(email: string) : Promise<ApiResponse<Finder>>{
    return await this.apiService.request('get', `${sub}/get-finder/${email}`, email, `Error getting finder ${email}`);
  }

  async getFinderByUrl(url: string) : Promise<ApiResponse<Finder>>{
    return await this.apiService.request('get', `${sub}/get-finder-url/${url}`, url, `Error getting finder ${url}`);
  }

  async getFinderById(id: string) : Promise<ApiResponse<Finder>>{
    return await this.apiService.request('get', `${sub}/get-finder-id/${id}`, id, `Error getting finder ${id}`);
  }

  async getAllFinders() : Promise<ApiResponse<Finder[]>>{
    return await this.apiService.request('get', `${sub}/get-all-finders`, {}, 'Error getting all finders');
  }
}
