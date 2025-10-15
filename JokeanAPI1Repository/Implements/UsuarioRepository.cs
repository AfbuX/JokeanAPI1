using Dapper.Contrib.Extensions;
using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using System.Data;

namespace JokeanAPI1Repository.Implements
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _db;

        public UsuarioRepository(IDbConnection db)
        {

            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Usuario> Add(Usuario usuario)
        {
            try
            {

                usuario.id = await _db.InsertAsync(usuario);
                return usuario;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            try
            {
                var rs = await _db.UpdateAsync<Usuario>(usuario);
                return usuario;
            }
            catch (Exception){ 
            
            throw; }
        }
    }
}
