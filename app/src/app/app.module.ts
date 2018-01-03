import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { EmpresaComponent } from "./pages/empresa/empresa.component";
import { NavbarComponent } from "./navbar/navbar.component";
import { Routes, RouterModule } from "@angular/router";
import { PessoaComponent } from "./pages/pessoa/pessoa.component";
import { ColaboradorComponent } from "./pages/colaborador/colaborador.component";
import {
  XHRBackend,
  RequestOptions,
  Http,
  HttpModule,
  RequestOptionsArgs
} from "@angular/http";
import { ApiXHRBackendService } from "./services/api-xhrbackend.service";
import { CustomHttpService } from "./services/custom-http.service";

const appRoutes: Routes = [
  { path: "empresa", component: EmpresaComponent },
  { path: "pessoa", component: PessoaComponent },
  { path: "colaborador", component: ColaboradorComponent },
  {
    path: "**",
    redirectTo: "colaborador",
    pathMatch: "full"
  }
  // { path: '**', component: PageNotFoundComponent }
];

export function CustomHttpServiceFactory(
  backend: XHRBackend,
  options: RequestOptions
) {
  return new CustomHttpService(backend, options);
}

@NgModule({
  declarations: [
    AppComponent,
    EmpresaComponent,
    NavbarComponent,
    PessoaComponent,
    ColaboradorComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: false } // <-- debugging purposes only
    )
  ],
  providers: [
    ApiXHRBackendService,
    CustomHttpService,
    { provide: XHRBackend, useClass: ApiXHRBackendService },
    {
      provide: CustomHttpService,
      useFactory: CustomHttpServiceFactory,
      deps: [ApiXHRBackendService, RequestOptions]
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
