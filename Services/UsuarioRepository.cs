using ProyectoDesarrollo.B.P.Models;

namespace ProyectoDesarrollo.B.P.Services
{
    public class UsuarioRepository : IUsuario
    {
        private List<Usuario> LstUsuarios = new List<Usuario>();
        public void Add(Usuario usuario)
        {
            LstUsuarios.Add(usuario);
        }

        public IEnumerable<Usuario> GellAllUser()
        {
            return LstUsuarios;
        }
    }
}
