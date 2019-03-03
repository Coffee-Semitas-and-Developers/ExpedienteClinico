using medEvolution.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace medEvolution.Services
{
    interface IMunicipioService
    {
        IEnumerable<Municipio> GetMunicipios();
        Municipio GetById(int cod);
        IEnumerable<SelectListItem> GetMunicipiosEmpty();
        IEnumerable<SelectListItem> GetMunicipiosByDepart(int cod);
    }
}
