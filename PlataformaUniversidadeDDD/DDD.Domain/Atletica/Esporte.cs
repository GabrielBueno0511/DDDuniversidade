using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Atletica
{
    public class Esporte
    {
        public int EsporteId { get; set; }

        public string NomeEsporte { get; set; }
        public List<Atleta> Atletas { get; set; }

    }
}
