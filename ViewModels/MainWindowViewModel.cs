using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LivrariaApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        public string Greeting => "Bem vindo à Livraria!";

        private ObservableCollection<Livro> _livros;
        public ObservableCollection<Livro> Livros
        {
            get => _livros;
            set
            {
                _livros = value;
                OnPropertyChanged(nameof(Livros));
            }
        }

        public MainWindowViewModel()
        {
            LoadLivros();
        }

        public async void LoadLivros()
        {
            var livros = await LoadLivrosAsync();
            Livros = new ObservableCollection<Livro>(livros);
        }

        public async Task<List<Livro>> LoadLivrosAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/livros");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var livros = JsonSerializer.Deserialize<List<Livro>>(content, jsonOptions);
            return livros;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}