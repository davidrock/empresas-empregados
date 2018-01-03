export interface PessoaModel {
    id: number;
    nome: string;
    cpf: string;
    dtNascimento: Date;
    dtCadastro: Date;
    colaboradores: any[];
}
