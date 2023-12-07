import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Product } from '../interfaces/product.interface';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private baseUrl : string

  constructor(private httpClient : HttpClient ) {

    this.baseUrl = "http://localhost:5235/api/Product/"
  }

  //Obtención de todos los Productos  
  getAll() : Promise<Product[]>{
    const response = lastValueFrom(this.httpClient.get<Product[]>(this.baseUrl + "AllProducts"))

    return response
  }
}
