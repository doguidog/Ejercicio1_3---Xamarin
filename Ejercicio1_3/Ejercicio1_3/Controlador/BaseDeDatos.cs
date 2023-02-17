using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Ejercicio1_3.Modelo;
using System.Threading.Tasks;

namespace Ejercicio1_3.Controlador
{
    public class BaseDeDatos
    {

        readonly SQLiteAsyncConnection dbase;

        public BaseDeDatos(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);
            dbase.CreateTableAsync<Modelo.Gente>();
        }

        #region OperacionesGente

        //Creacion del CRUD
        public Task<int> GuardarGente(Gente gente)
        {
            if(gente.id != 0)
            {
                return dbase.UpdateAsync(gente);
            }
            else
            {
                return dbase.InsertAsync(gente);
            }
        }

        //Leer la lista de los registros creados en la bd
        public Task<List<Gente>> getListGente()
        {
            return dbase.Table<Gente>().ToListAsync();
        }

        //Lectura del registro por el ID
        public Task<Gente> getGente(int pid)
        {
            return dbase.Table<Gente>().Where(i => i.id == pid).FirstOrDefaultAsync();
        }

        //Borrar el registro
        public Task<int> DeleteGente(Gente gente)
        {
            return dbase.DeleteAsync(gente);
        }

        #endregion OperacionesGente

    }
}
