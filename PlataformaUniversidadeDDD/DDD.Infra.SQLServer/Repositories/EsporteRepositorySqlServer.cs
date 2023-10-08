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
   
    public class EsporteRepositorySqlServer : IEsporteRepository
    {
        private readonly SqlContext _context;

        public EsporteRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }


        public void DeleteEsporte(Esporte esporte)
        {
            try
            {
                _context.Set<Esporte>().Remove(esporte);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Esporte> GetEsportes()
        {
            return _context.Esportes.ToList();
        }

        public Esporte GetEsporteById(int id)
        {
            return _context.Esportes.Find(id);
        }

        public void InsertEsporte(Esporte esporte)
        {
            try
            {
                _context.Esportes.Add(esporte);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateEsporte(Esporte esporte)
        {
            try
            {
                _context.Entry(esporte).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

