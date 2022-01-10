using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<Usuario> DbSet;

        public UsuarioRepository(AppDbContext db)
        {
            Db = db;
            DbSet = db.Set<Usuario>();
        }
        public async Task Adicionar(Usuario usuario)
        {
            DbSet.Add(usuario);
            await SaveChanges();
        }

        public async Task Atualizar(Usuario usuario)
        {
            DbSet.Update(usuario);
            await SaveChanges();
        }

        public async Task<IEnumerable<Usuario>> BuscarUsuario(Expression<Func<Usuario, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
       
        public async Task Remover(Guid id)
        {
            DbSet.Remove(new Usuario { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}
