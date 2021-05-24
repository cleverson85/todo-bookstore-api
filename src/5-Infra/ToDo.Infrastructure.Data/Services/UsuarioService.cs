using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;
using BC = BCrypt.Net.BCrypt;

namespace ToDo.Infrastructure.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository; 
        }

        public async Task<Usuario> Register(Usuario usuario)
        {
            string hashPassWord = BC.HashPassword(usuario.Senha);
            usuario.Senha = hashPassWord;

            return await _usuarioRepository.Save(usuario);
        }

        public async Task<Usuario> Authenticate(Usuario usuario)
        {
            var account = await FindUser(usuario);

            if (account == null || !BC.Verify(usuario.Senha, account.Senha))
            {
                return null;
            }

            return account;
        }

        public async Task<Usuario> FindUser(Usuario usuario)
        {
            var user = await _usuarioRepository.FindUser(usuario);
            return user;
        }

        public async Task<Usuario> FindById(int id)
        {
            return await _usuarioRepository.GetById(id);
        }

        public override Task<IList<Usuario>> FindByDescription(string description, PaginacaoParametroDto paginacaoParametro)
        {
            throw new NotImplementedException();
        }
    }
}
