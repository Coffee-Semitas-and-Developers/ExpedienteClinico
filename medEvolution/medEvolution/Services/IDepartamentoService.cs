﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    interface IDepartamentoService
    {
        IEnumerable<Departamento> GetDepartamentos();   
    }
}
