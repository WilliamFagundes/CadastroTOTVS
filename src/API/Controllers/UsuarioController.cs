using API.ViewModels;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {

        
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly UsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository usuarioRepository, 
            UsuarioService usuarioService,
            IMapper mapper)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> ListarUsuarios()
        {
            var usuario = _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObterUsuarios());

            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioViewModel>> Adicionar(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _usuarioService.Adicionar(_mapper.Map<Usuario>(usuarioViewModel));

            return Ok(usuarioViewModel);
            
        }
    }
}
