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

@Component({
  selector: "app-empresa",
  templateUrl: "./empresa.component.html",
  styleUrls: ["./empresa.component.css"]
})
export class EmpresaComponent implements OnInit {
  empresas: EmpresaModel[] = <EmpresaModel[]>[];
  empresaForm: FormGroup;

  constructor(private _http: CustomHttpService, private _fb: FormBuilder) {}

  ngOnInit() {
    this.obterEmpresas();
    this.formsInit();
  }

  obterEmpresas() {
    this._http.get("empresa").subscribe(res => {
      this.empresas = res.json();
    });
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

    this._http.post("empresa", value).subscribe(res => {
      console.log(res);
      if (res.status == 200) {
        this.obterEmpresas();
      } else {
        alert('blaa');
      }
    });
  }
}
