import { Component, OnInit } from '@angular/core';
import { ColaboradorModel } from '../../interfaces/ColaboradorModel';
import { environment } from "../../../environments/environment";
import { CustomHttpService } from "../../services/custom-http.service";
import { EmpresaModel } from "../../interfaces/EmpresasModel";
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators
} from "@angular/forms";
import { NotificationService } from "../../services/notification.service";
import "rxjs/add/observable/throw";
import "rxjs/add/operator/catch";
import { PessoaModel } from '../../interfaces/PessoaModel';

@Component({
  selector: 'app-colaborador',
  templateUrl: './colaborador.component.html',
  styleUrls: ['./colaborador.component.css']
})
export class ColaboradorComponent implements OnInit {
  colaboradors: ColaboradorModel[] = <ColaboradorModel[]>[];
  empresas: EmpresaModel[] = <EmpresaModel[]>[];
  pessoas: PessoaModel[] = <PessoaModel[]>[];
  colaboradorForm: FormGroup;

  constructor(
    private _http: CustomHttpService,
    private _fb: FormBuilder,
    private _swal: NotificationService
  ) {}

  ngOnInit() {
    this.obterColaboradors();
    this.obterEmpresas();
    this.obterpessoas();
    this.formsInit();
  }

  obterColaboradors() {
    this._http.get("colaborador").subscribe(res => {
      this.colaboradors = res.json();
    });
  }

  obterEmpresas() {
    this._http.get("empresa").subscribe(res => {
      this.empresas = res.json();
    });
  }

  obterpessoas() {
    this._http.get("pessoa").subscribe(res => {
      this.pessoas = res.json();
    });
  }

  formsInit() {
    this.colaboradorForm = this._fb.group({
      pessoaId: ["", [<any>Validators.required]],
      empresaId: ["", [<any>Validators.required]],
      salario: ["", [<any>Validators.required]],
      cargo: ["", [<any>Validators.required]]
    });
  }

  adicionar(value: any, valid: boolean) {
    console.log(value);

    this._http.post("colaborador", value).subscribe(
      res => {
        this._swal.sucess("Sucesso!", "Colaborador adicionada com sucesso!");
        //swal.error("sucesso", "Foi");
        this.obterColaboradors();
      },
      err => this._swal.error("Erro", err.json().motivo),
      () => console.log("yay")
    );
  }

  demitir(value: ColaboradorModel){
    this._http.post("colaborador/demitir", value).subscribe(
      res => {
        this._swal.sucess("Sucesso!", "Colaborador demitido.");
        //swal.error("sucesso", "Foi");
        this.obterColaboradors();
      },
      err => this._swal.error("Erro", err.json().motivo),
      () => console.log("yay")
    );
  }

}
