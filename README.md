# web-api
API para um sistema para gerenciar um restaurante.

# Configurações iniciais
Após clonar o repositório, execute o seguinte comando:

```dotnet restore```

Depois, execute:

```dotnet ef migrations add initial```

Por fim, execute:

```dotnet ef database update```

# Execução
Caso esteja desenvolvendo, execute:

```dotnet watch run```

Caso queira executar em modo de produção:

```dotnet run```
