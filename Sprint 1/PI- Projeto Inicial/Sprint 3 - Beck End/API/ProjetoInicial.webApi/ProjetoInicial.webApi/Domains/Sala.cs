using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoInicial.webApi.Domains
{
    public partial class Sala
    {
        public Sala()
        {
            SalasEquipamentos = new HashSet<SalasEquipamento>();
        }

        public int IdSala { get; set; }
        public int Andar { get; set; }
        public string Nome { get; set; }
        public int Metragem { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<SalasEquipamento> SalasEquipamentos { get; set; }
    }
}
