import { Component } from '@angular/core';
import { Agro } from 'src/app/interfaces/agro.interface';
import { Product } from 'src/app/interfaces/product.interface';
import { AgroXProductService } from 'src/app/services/agro-x-product.service';
import { AgrosService } from 'src/app/services/agros.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-agro-list',
  templateUrl: './agro-list.component.html',
  styleUrls: ['./agro-list.component.css']
})
export class AgroListComponent {

  arrAgros : Agro[]; 
  arrProducts:Product[];
  productsByIdAgro: Product[][]; //Matriz de productos

  constructor(
    private agrosService : AgrosService,
    private agroXProductService: AgroXProductService,
    private productsService : ProductsService){
    this.arrAgros = [];
    this.arrProducts = [];
    this.productsByIdAgro = [];

  }

  async ngOnInit(){

    //Obtención de todos los Agros y Productos(Tipos de cultivo)
    this.arrAgros = await this.agrosService.getAll()
    this.arrProducts = await this.productsService.getAll()
    
    for(let agro of this.arrAgros ){

      const agroId = agro.id;

      //Obtención de los productos que tiene el Agro a partir del Id del Agro
      const products= await this.agroXProductService.getProductByIdAgro(agroId);
      
      this.productsByIdAgro[agroId] = products;
      
    }
    
  }

  async productFilter($event: any){
    //Filtrar agros por producto
    
    if ($event.target.value == ""){
      //En el caso de seleccionar "Todos los Productos" devolver todos los Agros
      this.arrAgros = await this.agrosService.getAll();
    }else{
      //Obtención de los Agros que contienen el Producto a partir del Id del Producto
      this.arrAgros = await this.agroXProductService.getAgroByIdProduct($event.target.value)
    }
    
  }
}
