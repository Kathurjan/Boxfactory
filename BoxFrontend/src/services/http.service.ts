import { Injectable } from '@angular/core';

import axios from 'axios';
export const customAxios = axios.create({
  baseURL: 'http://localhost:5051'
})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() {
    customAxios.interceptors.response.use(
      response => {
        if (response.status==201){

        }
        return response;
      }, rejectd =>{
        return rejectd;
      }
    )

   }

  async getBoxes(){
    const httpResponse = await customAxios.get<any>('Box')
    return httpResponse.data;


  }

  async createBox(box: { width: number; length: number; type: string }) {
   const httpResult = await customAxios.post('Box',box);
   return httpResult.data

  }

  async deleteBoxById(id: number) {
    const httpResult = await customAxios.delete('Box/'+id)
    return httpResult.data;
  }
}

