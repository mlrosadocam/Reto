using WebApplication2.Data;
using WebApplication2.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Repositories
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbContextClass _dbContext;

        public UsuarioService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Usuario>> GetUsuarioListAsync()
        {
            return await _dbContext.Usuario
                .FromSqlRaw<Usuario>("usp_select_user")
                .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetUsuarioByIdAsync(int UsuarioId)
        {
            var param = new SqlParameter("@UsuarioId", UsuarioId);

            var usuarioDetails = await Task.Run(() => _dbContext.Usuario
                            .FromSqlRaw(@"exec usp_get_user @UsuarioId", param).ToListAsync());

            return usuarioDetails;
        }

        public async Task<int> AddUsuarioAsync(Usuario usuario)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Nombres", usuario.Nombres));
            parameter.Add(new SqlParameter("@Apellidos", usuario.Apellidos));
            parameter.Add(new SqlParameter("@Edad", usuario.Edad));
            parameter.Add(new SqlParameter("@Telefono", usuario.Telefono));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec usp_insert_user @Nombres, @Apellidos, @Edad, @Telefono", parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateUsuarioAsync(Usuario usuario)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@UsuarioId", usuario.UsuarioId));
            parameter.Add(new SqlParameter("@Nombres", usuario.Nombres));
            parameter.Add(new SqlParameter("@Apellidos", usuario.Apellidos));
            parameter.Add(new SqlParameter("@Edad", usuario.Edad));
            parameter.Add(new SqlParameter("@Telefono", usuario.Telefono));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec usp_update_user @UsuarioId, @Nombres, @Apellidos, @Edad, @Telefono", parameter.ToArray()));
            return result;
        }
        public async Task<int> DeleteUsuarioAsync(int UsuarioId)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"usp_delete_user {UsuarioId}"));
        }
    }
}