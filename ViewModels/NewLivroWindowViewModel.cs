using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;

namespace LivrariaApp.ViewModels
{
    public class NewLivroWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private NewLivro _livro;
        public NewLivro Livro
        {
            get => _livro;
            set
            {
                _livro = value;
                OnPropertyChanged();
            }
        }

        public NewLivroWindowViewModel()
        {
            Livro = new NewLivro
            {
                Titulo = "",
                Autor = "",
                Preco = 0,
                AnoPublicacao = 0
            };
        }

        public async Task SaveLivroAsync()
        {
            var client = new HttpClient();
            var json = JsonSerializer.Serialize(Livro);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5000/livros", content);
            response.EnsureSuccessStatusCode();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}