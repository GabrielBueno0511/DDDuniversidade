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
    public class AtletaRepositorySqlServer : IAtletaRepository
    {
        private readonly SqlContext _context;

        public AtletaRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteAtleta(Atleta atleta)
        {
            try
            {
                _context.Set<Atleta>().Remove(atleta);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Atleta GetAtletaById(int id)
        {
            return _context.Atletas.Find(id);
        }

        public List<Atleta> GetAtletas()
        {
            //return  _context.Atletas.Include(x => x.Disciplinas).ToList();
            return _context.Atletas.ToList();

        }

        public void InsertAtleta(Atleta atleta)
        {
            try
            {
                _context.Atletas.Add(atleta);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateAtleta(Atleta atleta)
        {
            try
            {
                _context.Entry(atleta).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

