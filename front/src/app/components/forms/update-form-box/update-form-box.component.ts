import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Box, UpdatedBox } from 'src/app/interfaces/box.interface';
import { BoxesService } from 'src/app/services/boxes.service';

@Component({
  selector: 'app-update-form-box',
  templateUrl: './update-form-box.component.html',
  styleUrls: ['./update-form-box.component.css']
})
export class UpdateFormBoxComponent {

  form! : FormGroup;
  updatedBox! : UpdatedBox
  id! : number
  box!: Box

  constructor(
     private boxesService: BoxesService,
     private activatedRoute: ActivatedRoute,
     private router: Router) {}
  
  ngOnInit(){
    
    this.form = new FormGroup({
      
      Name: new FormControl('', Validators.required),
      Description: new FormControl('', Validators.required),
      Stock: new FormControl('', Validators.required),
    })
    
    this.activatedRoute.params.subscribe(async(params : any) =>{
      //Obtención del id de la caja por ruta
      const id = parseInt(params.idbox);
  
      this.id = id;
      
      this.box = await this.boxesService.getById(this.id);

      //Actualización de los valores iniciales del form.
      this.form.patchValue({
        Name: this.box.name,
        Description: this.box.description,
        Stock: this.box.stock
      })

    })
  }

  //Indicación de espacios no rellendos
  checkError(control: string, error: string) {
    if (this.form.get(control)?.hasError(error) && this.form.get(control)?.touched) {
      return true
    } else {
      return false
    }
  }

  async onSubmit(){
    this.updatedBox = this.form.value;

    //Envio de datos al back
    this.boxesService.update( this.id, this.updatedBox);
    alert("La caja se ha modificado correctamente");
    //Redirección a box-detail
    await this.router.navigate(['/boxes', this.id]);
  }
}


