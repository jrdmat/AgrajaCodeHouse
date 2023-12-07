import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { Agro, AgroAdded, UptadatedAgro } from '../interfaces/agro.interface';

@Injectable({
  providedIn: 'root'
})
export class AgrosService {

  private baseUrl : string

  constructor(private httpClient : HttpClient) { 

    this.baseUrl = 'http://localhost:5235/api/Agro/';

  }

  //Obtener todos los Agros
  getAll(): Promise<Agro[]> {
    const response = lastValueFrom(this.httpClient.get<Agro[]>(this.baseUrl + "AllAgros"))

    return response
  }

  //Obtener un Agro por su id
  getById(id: number): Promise<Agro>{
    const response = lastValueFrom(this.httpClient.get<Agro>(this.baseUrl + id))

    return response
  }

  //Actualizar un Agro
  update(id : number, updatedAgro: UptadatedAgro){

    const response = lastValueFrom(this.httpClient.put(this.baseUrl + "UpdateAgro/" + id, updatedAgro))
  
    return response
  }

  //Eliminar Agro
  delete(id: number) {
    const response = lastValueFrom(this.httpClient.delete(this.baseUrl + id))

    return response
  }

  //Agregar nuevo Agro
  Add(newAgro: AgroAdded): Promise<AgroAdded>{

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-type': 'application/json; charset=UTF-8',
      })
    }

    const response = lastValueFrom(this.httpClient.post<AgroAdded>(this.baseUrl + "AddAgro", newAgro, httpOptions))
    return response
  }

}
