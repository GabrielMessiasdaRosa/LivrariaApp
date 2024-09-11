using Avalonia.Controls;
using Avalonia.Interactivity;
using LivrariaApp.ViewModels;
using System;
namespace LivrariaApp.Views;
public partial class LivroWindow : Window
{
    public LivroWindow(Livro livro)
    {
        InitializeComponent();
        DataContext = new LivroWindowViewModel(livro);
    }

    private void Salvar_Button_Click(object sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as LivroWindowViewModel;
        Console.WriteLine($"Salvando livro {viewModel.Livro.Titulo}");
        viewModel.SalvarLivro(viewModel.Livro);
        Console.WriteLine("Livro salvo com sucesso!");
        Close();
    }

    private void Excluir_Button_Click(object sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as LivroWindowViewModel;
        Console.WriteLine($"Excluindo livro {viewModel.Livro.Titulo}");
        viewModel.DeleteLivroAsync(viewModel.Livro);
        Console.WriteLine("Livro excluído com sucesso!");
        Close();
    }

    private void Cancelar_Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}