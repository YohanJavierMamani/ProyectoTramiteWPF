using ProyectoTramite.ViewModels;
using ProyectoTramite.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoTramite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainPageViewModel ViewModel { get; set; }
        public ObservableCollection<Models.Amiibo> Amiibos { set; get; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public override async void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ViewModel = new MainPageViewModel();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                //DoSomething();
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CrudWindow crudwindow = new CrudWindow();
            crudwindow.ShowDialog();
        }

        private void Button__Usuario_Click(object sender, RoutedEventArgs e)
        {
            UsuarioWindow usuarioWindow = new UsuarioWindow();
            usuarioWindow.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UsuariosFrecuentesWindow usuariosFrecuentesWindow = new UsuariosFrecuentesWindow();
            usuariosFrecuentesWindow.ShowDialog();
        }
    }
}
