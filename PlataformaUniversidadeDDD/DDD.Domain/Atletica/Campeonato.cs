using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Atletica
{
    public class Campeonato
    {
        public int CampeonatoId { get; set; }

        public string NomeCampeonato { get; set; }

        public  int EsporteId { get; set; }
    }
}
