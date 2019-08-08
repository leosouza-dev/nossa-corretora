using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPelum.ViewModel;

namespace XPelum.Models
{
    public class Assessoria
    {
        public Assessoria(){}

        public Assessoria(string nome, string imagem, string investimento, string descricao)
        {
            Nome = nome;
            Imagem = imagem;
            Investimento = investimento;
            Descricao = descricao;
        }

        public int Id { get; private set;}
        public string Nome { get; private set; }
        public string Imagem { get; private set; }
        public string Investimento { get; private set; }
        public string Descricao { get; private set; }

    }
}
