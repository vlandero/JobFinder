import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import CompanyResponse from 'src/models/CompanyResponse.model';
import ApiResponse from 'src/models/ApiResponse.model';

const sub = 'Companies'

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private apiService: ApiService) { }

  async deleteAllCompanies(): Promise<ApiResponse<void>> {
    return await this.apiService.request('post', `${sub}/register-finder`, {}, 'Error deleting all companies');
  }

  async deleteCompany(name: string): Promise<ApiResponse<void>> {
    return await this.apiService.request('delete', `${sub}/delete-company/${name}`, name, `Error deleting company ${name}`);
  }

  async modifyCompany(name: string): Promise<ApiResponse<void>> {
    return await this.apiService.request('post', `${sub}/modify-company/${name}`, name, `Error modifying company ${name}`);
  }

  async getCompany(name: string): Promise<ApiResponse<CompanyResponse>> {
    return await this.apiService.request('get', `${sub}/get-company/${name}`, name, `Error getting company ${name}`);
  }

  async getAllCompanies(): Promise<ApiResponse<CompanyResponse[]>> {
    return await this.apiService.request('get', `${sub}/get-all-companies`, {}, 'Error getting all companies');
  }
}
