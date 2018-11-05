﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models.App
{
    [Table("Empleado")]
    public class Empleado : Persona
    {
        public Empleado()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Description("Identificador de empleado:")]
        public int IdEmpleado { get; set; }

        [Required]
        [StringLength(30)]
        [Description("Cargo:")]
        public string Cargo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Description("Fecha de Contratación:")]
        public DateTime FechaContratacion { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Description("Fecha de despido:")]
        public DateTime? FechaDespido { get; set; }

        [Required]
        [Description("Salario:")]
        public double Salario { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public string HorasLaborales { get; set; }

        [Required]
        [Column("Clinica_IdClinica")]
        [DisplayName("Clinica: ")]
        public int IdClinica { get; set; }
        public virtual Clinica Clinica { get; set; }

        [Required]
        [Column("Estado_CodigoEstado")]
        [DisplayName("Estado: ")]
        public int CodigoEstado { get; set; }
        public virtual Estado Estado { get; set; }

        //public virtual ICollection<Medico> Medicos { get; set; }

    }
}