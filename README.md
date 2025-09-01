# API de Produtos

Uma API RESTful desenvolvida em .NET 8 para gerenciamento de produtos.

## 📋 Sobre o Projeto

Esta API permite realizar operações CRUD (Create, Read, Update, Delete) em produtos, utilizando Entity Framework Core com SQL Server como banco de dados.

## 🚀 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI
- Minimal APIs

## 📦 Funcionalidades

- ✅ Criar novos produtos
- ✅ Listar todos os produtos
- ✅ Buscar produto por ID
- ✅ Atualizar produtos existentes
- ✅ Excluir produtos
- ✅ Documentação automática com Swagger

## 🛠️ Pré-requisitos

- .NET 8 SDK
- SQL Server (LocalDB ou instância completa)
- Visual Studio 2022 ou VS Code

## ⚙️ Configuração

1. Clone o repositório:
```bash
git clone [URL_DO_REPOSITORIO]
cd WEB-API/ApiProdutos
```

2. Configure a string de conexão no arquivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "ApiProdutosContext": "Server=(localdb)\\mssqllocaldb;Database=ApiProdutosContext;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

3. Execute as migrações do banco de dados:
```bash
dotnet ef database update
```

4. Execute a aplicação:
```bash
dotnet run
```

## 📖 Documentação da API

Após executar a aplicação, acesse a documentação Swagger em:
- `https://localhost:[PORTA]/swagger`

## 🗂️ Estrutura do Projeto

```
ApiProdutos/
├── Data/
│   └── ApiProdutosContext.cs      # Contexto do Entity Framework
├── Entities/
│   └── Produto.cs                 # Modelo de dados do Produto
├── Migrations/                    # Migrações do banco de dados
├── ProdutoEndpoints.cs           # Endpoints da API
├── Program.cs                    # Ponto de entrada da aplicação
└── appsettings.json             # Configurações da aplicação
```

## 📊 Modelo de Dados

### Produto
```csharp
{
    "id": 1,
    "nome": "Nome do Produto",
    "preco": 99.99,
    "estoque": 100
}
```

## 🔧 Endpoints Disponíveis

- `GET /api/produtos` - Lista todos os produtos
- `GET /api/produtos/{id}` - Busca produto por ID
- `POST /api/produtos` - Cria um novo produto
- `PUT /api/produtos/{id}` - Atualiza um produto existente
- `DELETE /api/produtos/{id}` - Remove um produto

## 🤝 Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👨‍💻 Autor

Arthur Jacinto

---

⭐ Se este projeto te ajudou, não esqueça de dar uma estrela!
