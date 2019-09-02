using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPelum.Data;
using XPelum.Models;

namespace XPelum.Repository
{
    public class AssessoriaRepository
    {

        private readonly MeuDbContext _context;
        public AssessoriaRepository(MeuDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Assessoria> ListarTodas()
        {
            return _context.Assessoria.ToList();
        }

        public void Salvar(Assessoria assessoria)
        {
            _context.Add(assessoria);
            _context.SaveChanges();
        }
    }
}