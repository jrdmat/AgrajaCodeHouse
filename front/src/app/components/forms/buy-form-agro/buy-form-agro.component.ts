import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Agro } from 'src/app/interfaces/agro.interface';
import { PaymentType } from 'src/app/interfaces/paymentType.interface';
import { Product } from 'src/app/interfaces/product.interface';
import { AgrosService } from 'src/app/services/agros.service';
import { PaymentTypeService } from 'src/app/services/payment-type.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-buy-form-agro',
  templateUrl: './buy-form-agro.component.html',
  styleUrls: ['./buy-form-agro.component.css']
})

export class BuyFormAgroComponent {

  form! : FormGroup;
  arrPaymentTypes! : PaymentType[];
  arrProducts! : Product[];
  id! : number;
  agro : Agro;

  constructor(
  private paymentTypeService : PaymentTypeService,
  private productsService : ProductsService,
  private agrosService : AgrosService,
  private activatedRoute: ActivatedRoute,
  private router : Router) 
  {
    this.agro = {
    id: 0,
    name: "",
    description:"",
    province:"",
    prize: 0,
    picture: ""
    }
  }

  async ngOnInit(){

    this.form = new FormGroup({
      cultivation : new FormControl('',Validators.required),
      phone: new FormControl('',Validators.required),
      provinze: new FormControl('',Validators.required),
      poblation: new FormControl('',Validators.required),
      postalCode: new FormControl('',Validators.required),
      direction: new FormControl('',Validators.required),
      paymentType: new FormControl('',Validators.required),
    })

    //Obtención de todos los métodos de pago
    this.arrPaymentTypes = await this.paymentTypeService.getAll();

    //Obtención de todos los productos
    this.arrProducts = await this.productsService.getAll();

    this.activatedRoute.params.subscribe(async(params : any) =>{
      //Obtención del id del agro por ruta
      const id = parseInt(params.idagro);
  
      this.id = id;
      
      //Obtención del Agro por su Id
      this.agro = await this.agrosService.getById(this.id);

    })
  }

  //Validación
  checkError(control: string, error: string) {
    if (this.form.get(control)?.hasError(error) && this.form.get(control)?.touched) {
      return true
    } else {
      return false
    }
  }

  onSubmit(){

    alert("La compra se ha realizado correctamente.");
    this.router.navigate(['/home']);
  }

  

}
