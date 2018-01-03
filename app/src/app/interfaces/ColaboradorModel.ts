import { EmpresaModel } from "./EmpresasModel";
import { PessoaModel } from "./PessoaModel";

export interface ColaboradorModel {
    empresaId: number;
    pessoaId: number;
    salario: number;
    status: number;
    dtCadastro: Date;
    dtDemissao?: any;
    cargo: string;
    pessoa: PessoaModel;
    empresa: EmpresaModel;
}