using Avalonia.Controls;
using Avalonia.Interactivity;
using LivrariaApp.ViewModels;
using System;
namespace LivrariaApp.Views;
public partial class NewLivroWindow : Window
{
    public NewLivroWindow()
    {
        InitializeComponent();
        DataContext = new NewLivroWindowViewModel();
    }

    private void Salvar_Button_Click(object sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as NewLivroWindowViewModel;
        Console.WriteLine($"Salvando livro {viewModel.Livro.Titulo}");
        viewModel.SaveLivroAsync();
        Console.WriteLine("Livro salvo com sucesso!");
        Close();
    }

    private void Cancelar_Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}