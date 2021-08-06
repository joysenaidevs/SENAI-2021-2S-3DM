using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoInicial.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Salas = new HashSet<Sala>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdTiposUsuario { get; set; }

        public virtual TiposUsuario IdTiposUsuarioNavigation { get; set; }
        public virtual ICollection<Sala> Salas { get; set; }
    }
}
