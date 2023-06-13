import { Component, OnInit } from '@angular/core';
import { TarjetaService } from 'src/app/services/tarjeta.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-list-tarjeta-credito',
  templateUrl: './list-tarjeta-credito.component.html',
  styleUrls: ['./list-tarjeta-credito.component.css']
})
export class ListTarjetaCreditoComponent implements OnInit {

  constructor(public tarjetaService: TarjetaService, 
              public toastr: ToastrService) { }

  ngOnInit(): void {
    this.tarjetaService.obtenerTarjetas();
  }

  eliminarTarjeta(id: number){
    if (confirm('Esta seguro que desea elimnar el registro?')) {
      this.tarjetaService.elimnarTarjeta(id).subscribe(data => {
        this.toastr.warning('Registro eliminado', 'La tarjeta fue eliminada');
        this.tarjetaService.obtenerTarjetas();
      });
    }
  }

  editar(tarjeta) {
    this.tarjetaService.actualizar(tarjeta);
  }

}
