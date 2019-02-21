using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medEvolution.Data
{
    public interface IRepository<T1, T2> where T1 : class
    {
        /// <summary>
        /// Hemos comenzado a implementar el Patrón Repositorio Genérico
        /// y aquí creamos una interfaz Genérica que será implementada 
        /// en una clase concreta. Son los servicios necesarios de un CRUD
        /// https://www.c-sharpcorner.com/article/generic-repository-pattern-with-mvc/
        /// </summary>
        /// T1 puede ser cualquier clase que se implemente y T2 puede ser cualquier Object
        /// <returns></returns>

        IEnumerable<T1> GetAll();
        T1 GetById(object id);
        void Insert(T1 entity);
        void Update(T1 entity);
        void Delete(object id);
    }
}
