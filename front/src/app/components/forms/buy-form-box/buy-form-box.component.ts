import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Box } from 'src/app/interfaces/box.interface';
import { PaymentType } from 'src/app/interfaces/paymentType.interface';
import { BoxesService } from 'src/app/services/boxes.service';
import { PaymentTypeService } from 'src/app/services/payment-type.service';

@Component({
  selector: 'app-buy-form-box',
  templateUrl: './buy-form-box.component.html',
  styleUrls: ['./buy-form-box.component.css']
})
export class BuyFormBoxComponent {

  form! : FormGroup;
  arrPaymentTypes! : PaymentType[]
  id! : number;
  box : Box;
  

  constructor(
  private paymentTypeService : PaymentTypeService,
  private boxesService : BoxesService,
  private activatedRoute : ActivatedRoute,
  private router : Router) 
  {
    this.box = {
      id: 0,
      name: "",
      description: "",
      kg: 0,
      prize: 0,
      stock: 0,
      picture: ""
    }
  }

  async ngOnInit(){

    this.form = new FormGroup({
      phone: new FormControl('',Validators.required),
      provinze: new FormControl('',Validators.required),
      poblation: new FormControl('',Validators.required),
      postalCode: new FormControl('',Validators.required),
      direction: new FormControl('',Validators.required),
      paymentType: new FormControl('',Validators.required),
    })

    //Obtención de todos los métodos de pago
    this.arrPaymentTypes = await this.paymentTypeService.getAll();

    this.activatedRoute.params.subscribe(async(params : any) =>{
    //Obtención del id de la caja por ruta
    const id = parseInt(params.idbox);
  
    this.id = id;

    //Obtención de la Caja por su Id  
    this.box = await this.boxesService.getById(this.id);

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

    alert("La compra se ha realizado correctamente.")
    this.router.navigate(['/home']);
  }
}
