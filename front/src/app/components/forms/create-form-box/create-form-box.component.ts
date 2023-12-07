import { Component } from '@angular/core';
import { FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BoxAdded } from 'src/app/interfaces/box.interface';
import { Product } from 'src/app/interfaces/product.interface';
import { BoxesService } from 'src/app/services/boxes.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-create-form-box',
  templateUrl: './create-form-box.component.html',
  styleUrls: ['./create-form-box.component.css']
})
export class CreateFormBoxComponent {

  form! : FormGroup
  boxAdd! : BoxAdded
  productIds : number[]
  arrProducts! : Product[]

  constructor(
    private boxesService : BoxesService,
    private productsService : ProductsService,
    private router : Router,
  ){
    this.productIds = []
  }

  async ngOnInit(){
    
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      kg: new FormControl('', Validators.required),
      prize: new FormControl('', Validators.required),
      stock: new FormControl('',Validators.required),
      picture: new FormControl('', Validators.required),
      
    })

    this.arrProducts = await this.productsService.getAll()
    for (let product of this.arrProducts){
      //Addición del un control en el formo por cada producto
      this.form.addControl(product.name, new FormControl(''));
    }
  }

  //Validación
  checkError(control: string, error: string) {
    if (this.form.get(control)?.hasError(error) && this.form.get(control)?.touched) {
      return true
    } else {
      return false
    }
  }

  async onSubmit(){
    //Construcción de la ruta de la imagen
    this.form.value.picture = "./././assets/img/" + this.form.value.picture.trim() + ".jpg"

    //Obtención de las claves del form
    const controlsKeys = Object.keys(this.form.controls)
    
    for(let controlKey of controlsKeys){

      //Por cada clave obtener su valor
      const controlValue = this.form.get(controlKey)

      //Obtención del producto que tenga el mismo nombre que el controlKey
      const product = this.arrProducts.find((product) => product.name == controlKey)

      if(controlValue?.value === true){
        
        if(product !==undefined){
          //Si el el valor del controlador es true y no undefined añadir el id del product en productsIds
          this.productIds.push(product.id)
        }
      }
    }

    this.boxAdd = this.form.value
    this.boxAdd.productIds = this.productIds

    //Addición de la nueva Caja
    await this.boxesService.Add(this.boxAdd)
    alert("La Caja se ha añadido correctamente")
    this.router.navigate(['/boxes']);

  }

}
