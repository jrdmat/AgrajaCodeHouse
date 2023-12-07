import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Box } from 'src/app/interfaces/box.interface';
import { Product } from 'src/app/interfaces/product.interface';
import { BoxXProductService } from 'src/app/services/box-x-product.service';
import { BoxesService } from 'src/app/services/boxes.service';

@Component({
  selector: 'app-box-detail',
  templateUrl: './box-detail.component.html',
  styleUrls: ['./box-detail.component.css']
})
export class BoxDetailComponent {

  boxById: Box;
  productsByBox! : Product[];

  constructor (
    private boxesService: BoxesService,
    private boxXProductService : BoxXProductService,
    private activatedRoute: ActivatedRoute,
    private router: Router){

    this.boxById = {
      id: 0,
      name: "",
      description: "",
      kg: 0,
      prize: 0,
      stock: 0,
      picture: ""
    }

  }

  ngOnInit(){
    this.activatedRoute.params.subscribe(async(params : any) =>{
      
      const id = parseInt(params.idbox);

      this.boxById = await this.boxesService.getById(id);

      //Obtencion de los productos por el Id de la Caja
      this.productsByBox = await this.boxXProductService.getProductByIdBox(id);
    })
  }

  OnDelete(){
    this.activatedRoute.params.subscribe(async(params : any) =>{
      //Obtención del Id de la Caja mediante la ruta
      const id = parseInt(params.idbox);

      //Eliminación de la Caja
      await this.boxesService.delete(id);
      alert("La caja se ha eliminado correctamente");
      this.router.navigate(['/boxes']);

    })
  }

}
