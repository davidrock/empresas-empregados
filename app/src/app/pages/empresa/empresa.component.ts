import { Component, OnInit } from "@angular/core";
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
import { SpinerService } from "../../services/spiner.service";
//declare var swal: any;
@Component({
  selector: "app-empresa",
  templateUrl: "./empresa.component.html",
  styleUrls: ["./empresa.component.css"]
})
export class EmpresaComponent implements OnInit {
  empresas: EmpresaModel[] = <EmpresaModel[]>[];
  empresaForm: FormGroup;
  public mask = [
    /[1-9]/,
    /\d/,
    ".",
    /\d/,
    /\d/,
    /\d/,
    ".",
    /\d/,
    /\d/,
    /\d/,
    "/",
    /\d/,
    /\d/,
    /\d/,
    /\d/,
    "-",
    /\d/,
    /\d/
  ];

  constructor(
    private _http: CustomHttpService,
    private _fb: FormBuilder,
    private _swal: NotificationService,
    private _spiner: SpinerService
  ) {}

  ngOnInit() {
    this.obterEmpresas();
    this.formsInit();
  }

  obterEmpresas() {
    this._spiner.display(true);
    this._http.get("empresa").subscribe(
      res => {
        this.empresas = res.json();
      },
      err => {
        this._swal.error("Erro", err.json().motivo);
        this._spiner.display(false);
      },
      () => this._spiner.display(false)
    );
  }

  formsInit() {
    this.empresaForm = this._fb.group({
      nome: ["", [<any>Validators.required, <any>Validators.minLength(3)]],
      razaoSocial: ["", [<any>Validators.required]],
      cnpj: ["", [<any>Validators.required, <any>Validators.minLength(18)]]
    });
  }

  adicionar(value: any, valid: boolean) {
    console.log(value);
    this._spiner.display(true);
    this._http.post("empresa", value).subscribe(
      res => {
        this._swal.sucess("Sucesso!", "Empresa adicionada com sucesso!");
        //swal.error("sucesso", "Foi");
        this.obterEmpresas();
      },
      err => {
        this._swal.error("Erro", err.json().motivo);
        this._spiner.display(false);
      },
      () => this._spiner.display(false)
    );
  }

  remover(value: EmpresaModel) {
    this._spiner.display(true);
    this._http.delete("empresa/" + value.id).subscribe(
      res => {
        this._swal.sucess("Sucesso!", "Empresa removida com sucesso!");
        //swal.error("sucesso", "Foi");
        this.obterEmpresas();
      },
      err => {
        this._swal.error("Erro", err.json().motivo);
        this._spiner.display(false);
      },
      () => this._spiner.display(false)
    );
  }
}
