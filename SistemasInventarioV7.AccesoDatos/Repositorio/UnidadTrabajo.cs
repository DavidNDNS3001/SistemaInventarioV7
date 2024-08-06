using SistemasInventarioV7.AccesoDatos.Data;
using SistemasInventarioV7.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasInventarioV7.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {

        private readonly ApplicationDbContext _db;
        public IBodegaRepositorio Bodega { get; private set; }
        public ICategoriaRepositorio Categoria { get; private set; }    

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Bodega = new BodegaRepositorio(_db);
            Categoria=new CategoriaRepositorio(_db);    
        }


        //public IBodegaRepositorio Bodega => throw new NotImplementedException();

        public void Dispose()
        {
            _db.Dispose();
            //throw new NotImplementedException();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync(); 
           // throw new NotImplementedException();
        }
    }
}
