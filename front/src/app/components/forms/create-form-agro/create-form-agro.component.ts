import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AgroAdded } from 'src/app/interfaces/agro.interface';
import { Product } from 'src/app/interfaces/product.interface';
import { AgrosService } from 'src/app/services/agros.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-create-form-agro',
  templateUrl: './create-form-agro.component.html',
  styleUrls: ['./create-form-agro.component.css']
})
export class CreateFormAgroComponent {

  form! : FormGroup
  agroAdd! : AgroAdded
  productIds : number[]
  arrProducts! : Product[]
  

  constructor(
    private agrosService : AgrosService,
    private productsService : ProductsService,
    private router : Router,
  ){
    this.productIds = []
  }

  async ngOnInit(){
    
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      province: new FormControl('', Validators.required),
      prize: new FormControl('', Validators.required),
      picture: new FormControl('', Validators.required),
    })

    //Obtención de todos los productos
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

    this.agroAdd = this.form.value
    this.agroAdd.productIds = this.productIds

    //Construcción de la ruta de la imagen
    await this.agrosService.Add(this.agroAdd)
    alert("El Agro se ha añadido correctamente")
    this.router.navigate(['/agros']);

  }
    
}
  


