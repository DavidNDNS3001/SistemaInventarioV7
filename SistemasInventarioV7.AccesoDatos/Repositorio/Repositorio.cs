using Microsoft.EntityFrameworkCore;
using SistemasInventarioV7.AccesoDatos.Data;
using SistemasInventarioV7.AccesoDatos.Repositorio.IRepositorio;
using SistemasInventarioV7.Modelos.Especificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemasInventarioV7.AccesoDatos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            this.dbset= _db.Set<T>();
        }

        public async Task Agregar(T entidad)
        {
            await dbset.AddAsync(entidad);  //insert into  Table

           // throw new NotImplementedException();
        }

        public async Task<T> Obtener(int id)
        {
            return await dbset.FindAsync(id);       //Select * from Tabla (solo por id)
            //throw new NotImplementedException();
        }

        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>> filtro = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbset;
            if (filtro != null)
            {
                query = query.Where(filtro);    //select * from table where ... (varios)
            }
            if (incluirPropiedades != null)
            {
                foreach (var incluirPro in incluirPropiedades.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirPro);      //Ejemplo "Categoria, Marca"
                }
            }           
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();
           
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>> filtro = null,Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbset;
            if (filtro != null)
            {
                query = query.Where(filtro);    //select * from table where ... (varios)
            }
            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);    //  ejemplo "Categoria,Marca"
                }
            }            
            if(orderBy != null)
            {
                query = orderBy(query); 
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();   
            }
            return await query.ToListAsync();       
            //throw new NotImplementedException();
        }


        public PagedList<T> ObtenerTodosPaginados(Parametros parametros, Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbset;
            if (filtro != null)
            {
                query = query.Where(filtro);    //select * from table where ... (varios)
            }
            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);    //  ejemplo "Categoria,Marca"
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return PagedList<T>.ToPagedList(query, parametros.PageNumber, parametros.PageSize);
        }

        public void Remover(T entidad)
        {
            dbset.Remove(entidad);  
            //throw new NotImplementedException();
        }

        public void RemoverRango(IEnumerable<T> entidad)
        {
            dbset.RemoveRange(entidad); 
            //throw new NotImplementedException();
        }
    }
}
