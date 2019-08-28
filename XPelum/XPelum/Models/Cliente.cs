using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPelum.Areas.Identity.Repository;

namespace XPelum.Models
{
    public class Cliente : IdentityUser
    {
        public string CPF { get; set; }

        public string NomeCompleto { get; set; }

        public DateTime DataNascimento { get; set; }

        public bool VerificarClientePorCpf(Cliente cliente)
        {
            if (cliente == null)
                return true;
            else
                return false;
        }
    }
}
