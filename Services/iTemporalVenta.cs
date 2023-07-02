using ProyectoDesarrollo.B.P.Models;

namespace ProyectoDesarrollo.B.P.Services
{
    public interface iTemporalVenta
    {
        void agregar(TemporalVenta temporalVenta);
        IEnumerable<TemporalVenta> ListarTemporalVenta();

        int  ObtenerProductoPorCodigo(string codigo);
        void AumentarCantidadProducto(string codigo, int cantidad);

        int ObtenerIndexPorCodigo(string codigo);
        void remove(string codigo);
        TemporalVenta edit(string id); //Modificar 1
        void editDetails(TemporalVenta obj); //Modificar 2

    }
}
