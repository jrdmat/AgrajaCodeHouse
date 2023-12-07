import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Box, BoxAdded, UpdatedBox } from '../interfaces/box.interface';

@Injectable({
  providedIn: 'root'
})
export class BoxesService {

  private baseUrl : string

  constructor(private httpClient : HttpClient ) {

    this.baseUrl = "http://localhost:5235/api/Box/"
  }

  //Obtener todas las cajas.
  getAll() : Promise<Box[]>{
    const response = lastValueFrom(this.httpClient.get<Box[]>(this.baseUrl + "AllBoxes"))

    return response
  }

  //Obtener una caja por su Id.
  getById(id: number): Promise<Box>{
    const response = lastValueFrom(this.httpClient.get<Box>(this.baseUrl + id))

    return response
  }

  //Actualizar una caja
  update(id: number, updatedBox: UpdatedBox): Promise<UpdatedBox>{

    const response = lastValueFrom(this.httpClient.put<UpdatedBox>(this.baseUrl + "UpdateBox/" + id, updatedBox))

    return response
  }

  //Eliminar Caja
  delete(id: number) {
    const response = lastValueFrom(this.httpClient.delete(this.baseUrl + id))

    return response
  }

  //Agregar nueva Caja
  Add(newBox: BoxAdded): Promise<BoxAdded>{

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-type': 'application/json; charset=UTF-8',
      })
    }

    const response = lastValueFrom(this.httpClient.post<BoxAdded>(this.baseUrl + "AddBox", newBox, httpOptions))
    return response
  }


}
