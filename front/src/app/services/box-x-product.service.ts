import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../interfaces/product.interface';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BoxXProductService {

  private baseUrl : string

  constructor(private httpClient : HttpClient) { 

    this.baseUrl = 'http://localhost:5235/api/BoxxProduct/'
  }

  //Obtención de los Productos por el Id de la Caja
  getProductByIdBox(id : number): Promise<Product[]>{

    const response = lastValueFrom(this.httpClient.get<Product[]>(this.baseUrl+ "ProductsByBox/" + id));
    
    return response

   }

}
