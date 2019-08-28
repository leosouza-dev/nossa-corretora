namespace XPelum.Models
{
    public class Assessoria
    {
        public Assessoria(string nome, string imagem, string investimento, string descricao)
        {
            Nome = nome;
            Imagem = imagem;
            Investimento = investimento;
            Descricao = descricao;
        }

        public int Id { get; private set; }
        public string Nome { get; }
        public string Imagem { get; }
        public string Investimento { get; }
        public string Descricao { get; }
    }
}
