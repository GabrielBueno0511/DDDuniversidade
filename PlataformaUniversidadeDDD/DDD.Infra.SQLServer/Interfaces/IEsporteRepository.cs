using DDD.Domain.Atletica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IEsporteRepository
    {
        public List<Esporte> GetEsportes();
        public Esporte GetEsporteById(int id);
        public void InsertEsporte(Esporte esporte);
        public void UpdateEsporte(Esporte esporte);
        public void DeleteEsporte(Esporte esporte);
    }
}
