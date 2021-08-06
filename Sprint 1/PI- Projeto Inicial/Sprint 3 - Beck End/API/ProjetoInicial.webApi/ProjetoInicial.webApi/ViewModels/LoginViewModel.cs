using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Domains;

namespace ProjetoInicial.webApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é necessário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é necessário")]

        public string Senha { get; set; }
    }
}
