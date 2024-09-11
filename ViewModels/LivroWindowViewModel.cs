using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace LivrariaApp.ViewModels;

public class LivroWindowViewModel : ViewModelBase
{
    public Livro Livro { get; }

    public LivroWindowViewModel(Livro livro)
    {
        Livro = livro;
    }

    public void SalvarLivro(Livro livro)
    {
        if (livro.Id == 0)
        {
            AddLivroAsync(livro);
        }
        else
        {
            UpdateLivroAsync(livro);
        }
    }

    public async Task AddLivroAsync(Livro livro)
    {
        var client = new HttpClient();
        var content = new StringContent(JsonSerializer.Serialize(livro), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5000/livros", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateLivroAsync(Livro livro)
    {
        var client = new HttpClient();
        var content = new StringContent(JsonSerializer.Serialize(livro), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PatchAsync($"http://localhost:5000/livros?id={livro.Id}", content);
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Failed to update livro");
        }
        else
        {
            Console.WriteLine("Livro atualizado com sucesso!");
        }
    }

    public async Task DeleteLivroAsync(Livro livro)
    {
        var client = new HttpClient();
        var response = await client.DeleteAsync($"http://localhost:5000/livros?id={livro.Id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Failed to delete livro");
        }
        else
        {
            Console.WriteLine("Livro excluído com sucesso!");
        }
    }


}
/* using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using LivrariaApp.Views;

namespace LivrariaApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static

    private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    public string Greeting => "Bem vindo à Livraria!";

    public ObservableCollection<Livro> Livros { get; } = new ObservableCollection<Livro>();

    public MainWindowViewModel()
    {
        LoadLivros();

    }

    private void LoadLivros()
    {
        Task.Run(async () =>
        {
            var livros = await LoadLivrosAsync();
            foreach (var livro in livros)
            {
                Livros.Add(livro);
            }
        });
    }

    public async Task<List<Livro>> LoadLivrosAsync()
    {
        var client = new HttpClient();
        var response = await client.GetAsync("http://localhost:5000/livros");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var livros = JsonSerializer.Deserialize<List<Livro>>(content, jsonOptions);
        Console.WriteLine($"Loaded {livros?.ToArray().Length} livros");
        if (livros is null)
        {
            throw new InvalidOperationException("Failed to load livros");
        }
        return livros;
    }

    public async Task AddLivroAsync(Livro livro)
    {
        var client = new HttpClient();
        var content = new StringContent(JsonSerializer.Serialize(livro), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5000/livros", content);
        response.EnsureSuccessStatusCode();
        LoadLivros();
    }

    public async Task UpdateLivroAsync(Livro livro)
    {
        var client = new HttpClient();
        var content = new StringContent(JsonSerializer.Serialize(livro), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"http://localhost:5000/livros?id={livro.Id}", content);
        response.EnsureSuccessStatusCode();
        LoadLivros();
    }

    public async Task DeleteLivroAsync(Livro livro)
    {
        var client = new HttpClient();
        var response = await client.DeleteAsync($"http://localhost:5000/livros?id={livro.Id}");
        response.EnsureSuccessStatusCode();
        LoadLivros();
    }



#pragma warning restore CA1822 // Mark members as static
} */