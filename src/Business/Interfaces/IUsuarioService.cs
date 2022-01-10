using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        Task<bool> Adicionar(Usuario usuario);
        Task<bool> Atualizar(Usuario usuario);
        Task<bool> Remover(Guid id);
        Task<List<Usuario>> Listar();
    }
}
