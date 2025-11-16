namespace CRUDSimples.Domain
{
    public readonly record struct ProdutoId(int Valor)
    {
        public static ProdutoId Criar(int valor)
        {
            if (valor < 0)
                throw new ArgumentOutOfRangeException(nameof(valor), "Id do produto não pode ser negativo.");

            return new ProdutoId(valor);
        }


        // Factory method para novo produto
        public static ProdutoId Novo() => new(0);

        // Factory method para ID persistido
        public static ProdutoId FromDatabase(int valor) => Criar(valor);

        // Operadores de conversão
        public static implicit operator int(ProdutoId id) => id.Valor;
        public static explicit operator ProdutoId(int valor) => Criar(valor);
        public override string ToString() => Valor.ToString();
    }

    public record struct NomeProduto
    {
        public string Valor { get; }

        private NomeProduto(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentNullException(nameof(valor), "O nome não pode ser vazio.");

            if (valor.Length > 100)
                throw new ArgumentOutOfRangeException(nameof(valor), "O nome pode ter no máximo 100 caracteres.");

            Valor = valor.Trim();
        }

        public static NomeProduto Criar(string valor) => new(valor);

        // Operadores de conversão 
        public static implicit operator string(NomeProduto nome) => nome.Valor;
        public static explicit operator NomeProduto(string valor) => Criar(valor);

        public override string ToString() => Valor.ToString();
    }

    public record struct DescricaoProduto
    {
        public string? Valor { get; }

        private DescricaoProduto(string? valor)
        {
            if (valor is null)
                return;

            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentNullException(nameof(valor), "A descrição não pode conter apenas espaços em branco.");

            if (valor.Length > 500)
                throw new ArgumentOutOfRangeException(nameof(valor), "A descrição pode ter no máximo 500 caracteres");

            Valor = valor.Trim();
        }

        public static DescricaoProduto Criar(string valor) => new(valor);

        // Operadores de conversão
        public static implicit operator string?(DescricaoProduto descricao) => descricao.Valor;
        public static explicit operator DescricaoProduto?(string valor) => Criar(valor);
    }

    public record struct PrecoProduto
    {
        public decimal Valor { get; }

        private PrecoProduto(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentOutOfRangeException(nameof(valor), "Preço não pode ser negativo.");

            Valor = valor;
        }

        public 
    }
}
