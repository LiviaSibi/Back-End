using Senai.Peoples.Webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.Webapi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();

        void Cadastrar(FuncionarioDomain funcionario);

        FuncionarioDomain GetById(int id);

        void AtualizarUrl(int id, FuncionarioDomain funcionario);

        void Deletar(int id);

        List<FuncionarioDomain> GetByNameUrl(string nome);

        List<FuncionarioDomain> NomesCompletos();
    }
}
