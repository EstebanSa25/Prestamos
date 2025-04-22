using Models;

namespace PruebaServer.Data
{
    public class UserLogged
    {
        public UsuarioModel UsuarioActual { get; private set; }
        public void EstablecerUsuario(UsuarioModel usuario)
        {
            UsuarioActual = usuario;
        }

        public void LimpiarUsuario()
        {
            UsuarioActual = null;
        }

        public bool EstaLogueado => UsuarioActual != null;
    }
}
