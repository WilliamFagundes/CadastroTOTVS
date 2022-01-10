using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository, INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<bool> Adicionar(Usuario usuario)
        {
            if(_usuarioRepository.BuscarUsuario(u => u.Email == usuario.Email).Result.Any())
            {
                Notificar("E-mail já cadastrado.");
                return false;
            }

            await _usuarioRepository.Adicionar(usuario);
            return true;
        }

        public async Task<bool> Atualizar(Usuario usuario)
        {
            if (_usuarioRepository.BuscarUsuario(u => u.Email == usuario.Email).Result.Any())
            {
                Notificar("E-mail já cadastrado.");
                return false;
            }

            await _usuarioRepository.Atualizar(usuario);
            return true;
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

        public async Task<List<Usuario>> Listar()
        {
            return await _usuarioRepository.ObterUsuarios();
        }

        public async Task<bool> Remover(Guid id)
        {

            await _usuarioRepository.Remover(id);
            return true;
            
        }
    }
}
