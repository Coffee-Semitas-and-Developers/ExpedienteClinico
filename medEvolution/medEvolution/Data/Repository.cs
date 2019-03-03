using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace medEvolution.Data
{
    public class Repository<T1> : IRepository<T1> where T1 : class
    {
        /// <summary>
        /// Implementacion y definicion de métodos genéricos para el CRUD de nuestra aplicación
        /// T1 puede ser cualquier Modelo o clase y T2 cualquier objeto que necesitemos
        /// https://www.c-sharpcorner.com/UploadFile/3d39b4/crud-operations-using-the-generic-repository-pattern-and-dep/
        /// https://www.c-sharpcorner.com/UploadFile/3d39b4/crud-using-the-repository-pattern-in-mvc/
        /// </summary>
        /// <param name="id"> dicho parámetro puede ser cualquier objecto inclusive un
        /// conjunto de ellos para aquellas entidades que posean Keys compuestas en la BD</param>

        private readonly UnitOfWork _unit;
        private IDbSet<T1> _entity;

        private IDbSet<T1> Entity
        {
            get
            {
                if (_entity == null)
                {
                    _entity = _unit._context.Set<T1>();
                }
                return _entity;
            }
        }

        public virtual IQueryable<T1> Table
        {
            get
            {
                return this.Entity;
            }
        }

        public Repository(UnitOfWork unit)
        {
            this._unit =unit;
        }

        public void Delete(object id)
        {
            try
            {
                T1 ent = this.Entity.Find(id);
                if (ent == null)
                {
                    throw new ArgumentNullException("Entity cannot be found");
                }
                this.Entity.Remove(ent);
                this._unit.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw Excepcion(dbEx);
            }
        }

        public void Delete(T1 ent)
        {
            try
            {
                if (ent == null)
                {
                    throw new ArgumentNullException("Entity cannot be found");
                }
                this.Entity.Remove(ent);
                this._unit.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw Excepcion(dbEx);
            }
        }

        public IEnumerable<T1> GetAll()
        {
            try
            {
               return this.Entity.ToList();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw Excepcion(dbEx);
            }

        }

        public T1 GetById(object id)
        {
            try
            {
                return this.Entity.Find(id);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw Excepcion(dbEx);
            }
        }

        public void Insert(T1 entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entity.Add(entity);
                this._unit.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {

                throw Excepcion(dbEx);
            }
        }

        public void Update(T1 entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                //this._unit._context.Entry(entity).State = EntityState.Modified;
                this._unit.SaveChanges(entity);
            }
            catch (DbEntityValidationException dbEx)
            {

                throw Excepcion(dbEx);
            }
        }

        public T1 GetById(string s1, string s2, string s3)
        {
            try
            {
                return this.Entity.Find(s1,s2,s3);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw Excepcion(dbEx);
            }
        }

        /// <summary>
        /// Devuelve las excepciones que puedan presentar en las Entities y que se obtienen en el Catch
        /// </summary>
        /// <param name="ex"> Proviene de Exception</param>
        /// <returns> La exception que se presentó</returns>
        private Exception Excepcion(DbEntityValidationException ex)
        {
            var msg = string.Empty;

            foreach (var validationErrors in ex.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                }
            }
            var fail = new Exception(msg, ex);
            return fail;
        }
    }
}