import { Component, OnInit } from "@angular/core";
import { environment } from "../../../environments/environment";
import { CustomHttpService } from "../../services/custom-http.service";

@Component({
  selector: "app-empresa",
  templateUrl: "./empresa.component.html",
  styleUrls: ["./empresa.component.css"]
})
export class EmpresaComponent implements OnInit {
  constructor(private _http: CustomHttpService) {}

  ngOnInit() {
    this.obterEmpresas();
  }

  obterEmpresas() {
    this._http.get("empresa").subscribe(res => {
      console.log(res);
    });
  }
}
