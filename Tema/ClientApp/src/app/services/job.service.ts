import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import JobResponse from 'src/models/JobResponse.model';
import ApiResponse from 'src/models/ApiResponse.model';
import JobRequest from 'src/models/JobRequest.model';
import Finder from 'src/models/Finder.model';

const sub = 'Jobs'

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private apiService: ApiService) { }

  async getAllJobs() : Promise<ApiResponse<JobResponse[]>>{
    return await this.apiService.request('get', `${sub}/get-all-jobs`, {}, 'Error getting all jobs');
  }

  async deleteAllJobs() : Promise<ApiResponse<void>>{
    return await this.apiService.request('delete', `${sub}/delete-all-jobs`, {}, 'Error deleting all jobs');
  }

  async createJob(dto: JobRequest) : Promise<ApiResponse<JobResponse>>{
    return await this.apiService.request('post', `${sub}/create-job`, dto, 'Error creating jobs');
  }

  async getJob(id: number) : Promise<ApiResponse<JobResponse>>{
    return await this.apiService.request('get', `${sub}/get-job/${id}`, {}, 'Error getting job');
  }
}
