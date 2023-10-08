using DDD.Domain.Atletica;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class ContratoAtletaRepositorySqlServer : IContratoAtletaRepository
    {
        private readonly SqlContext _context;

        public ContratoAtletaRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }


        public void DeleteContratoAtleta(ContratoAtleta contratoAtleta)
        {
            try
            {
                _context.Set<ContratoAtleta>().Remove(contratoAtleta);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ContratoAtleta GetContratoAtletaById(int id)
        {
            return _context.ContratoAtletas.Find(id); ;
        }

        public List<ContratoAtleta> GetContratoAtleta()
        {
           return _context.ContratoAtletas.ToList();
        }

        public ContratoAtleta InsertContratoAtleta(int idAtleta, int idEsporte)
        {
            var atleta = _context.Atletas.First(i => i.UserId == idAtleta);
            var esporte = _context.Esportes.First(i => i.EsporteId == idEsporte);

            var ContratoAtleta = new ContratoAtleta
            {
                Atleta = atleta,
                Esporte = esporte
            };

            try
            {

                _context.Add(ContratoAtleta);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return ContratoAtleta;
        }

        public void UpdateContratoAtleta(ContratoAtleta contratoAtleta)
        {
            try
            {
                _context.Entry(contratoAtleta).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
