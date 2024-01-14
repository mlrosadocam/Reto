using WebApplication2.Entities;

namespace WebApplication2.Repositories
{
    public interface IUsuarioService
    {
        public Task<List<Usuario>> GetUsuarioListAsync();
        public Task<IEnumerable<Usuario>> GetUsuarioByIdAsync(int Id);
        public Task<int> AddUsuarioAsync(Usuario usuario);
        public Task<int> UpdateUsuarioAsync(Usuario usuario);
        public Task<int> DeleteUsuarioAsync(int Id);
    }
}