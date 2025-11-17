namespace CRUDSimples.Domain;

public class Produto
{
    public ProdutoId Id { get; private set; }
    public NomeProduto Nome { get; private set; }
    public DescricaoProduto? Descricao { get; private set; }
    public PrecoProduto Preco { get; private set; }
    public EstoqueProduto Estoque { get; private set; }

    private Produto() { } // Para ORM

    // Factory method para novo produto
    public static Produto Criar(NomeProduto nome, DescricaoProduto descricao, PrecoProduto preco, EstoqueProduto estoque)
    {
        var produto = new Produto
        {
            Id = ProdutoId.Novo(), // ID 0 indica novo produto
            Nome = nome,
            Descricao = descricao,
            Preco = preco,
            Estoque = estoque
        };

        return produto;
    }

    // Factory method para produto existente
    public static Produto Carregar(ProdutoId id, NomeProduto nome, DescricaoProduto descricao, PrecoProduto preco, EstoqueProduto estoque)
    {
        if (!id.EhPersistido)
            throw new ArgumentOutOfRangeException(nameof(id), "ID deve ser persistido para carregar entidade existente");

        var produto = new Produto
        {
            Id = id,
            Nome = nome,
            Descricao = descricao,
            Preco = preco,
            Estoque = estoque
        };

        return produto;
    }

    // Métodos de Atualização
    public void AtualizarNome(NomeProduto novoNome)
    {
        Nome = novoNome;
    }

    public void AtualizarDescricao(DescricaoProduto novaDescricao)
    {
        Descricao = novaDescricao;
    }

    public void AtualizarPreco(PrecoProduto novoPreco)
    {
        Preco = novoPreco;
    }

    public void AtualizarEstoque(EstoqueProduto novoEstoque)
    {
        Estoque = novoEstoque;
    }

    public override string ToString()
        => $"{Nome.Valor} - R${Preco.Valor} (Estoque: {Estoque.Valor})";
}