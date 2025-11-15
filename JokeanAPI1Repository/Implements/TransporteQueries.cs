using JokeanAPI1Models;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JokeanAPI1Repository.Interfaces;
using JokeanAPI1Repository.ModelsVM;
using TransporteVM = JokeanAPI1Models.TransporteVM;

namespace JokeanAPI1Repository.Implements
{
    public class TransporteQueries : ITransporteQueries
    {
        private readonly IDbConnection _db;

        public TransporteQueries(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<IEnumerable<TransporteVM>> GetAll()
        {
            try
            {
                string sql = @"
            SELECT 
                tt.Id AS TipoTransporteId,
                tt.Tipo AS TipoNombre,
                tt.Descripcion AS TipoDescripcion,

                t.Id AS TransporteId,
                t.Placa,
                t.Marca,
                t.Modelo,
                t.Capacidad
            FROM Transporte t
            INNER JOIN TipoTransporte tt ON t.TipoTransporteId = tt.Id
            ORDER BY t.Id DESC;
        ";

                var result = await _db.QueryAsync<TransporteVM>(sql);
                return result;
            }
            catch
            {
                throw;
            }
        }



        public async Task<IEnumerable<TransporteVM>> byVM(int id)
        {
            try
            {
                string sql = @"
            SELECT 
                t.Id AS TransporteId,
                t.Placa,
                t.Marca,
                t.Modelo,
                t.Capacidad,
                t.TipoMotor,
                t.Cilindraje,

                tt.Tipo AS TipoNombre,

                u.Id AS UsuarioId,
                u.Nombre AS UsuarioNombre,
                u.Email AS UsuarioEmail

            FROM Transporte t
            INNER JOIN TipoTransporte tt ON t.TipoTransporteId = tt.Id
            INNER JOIN Usuario u ON t.UsuarioId = u.Id
            WHERE t.Id = @Id;
        ";

                var result = await _db.QueryAsync<TransporteVM>(sql, new { Id = id });

                return result;
            }
            catch
            {
                throw;
            }
        }


    }

}        


