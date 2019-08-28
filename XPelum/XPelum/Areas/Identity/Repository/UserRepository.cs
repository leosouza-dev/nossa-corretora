using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPelum.Data;
using XPelum.Models;

namespace XPelum.Areas.Identity.Repository
{
    public class UserRepository
    {
        private ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Cliente BuscarPorCpf(string cpf)
        {
            return _context.Clientes.FirstOrDefault(c => c.CPF == cpf);
        }
    }
}
