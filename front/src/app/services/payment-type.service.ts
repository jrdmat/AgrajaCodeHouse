import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { PaymentType } from '../interfaces/paymentType.interface';

@Injectable({
  providedIn: 'root'
})
export class PaymentTypeService {

  private baseUrl : string

  constructor(private httpClient : HttpClient) 
  {
    this.baseUrl = "http://localhost:5235/api/PaymentType/"
    
  }

  //Obtener todos los Métodos de Pago
  getAll() : Promise<PaymentType[]>{
    const response = lastValueFrom(this.httpClient.get<PaymentType[]>(this.baseUrl + "AllPaymentTypes"))

    return response
  }
}
