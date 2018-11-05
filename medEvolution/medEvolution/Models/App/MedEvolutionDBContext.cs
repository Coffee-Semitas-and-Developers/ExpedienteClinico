using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;

namespace MedEvolution.Models.App
{
    public class MedEvolutionDbContext : DbContext
    {
        public MedEvolutionDbContext()
        {

        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<ConjuntoSignosVitales> ConjuntoSignosVitales { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Especialidad_Desempeniada> Especialidad_Desempeniada { get; set; }
        public DbSet<Horario_De_Atencion> Horario_De_Atencion { get; set; }
        public DbSet<Medico> Medico { get; set; }
        /*public DbSet<Medicamento> Medicamento { get; set; }
        public DbSet<Receta> Receta { get; set; }
        public DbSet<DetalleExamenes> DetalleExamenes { get; set; }
        public DbSet<Examen> Examen { get; set; }
        public DbSet<OrdenExamen> OrdenExamen { get; set; }
        public DbSet<Cita> Cita { get; set; }
        public DbSet<Consulta> Consulta { get; set; }*/



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /* modelBuilder.Entity<DetalleExamenes>()
                 .HasRequired(e => e.Examen).WithMany().HasForeignKey(e => e.Examen_CodigoExamen);

             modelBuilder.Entity<DetalleExamenes>()
                 .HasRequired(e => e.OrdenExamen).WithMany().HasForeignKey(e => e.OrdenExamen_IdOrden);*/

            modelBuilder.Entity<Medico>()
                .HasRequired(e => e.Especialidad_Desempeniada)
                .WithMany(e => e.Medicos)
                .HasForeignKey(e => e.CodigoEspecialidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medico>()
                .HasRequired(e => e.Horario_De_Atencion)
                .WithMany(e => e.Medicos)
                .HasForeignKey(e => e.CodigoHorario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                 .Map(e => { e.MapInheritedProperties(); e.ToTable("Empleado"); })
                 .HasKey(e => e.IdEmpleado);

            modelBuilder.Entity<Paciente>()
                .Map(e => { e.MapInheritedProperties(); e.ToTable("Paciente"); })
                .HasKey(e => e.IdPaciente);

            modelBuilder.Entity<Empleado>()
                .HasRequired(e => e.Clinica)
                .WithMany(e => e.Empleados)
                .HasForeignKey(e => e.IdClinica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                .HasRequired(e => e.Estado)
                .WithMany(e => e.Empleados)
                .HasForeignKey(e => e.CodigoEstado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .HasRequired(e => e.Estado)
                .WithMany(e => e.Pacientes)
                .HasForeignKey(e => e.CodigoEstado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .HasRequired(e => e.Departamento);

            modelBuilder.Entity<Direccion>()
               .HasRequired(e => e.Municipio)
               .WithMany(e => e.Direcciones)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clinica>()
               .HasRequired(e => e.Direccion);

        }

    }
}