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
@Component({
  selector: "app-pessoa",
  templateUrl: "./pessoa.component.html",
  styleUrls: ["./pessoa.component.css"]
})
export class PessoaComponent implements OnInit {
  pessoas: PessoaModel[] = <PessoaModel[]>[];
  pessoaForm: FormGroup;

  constructor(
    private _http: CustomHttpService,
    private _fb: FormBuilder,
    private _swal: NotificationService
  ) {}

  ngOnInit() {
    this.obterpessoas();
    this.formsInit();
  }

  obterpessoas() {
    this._http.get("pessoa").subscribe(res => {
      this.pessoas = res.json();
    });
  }

  formsInit() {
    this.pessoaForm = this._fb.group({
      nome: ["", [<any>Validators.required, <any>Validators.minLength(3)]],
      dtNascimento: [new Date(), [<any>Validators.required]],
      cpf: ["", [<any>Validators.required, <any>Validators.minLength(18)]]
    });
  }

  adicionar(value: any, valid: boolean) {
    console.log(value);

    this._http.post("pessoa", value).subscribe(
      res => {
        this._swal.sucess("Sucesso!", "Pessoa adicionada com sucesso!");
        //swal.error("sucesso", "Foi");
        this.obterpessoas();
      },
      err => this._swal.error("Erro", err.json().motivo),
      () => console.log("yay")
    );
  }

  remover(value: PessoaModel){
    this._http.delete("pessoa/" + value.id).subscribe(
      res => {
        this._swal.sucess("Sucesso!", "Pessoa removida com sucesso!");
        //swal.error("sucesso", "Foi");
        this.obterpessoas();
      },
      err => this._swal.error("Erro", err.json().motivo),
      () => console.log("yay")
    );
  }

}
