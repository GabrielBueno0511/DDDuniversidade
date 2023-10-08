using DDD.Domain.Atletica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IAtletaRepository
    {
        public List<Atleta> GetAtletas();
        public Atleta GetAtletaById(int id);
        public void InsertAtleta(Atleta atleta);
        public void UpdateAtleta(Atleta atleta);
        public void DeleteAtleta(Atleta atleta);
    }
}
