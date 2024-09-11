# LivrariaApp

Este é o projeto LivrariaApp, uma aplicação desenvolvida com Avalonia

## Estrutura do Projeto

```plaintext
.gitignore
.vscode/
    settings.json
App.axaml
App.axaml.cs
app.manifest
Assets/
bin/
    Debug/
...
LivrariaApp.csproj
LivrariaApp.sln
Models/
    Livro.cs
    NewLivro.cs
obj/
    Debug/
        LivrariaApp.csproj.nuget.dgspec.json
        LivrariaApp.csproj.nuget.g.props
        LivrariaApp.csproj.nuget.g.targets
        project.assets.json
        project.nuget.cache
Program.cs
README.md
ViewLocator.cs
ViewModels/
    LivroWindowViewModel.cs
    MainWindowViewModel.cs
    NewLivroWindowViewModel.cs
    ViewModelBase.cs
Views/
    LivroWindow.axaml
...
```

## Pré-requisitos

- .NET SDK 6.0 ou superior
- ⚠️⚠️ Ter o projeto LivrariaApi rodando localmente com Docker https://github.com/GabrielMessiasdaRosa/LivrariaApi ⚠️⚠️

## Como rodar o projeto

### Executar com `dotnet run`

1. Abra um terminal na raiz do projeto.
2. Execute o comando:

   ```sh
   dotnet run
   ```

### Executar com `dotnet watch`

1. Abra um terminal na raiz do projeto.
2. Execute o comando:

   ```sh
   dotnet watch run
   ```

Isso iniciará a aplicação e monitorará as mudanças no código, reiniciando automaticamente quando houver alterações.

## Estrutura dos Diretórios

- **Models/**: Contém as classes de modelo, como `Livro.cs` e `NewLivro.cs`.
- **ViewModels/**: Contém as classes de ViewModel, como `LivroWindowViewModel.cs`, `MainWindowViewModel.cs`, `NewLivroWindowViewModel.cs` e `ViewModelBase.cs`.
- **Views/**: Contém os arquivos de visualização, como `LivroWindow.axaml`.
- **Assets/**: Contém os recursos da aplicação.
- **bin/** e **obj/**: Diretórios gerados pelo build do .NET.
