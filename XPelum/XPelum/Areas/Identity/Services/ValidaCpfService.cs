using Maoli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPelum.Areas.Identity.Repository;

namespace XPelum.Areas.Identity.Services
{
    public class ValidaCpfService
    {
        private readonly UserRepository _userRepository;
        public ValidaCpfService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<string> ListaDeErros = new List<string>();

        public bool ValidarCpf(string cpf)
        {
            var cliente = _userRepository.BuscarPorCpf(cpf);
            if (cliente != null)
            {
                ListaDeErros.Add($"O CPF {cpf} já está sendo utilizado!");
                return false;
            }

            return true;
        }
    }
}
