import { Injectable } from '@angular/core';

import axios from 'axios';
export const customAxios = axios.create({
  baseURL: "Https://localhost:5001"
})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

  async getBoxes(){
    const httpResponse = await customAxios.get('boxes');
    httpResponse.data;

  }
}

