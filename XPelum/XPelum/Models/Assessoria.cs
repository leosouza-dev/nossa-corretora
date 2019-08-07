﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPelum.ViewModel;

namespace XPelum.Models
{
    public class Assessoria
    {
        public Assessoria()
        {

        }

        public Assessoria(CreateAssessoriaViewModel assessoriaVM, string uniqueFileName)
        {
            Nome = assessoriaVM.Nome;
            Imagem = uniqueFileName;
            Investimento = assessoriaVM.investimento;
            Descricao = assessoriaVM.Descricao;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Imagem { get; private set; }
        public string Investimento { get; private set; }
        public string Descricao { get; private set; }

    }
}
