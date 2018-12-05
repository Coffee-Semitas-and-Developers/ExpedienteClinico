using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace medEvolution.Models.App
{
    [Table("Departamento")]
    public class Departamento
    {
        public Departamento()
        {
        }

        public Departamento(int codigo, string nombre)
        {
            CodigoDepartamento = codigo;
            NombreDep = nombre;
        }

        [Key]
        [DisplayName("Código de Departamento")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoDepartamento { get; set; }

        [Required]
        [DisplayName("Nombre del Departamento")]
        [StringLength(30)]
        public string NombreDep { get; set; }

        public virtual ICollection<Municipio> Municipios { get; set; }

        public IEnumerable<SelectListItem> GetMunicipios(int cod)
        {
            if (cod!=0)
            {
                using (var context = new MedEvolutionDbContext())
                {
                    IEnumerable<SelectListItem> municipios = context.Municipio.AsNoTracking()
                        .OrderBy(n => n.CodigoDepartamento)
                        .Where(n => n.CodigoDepartamento == cod)
                        .Select(n =>
                           new SelectListItem
                           {
                               Value = n.CodigoMunicipio.ToString(),
                               Text = n.NombreMun
                           }).ToList();
                    return new SelectList(municipios, "Value", "Text");
                }
            }
            return null;
        }
    }

}
