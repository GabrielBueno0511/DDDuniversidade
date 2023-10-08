using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Atletica
{
    public class ContratoAtleta
    {
        public int ContratoId { get; set; }

        public int AtletaId { get; set; }
        public Atleta Atleta { get; set; }

        public int EsporteId { get; set; }
        public Esporte Esporte { get; set;}

        public int TempoContrato { get; set; }
    }
}
