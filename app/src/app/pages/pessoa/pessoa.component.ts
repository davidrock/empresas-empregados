import { Component, OnInit } from "@angular/core";
import { environment } from "../../../environments/environment";
import { CustomHttpService } from "../../services/custom-http.service";
import { PessoaModel } from "../../interfaces/PessoaModel";
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
@Component({
  selector: "app-pessoa",
  templateUrl: "./pessoa.component.html",
  styleUrls: ["./pessoa.component.css"]
})
export class PessoaComponent implements OnInit {
  pessoas: PessoaModel[] = <PessoaModel[]>[];
  pessoaForm: FormGroup;
  public mask = [
    /[1-9]/,
    /\d/,
    /\d/,
    ".",
    /\d/,
    /\d/,
    /\d/,
    ".",
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
    this.obterpessoas();
    this.formsInit();
  }

  obterpessoas() {
    this._spiner.display(true);
    this._http.get("pessoa").subscribe(
      res => {
        this.pessoas = res.json();
      },
      err => {
        this._swal.error("Erro", err.json().motivo);
        this._spiner.display(false);
      },
      () => this._spiner.display(false)
    );
  }

  formsInit() {
    this.pessoaForm = this._fb.group({
      nome: ["", [<any>Validators.required, <any>Validators.minLength(3)]],
      dtNascimento: [new Date(), [<any>Validators.required]],
      cpf: ["", [<any>Validators.required, <any>Validators.minLength(14)]]
    });
  }

  isValidForm(valid) {
    return valid;
  }

  adicionar(value: any, valid: boolean) {
    console.log(valid);

    this._spiner.display(true);
    this._http.post("pessoa", value).subscribe(
      res => {
        this._swal.sucess("Sucesso!", "Pessoa adicionada com sucesso!");
        //swal.error("sucesso", "Foi");
        this.obterpessoas();
      },
      err => {
        this._swal.error("Erro", err.json().motivo);
        this._spiner.display(false);
      },
      () => this._spiner.display(false)
    );
  }

  remover(value: PessoaModel) {
    this._spiner.display(true);
    this._http.delete("pessoa/" + value.id).subscribe(
      res => {
        this._swal.sucess("Sucesso!", "Pessoa removida com sucesso!");
        //swal.error("sucesso", "Foi");
        this.obterpessoas();
      },
      err => {
        this._swal.error("Erro", err.json().motivo);
        this._spiner.display(false);
      },
      () => this._spiner.display(false)
    );
  }
}
