using ProyectoTramite.Core;
using ProyectoTramite.Core.Commands;
using ProyectoTramite.Helpers;
using ProyectoTramite.Models;
using ProyectoTramite.Providers.UsuarioProvider;
using ProyectoTramite.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProyectoTramite.ViewModels
{
    class UsuarioViewModel : Generic
    {
        IUsuarioProvider usuarioProvider;

        public UsuarioViewModel()
        {
            usuarioProvider = new UsuarioProvider();
        }

        public ObservableCollection<UserModel> UsersModel { set; get; }

        public ObservableCollection<UserModel> ListaUsuario
        {
            get { return UsersModel; }
            set
            {
                UsersModel = value;
                OnPropertyChanged("ListaUsuario");
            }
        }

        private ICommand _listarUsuariosCommand;
        public ICommand ListarUsuariosCommand
        {
            get
            {
                if (_listarUsuariosCommand == null)
                    _listarUsuariosCommand = new RelayCommand(new Action(ListarUsuarios));
                return _listarUsuariosCommand;
            }
        }

        private async void ListarUsuarios()
        {
            ListaUsuario = await usuarioProvider.listarUsuarios("2");
        }


        private UserModel _currentUser;

        public UserModel CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged("CurrentEstudiante");
                OnPropertyChanged("CanShowInfo");
            }
        }


        private ICommand _verInfoCommand;
        public ICommand VerInfoCommand
        {
            get
            {
                if (_verInfoCommand == null)
                    _verInfoCommand = new RelayCommand(new Action(VerInfo), () => CanShowInfo);
                return _verInfoCommand;
            }
        }

        private void VerInfo()
        {
            MessageBox.Show(CurrentUser.first_name);
        }

        private bool CanShowInfo
        {
            get
            {
                return CurrentUser != null;
            }
        }

        private ICommand _verInfo2Command;
        public ICommand VerInfo2Command
        {
            get
            {
                if (_verInfo2Command == null)
                    _verInfo2Command = new ParamCommand(new Action<object>(VerInfo2));
                return _verInfo2Command;
            }
        }

        private void VerInfo2(object obj)
        {
            if (obj != null)
            {
                CurrentUser = (UserModel)obj;
                MessageBox.Show(CurrentUser.first_name);
            }
        }



        private ICommand _showModalAddUser;
        public ICommand ShowModalAddUser
        {
            get
            {
                if (_showModalAddUser == null)
                    _showModalAddUser = new RelayCommand(new Action(VerShowModalAddUser));
                return _showModalAddUser;
            }
        }

        private void VerShowModalAddUser()
        {
            NuevoUsuario NuevoUsuarioWindow = new NuevoUsuario();

            NuevoUsuarioWindow.ShowDialog();
        }

        private ICommand _addUserCommand;
        public ICommand AddUserCommand
        {
            get
            {
                if (_addUserCommand == null)
                    _addUserCommand = new ParamCommand(new Action<object>(AddUser));
                return _addUserCommand;
            }
        }

        private async void AddUser(object obj)
        {
            var amiibos = await usuarioProvider.addUsuario(obj);
            if (amiibos!=null)
            {
               String accessToken = Properties.Settings.Default.AccessToken;
                Properties.Settings.Default.Save();
                MessageBox.Show("Registró");
            }
        }


        public ObservableCollection<UsuarioFrecuenteModel> UsersFrecuentesModel { set; get; }

        public ObservableCollection<UsuarioFrecuenteModel> ListaUsuarioFrecuentes
        {
            get { return UsersFrecuentesModel; }
            set
            {
                UsersFrecuentesModel = value;
                OnPropertyChanged("UsersFrecuentesModel");
            }
        }


        private ICommand _listarUsuariosFrecuentesCommand;
        public ICommand ListarUsuariosFrecuentesCommand
        {
            get
            {
                if (_listarUsuariosFrecuentesCommand == null)
                    _listarUsuariosFrecuentesCommand = new RelayCommand(new Action(ListarUsuariosFrecuentes));
                return _listarUsuariosFrecuentesCommand;
            }
        }

        public async void ListarUsuariosFrecuentes()
        {
            ListaUsuarioFrecuentes = await usuarioProvider.listarUsuariosFrecuentes();
            var data = ListaUsuarioFrecuentes;
        }

    }
}
