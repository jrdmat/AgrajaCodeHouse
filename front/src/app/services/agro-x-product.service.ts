import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Product } from '../interfaces/product.interface';
import { Agro } from '../interfaces/agro.interface';

@Injectable({
  providedIn: 'root'
})
export class AgroXProductService {

  private baseUrl : string;

  constructor(private httpClient : HttpClient) {

    this.baseUrl = 'http://localhost:5235/api/AgroxProduct/';

   }

   //Obtención de los Productos por el Id del Agro
   getProductByIdAgro(id: number): Promise<Product[]>{

    const response = lastValueFrom(this.httpClient.get<Product[]>(this.baseUrl + "ProductsByAgro/" + id));
    
    return response

   }

   //Obtención de los Agros por el Id del Producto
   getAgroByIdProduct(id: number): Promise<Agro[]>{
    
    const response = lastValueFrom(this.httpClient.get<Agro[]>(this.baseUrl + "AgrosByProduct/" + id));

    return response
   }
}
