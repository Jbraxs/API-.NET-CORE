import { IQueens } from '@core/models/queens.interface';
import { Component, Inject, OnInit } from '@angular/core';
import { QueensService } from '@app/core/services/queensService.service';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {

  public allQueens: IQueens[] = [];

persona = {
  nombre: 'pepe',
  apellido: 'aaaa'
}


  constructor(private _service: QueensService) { }

  ngOnInit(): void {
    this.onGetAllQueens();
  }

  onGetAllQueens(){
    this._service.getAllQueens()
    .subscribe((data: IQueens[]) => {
      this.allQueens = data;
      console.log('allQueens', this.allQueens);
    }), (e : HttpErrorResponse) => {
      console.log('Error onGetAllQueens', e);
    }
  }
}

