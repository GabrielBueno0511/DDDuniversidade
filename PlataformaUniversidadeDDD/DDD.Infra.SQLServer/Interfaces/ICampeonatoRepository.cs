using DDD.Domain.Atletica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface ICampeonatoRepository
    {
        public List<Campeonato> GetCampeonatos();
        public Campeonato GetCampeonatoById(int id);
        public void InsertCampeonato(Campeonato campeonato);
        public void UpdateCampeonato(Campeonato campeonato);
        public void DeleteCampeonato(Campeonato campeonato);

    }
}
