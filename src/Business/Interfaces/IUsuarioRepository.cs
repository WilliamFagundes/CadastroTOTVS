using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUsuarioRepository : IDisposable
    {
        Task Adicionar(Usuario usuario);
        Task<Usuario> ObterPorId(Guid id);
        Task<List<Usuario>> ObterUsuarios();
        Task Atualizar(Usuario usuario);
        Task Remover(Guid id);
        Task<IEnumerable<Usuario>> BuscarUsuario(Expression<Func<Usuario, bool>> predicate);
        Task<int> SaveChanges();
    }
}
