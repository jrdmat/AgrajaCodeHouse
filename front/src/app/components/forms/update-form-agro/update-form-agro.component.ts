import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Agro, UptadatedAgro } from 'src/app/interfaces/agro.interface';
import { AgrosService } from 'src/app/services/agros.service';

@Component({
  selector: 'app-update-form-agro',
  templateUrl: './update-form-agro.component.html',
  styleUrls: ['./update-form-agro.component.css']
})
export class UpdateFormAgroComponent {

  form! : FormGroup;
  updatedAgro! : UptadatedAgro;
  id! : number;
  agro!: Agro;

  constructor(
    private agrosService: AgrosService,
    private activatedRoute: ActivatedRoute,
    private router: Router){}

  ngOnInit(){

    this.form = new FormGroup({
      Name: new FormControl('', Validators.required),
      Description: new FormControl('', Validators.required),
    })
    
    this.activatedRoute.params.subscribe(async(params : any) =>{
      //Obtención del id del agro por ruta
      const id = parseInt(params.idagro);
  
      this.id = id;
      
      this.agro = await this.agrosService.getById(this.id);

      //Actualización de los valores iniciales del form.
      this.form.patchValue({
        Name: this.agro.name,
        Description: this.agro.description,
      })

    })
  }

  //Indicación de espacios no rellenados
  checkError(control: string, error: string) {
    if (this.form.get(control)?.hasError(error) && this.form.get(control)?.touched) {
      return true
    } else {
      return false
    }
  }

  async onSubmit(){
    this.updatedAgro = this.form.value;

    //Envio de datos al back
    this.agrosService.update( this.id, this.updatedAgro);
    alert("El agro se ha modificado correctamente");
    //Redirección a box-detail
    await this.router.navigate(['/agros', this.id]);
  }



}
