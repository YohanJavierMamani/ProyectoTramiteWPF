using ProyectoTramite.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoTramite.Views
{
    /// <summary>
    /// Lógica de interacción para UsuariosFrecuentesWindow.xaml
    /// </summary>
    public partial class UsuariosFrecuentesWindow : Window
    {
        public UsuariosFrecuentesWindow()
        {
            InitializeComponent();
            inicializarValores();
        }

        public void inicializarValores()
        {
            UsuarioViewModel ViewModel = new UsuarioViewModel();
            ViewModel.ListarUsuariosFrecuentes();
            this.DataContext = ViewModel;
        }
    }
}
