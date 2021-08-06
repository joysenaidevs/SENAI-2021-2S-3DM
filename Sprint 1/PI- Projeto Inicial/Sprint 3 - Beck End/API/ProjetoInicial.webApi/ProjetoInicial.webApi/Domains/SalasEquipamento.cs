using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoInicial.webApi.Domains
{
    public partial class SalasEquipamento
    {
        public int IdSalasEquipamento { get; set; }
        public int? IdSala { get; set; }
        public int? IdEquipamento { get; set; }

        public virtual Equipamento IdEquipamentoNavigation { get; set; }
        public virtual Sala IdSalaNavigation { get; set; }
    }
}
