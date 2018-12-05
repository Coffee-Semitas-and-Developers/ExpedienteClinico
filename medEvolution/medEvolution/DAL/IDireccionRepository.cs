using medEvolution.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace medEvolution.DAL
{
    public interface IDireccionRepository: IDisposable
    {
        IEnumerable<Direccion> GetDirecciones();
        Direccion GetDireccionByID(string IdColonia, string IdPasaje, string IdCasa);
        void InsertDireccion(Direccion direccion);
        void DeleteDireccion(string IdColonia, string IdPasaje, string IdCasa);
        void UpdateDireccion(Direccion direccion);
        void Save();
    }
}