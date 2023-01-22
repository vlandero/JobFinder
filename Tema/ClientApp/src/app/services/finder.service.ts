import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import ApiResponse from 'src/models/ApiResponse.model';
import FinderRequestRegister from 'src/models/FinderRequestRegister.model';
import UserRequestLogin from 'src/models/UserRequestLogin.model';
import Finder from 'src/models/Finder.model';
import FinderResponseLogin from 'src/models/FinderResponseLogin.model';
import Applicant from 'src/models/Applicant.model';

const sub = 'Finders'

@Injectable({
  providedIn: 'root'
})
export class FinderService {

  constructor(private apiService: ApiService) { }


  async registerFinder(dto: FinderRequestRegister) : Promise<ApiResponse<void>>{
    return await this.apiService.request('post', `${sub}/register-finder`, dto, 'Error registering finder');
  }

  async loginFinder(dto: UserRequestLogin) : Promise<ApiResponse<FinderResponseLogin>>{
    return await this.apiService.request('post', `${sub}/login-finder`, dto, 'Error logging in');
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
}
