export interface EmpresaModel {
    id: number;
    nome: string;
    razaoSocial: string;
    cnpj: string;
    dtCadastro: Date;
    colaboradores: any[];
}
