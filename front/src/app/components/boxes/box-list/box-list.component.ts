import { Component } from '@angular/core';
import { Box } from 'src/app/interfaces/box.interface';
import { Product } from 'src/app/interfaces/product.interface';
import { BoxXProductService } from 'src/app/services/box-x-product.service';
import { BoxesService } from 'src/app/services/boxes.service';

@Component({
  selector: 'app-box-list',
  templateUrl: './box-list.component.html',
  styleUrls: ['./box-list.component.css']
})
export class BoxListComponent {

  arrBoxes: Box[];
  productsByIdBox: Product[][];

  constructor (
    private boxesService : BoxesService,
    private boxXProductService : BoxXProductService ){
    this.arrBoxes = [];
    this.productsByIdBox = [];
  
  }

  async ngOnInit(){

    //Obtención de todos las Cajas
    this.arrBoxes = await this.boxesService.getAll()

    for(let box of this.arrBoxes ){

      const boxId  = box.id;

      //Obtención de los productos que tiene la Caja a partir del Id de la Caja
      const products = await this.boxXProductService.getProductByIdBox(boxId);
      this.productsByIdBox[boxId] = products;
      
    }
  }

  //Ordenar cajas por precio: de mayor a menor
  sortByPrizeMaxToMin(){
    this.arrBoxes = this.arrBoxes.sort((a, b) => b.prize - a.prize);
  }

  //Ordenar cajas por precio: de menor a mayor
  sortByPrizeMinToMax(){
    this.arrBoxes = this.arrBoxes.sort((a, b) => a.prize - b.prize);
  }
}
