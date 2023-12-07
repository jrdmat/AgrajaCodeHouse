import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private baseUrl : string

  constructor(private httpClient : HttpClient) { 

    this.baseUrl = "http://localhost:5235/api/User"
  }

  

}
