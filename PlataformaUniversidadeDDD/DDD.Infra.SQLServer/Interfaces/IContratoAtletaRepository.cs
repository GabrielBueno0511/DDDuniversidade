using DDD.Domain.Atletica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IContratoAtletaRepository
    {
        public List<ContratoAtleta> GetContratoAtleta();
        public ContratoAtleta GetContratoAtletaById(int id);
        public ContratoAtleta InsertContratoAtleta(int idAtleta, int idEsporte);
        public void UpdateContratoAtleta(ContratoAtleta contratoAtleta);
        public void DeleteContratoAtleta(ContratoAtleta contratoAtleta);
    }
}
