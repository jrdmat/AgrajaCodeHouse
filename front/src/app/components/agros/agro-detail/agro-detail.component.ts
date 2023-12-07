import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Agro } from 'src/app/interfaces/agro.interface';
import { Product } from 'src/app/interfaces/product.interface';
import { AgroXProductService } from 'src/app/services/agro-x-product.service';
import { AgrosService } from 'src/app/services/agros.service';

@Component({
  selector: 'app-agro-detail',
  templateUrl: './agro-detail.component.html',
  styleUrls: ['./agro-detail.component.css']
})
export class AgroDetailComponent {

  agroById : Agro;
  productsByAgro! : Product[]; 

  constructor (
    private agrosService: AgrosService,
    private agroXProductService: AgroXProductService, 
    private activatedRoute: ActivatedRoute,
    private router: Router){

    this.agroById = {
      id: 0,
      name: "",
      description:"",
      province:"",
      prize: 0,
      picture: ""
    }
    
  }

  ngOnInit(){
    this.activatedRoute.params.subscribe(async(params : any) =>{
      
      const id = parseInt(params.idagro);

      this.agroById = await this.agrosService.getById(id);

      //Obtencion de los productos por el Id del Agro
      this.productsByAgro = await this.agroXProductService.getProductByIdAgro(id);


    })

  }

  OnDelete(){
    this.activatedRoute.params.subscribe(async(params : any) =>{
      //Obtención del Id del Agro
      const id = parseInt(params.idagro);

      //Eliminación del Agro
      await this.agrosService.delete(id);
      alert("El agro se ha eliminado correctamente")
      this.router.navigate(['/agros']);

    })
  }

}
