using System;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly Expression<Func<Usuario, object>>[] include = { c => c.Pessoa };

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
            var account = await FindUser(usuario, new PaginacaoParametroDto());

            if (account == null || !BC.Verify(usuario.Senha, account.Senha))
            {
                return null;
            }

            return account;
        }

        public async Task<Usuario> FindUser(Usuario usuario, PaginacaoParametroDto paginacaoParametroDto)
        {
            var cliente = await GetByExpression(paginacaoParametroDto, c => c.Pessoa.Email == usuario.Pessoa.Email, null, include);
            return cliente.FirstOrDefault();
        }

        public async Task<Usuario> FindById(int id)
        {
            return await _repository.GetById(id, include);
        }
    }
}
