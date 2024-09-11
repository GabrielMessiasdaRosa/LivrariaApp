using Avalonia.Controls;
using Avalonia.Interactivity;
using LivrariaApp.ViewModels;
using System;
namespace LivrariaApp.Views;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
        Activated += OnWindowActivated;
    }

    private void Editar_Livro_Button_Click(object sender, RoutedEventArgs e)
    {
        var livro = (sender as Button).DataContext as Livro;
        var livroWindow = new LivroWindow(livro);
        livroWindow.ShowDialog(this);
    }

    private void Adicionar_Livro_Button_Click(object sender, RoutedEventArgs e)
    {
        var newLivroWindow = new NewLivroWindow();
        newLivroWindow.ShowDialog(this);
    }

    private void OnWindowActivated(object sender, EventArgs e)
    {
        if (DataContext is MainWindowViewModel viewModel)
        {
            viewModel.LoadLivros();
        }
    }
}
