using DDD.Domain.Atletica;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class CampeonatoRepositorySqlServer : ICampeonatoRepository
    {
        private readonly SqlContext _context;

        public CampeonatoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteCampeonato(Campeonato campeonato)
        {
            try
            {
                _context.Set<Campeonato>().Remove(campeonato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Campeonato GetCampeonatoById(int id)
        {
            return _context.Campeonatos.Find(id);
        }

        public List<Campeonato> GetCampeonatos()
        {
            //return  _context.Campeonatos.Include(x => x.Disciplinas).ToList();
            return _context.Campeonatos.ToList();

        }

        public void InsertCampeonato(Campeonato campeonato)
        {
            try
            {
                _context.Campeonatos.Add(campeonato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateCampeonato(Campeonato campeonato)
        {
            try
            {
                _context.Entry(campeonato).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
