import { Injectable } from '@angular/core';
import axios, { AxiosRequestConfig, AxiosResponse } from 'axios';

const url = 'https://localhost:5001'

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor() { }


  async request(method: 'get' | 'post' | 'put' | 'delete', path: string, data?: any, config?: AxiosRequestConfig): Promise<AxiosResponse> {
    try {
      return await axios({
        method,
        url: `${url}/${path}`,
        data,
        ...config
      });
    } catch (error) {
      console.error(error);
      throw error;
    }
  }
}
