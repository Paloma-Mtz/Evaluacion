import { Component, OnInit } from '@angular/core';
import { JugueteService } from 'src/app/servicios/juguete.service';
import { ToastrService } from 'ngx-toastr';
import { Juguete } from 'src/app/modelos/juguete';
@Component({
  selector: 'app-mostrar-juguetes',
  templateUrl: './mostrar-juguetes.component.html',
  styleUrls: ['./mostrar-juguetes.component.css']
})
export class MostrarJuguetesComponent implements OnInit {

  constructor(public jugueteServicio: JugueteService,  private toastr: ToastrService) { }

  ngOnInit(): void {
    this.jugueteServicio.obtenerInformacion();
  }

  eliminarDato(id: number){
   var dato= confirm("Desea eliminar el elemento");
 
    
    if(dato)
    {
      this.jugueteServicio.eliminar(id).subscribe(data => {
        this.toastr.warning('', 'Registro eliminado');
        this.jugueteServicio.obtenerInformacion();
      });
    }                   
    this.jugueteServicio.obtenerInformacion();
  }

  editarInformacion(juguete: Juguete){
    this.jugueteServicio.actualizar(juguete);
  }
}
