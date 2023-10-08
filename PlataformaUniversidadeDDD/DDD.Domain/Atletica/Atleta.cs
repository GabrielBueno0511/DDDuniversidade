using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Atletica
{
    public class Atleta: User
    {
        public List<Esporte> Esportes{ get; set; }

    }
}
