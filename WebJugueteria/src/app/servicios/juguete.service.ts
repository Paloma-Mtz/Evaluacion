import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Juguete } from '../modelos/juguete';

@Injectable({
  providedIn: 'root'
})
export class JugueteService {
  apiUrl ="https://localhost:44396/api/Jugueteria/"; 
  listaJuguetes : Juguete[];

  private formularioActualizar = new BehaviorSubject<Juguete>({} as any)

  constructor(private http: HttpClient) { }
    
 
    guardarInformacion(juguete: Juguete): Observable<Juguete>
    {
      return this.http.post<Juguete>(this.apiUrl ,juguete);
    }
 
    obtenerInformacion()
    {
        this.http.get(this.apiUrl ).toPromise().then(data =>{
        this.listaJuguetes = data as Juguete[];
      })
    }

    eliminar(id: number): Observable<Juguete>{
      return this.http.delete<Juguete>(this.apiUrl+id);
    }
    
    actualizar(juguete: Juguete)
    {
      this.formularioActualizar.next(juguete);
    }

    obtenerInformacionJuguete(): Observable<Juguete>{
      return this.formularioActualizar.asObservable();
    }

    actualizarJuguete(id: number, juguete: Juguete): Observable<Juguete>{
      return this.http.put<Juguete>(this.apiUrl + id, juguete);
    }
  }