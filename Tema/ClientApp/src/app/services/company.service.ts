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
    const data = await this.apiService.request('delete', `${sub}/delete-all-companies`);
    return new ApiResponse({
      status: data.status,
      data: data.data,
      message: 'Error deleting all companies'
    });
  }

  async deleteCompany(name: string): Promise<ApiResponse<void>> {
    const data = await this.apiService.request('delete', `${sub}/delete-company/${name}`);
    return new ApiResponse({
      status: data.status,
      data: data.data,
      message: `Error deleting company ${name}`
    });
  }

  async modifyCompany(name: string): Promise<ApiResponse<void>> {
    const data = await this.apiService.request('post', `${sub}/modify-company/${name}`);
    return new ApiResponse({
      status: data.status,
      data: data.data,
      message: `Error modifying company ${name}`
    });
  }

  async getCompany(name: string): Promise<ApiResponse<CompanyResponse>> {
    const data = await this.apiService.request('get', `${sub}/get-company/${name}`);
    return new ApiResponse({
      status: data.status,
      data: data.data,
      message: `Error getting company ${name}`
    });
  }
}
