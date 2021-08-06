using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoInicial.webApi.Domains
{
    public partial class Equipamento
    {
        public Equipamento()
        {
            SalasEquipamentos = new HashSet<SalasEquipamento>();
        }

        public int IdEquipamento { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        public string NumeroSerie { get; set; }
        public string Descricao { get; set; }
        public string NumeroPatrimonio { get; set; }
        public bool Disponivel { get; set; }

        public virtual ICollection<SalasEquipamento> SalasEquipamentos { get; set; }
    }
}
