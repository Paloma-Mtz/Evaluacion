import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators   } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Juguete } from 'src/app/modelos/juguete';
import { JugueteService } from 'src/app/servicios/juguete.service';
 

@Component({
  selector: 'app-agrega-juguete',
  templateUrl: './agrega-juguete.component.html',
  styleUrls: ['./agrega-juguete.component.css']
})
export class AgregaJugueteComponent implements OnInit,OnDestroy {

  registro :FormGroup;
  subs: Subscription;
  juguete: Juguete;
  idJuguete = 0;

 constructor  (private formBuilder : FormBuilder, private jugueteServicio: JugueteService,
  private toastr: ToastrService ){

  this.registro = this.formBuilder.group({
    id:0,
    nombre: ['',[ Validators.required, Validators.maxLength(50)]],
    descripcion: ['', [Validators.maxLength(100)]],
    restriccionEdad :  [null, [Validators.min(0), Validators.max(100)]],
    precio:  [null, [Validators.required, Validators.min(1), Validators.max(1000)]],
    compania: ['', [Validators.required, Validators.maxLength(50)]],
  });
 }

  ngOnInit(): void {
   
    this.jugueteServicio.obtenerInformacionJuguete().subscribe(data=> {
      console.log(data);
      this.juguete = data;
      this.registro.patchValue({
        id: this.juguete.id,
        nombre: this.juguete.nombre,
        decipcion: this.juguete.descripcion,
        precio: this.juguete.precio,
        restriccionEdad: this.juguete.restriccionEdad,
        compania: this.juguete.compania,
      });
      this.idJuguete= this.juguete.id;
    })
  }

  ngOnDestroy(){
    this.subs.unsubscribe();
  }

  guardarDatos(){
    console.log(this.idJuguete);
    if(this.idJuguete === 0 || this.idJuguete === undefined){
      
    console.log('agregar');
      this.agregaDatos();
    }else 
    {
      this.actualizarDatos();
    }
  }

  agregaDatos(){
    const juguete : Juguete = {
      id:0,
      nombre : this.registro.get("nombre")?.value,
      descripcion : this.registro.get("descripcion")?.value,
      restriccionEdad : this.registro.get("restriccionEdad")?.value,
      precio : this.registro.get("precio")?.value,
      compania : this.registro.get("compania")?.value,
    }
    this.jugueteServicio.guardarInformacion(juguete).subscribe(data => {
      this.toastr.success("", "Registro agregado");
      this.jugueteServicio.obtenerInformacion();
      this.registro.reset();
    });
  }


  actualizarDatos(){
    const jugueteActualizar : Juguete = {
      id:this.juguete.id,
      nombre : this.registro.get("nombre")?.value,
      descripcion : this.registro.get("descripcion")?.value,
      restriccionEdad : this.registro.get("restriccionEdad")?.value,
      precio : this.registro.get("precio")?.value,
      compania : this.registro.get("compania")?.value,
    }
    this.jugueteServicio.actualizarJuguete(this.juguete.id,jugueteActualizar).subscribe(data => {
      this.toastr.info("", "Registro actualizado");
      this.jugueteServicio.obtenerInformacion();
      this.registro.reset();
      this.idJuguete=0;
    });
  }
}
