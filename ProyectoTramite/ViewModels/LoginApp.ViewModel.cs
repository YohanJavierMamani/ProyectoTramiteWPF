using ProyectoTramite.Core;
using ProyectoTramite.Core.Commands;
using ProyectoTramite.Models;
using ProyectoTramite.Providers.LoginAppProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProyectoTramite.ViewModels
{
    class LoginAppViewModel : Generic
    {
        ILoginAppProvider loginAppProvider;

        private ICommand _loginUserCommand;

        public LoginAppViewModel()
        {
            loginAppProvider = new LoginAppProvider();
        }

        public ICommand LoginUserCommand
        {
            get
            {
                if (_loginUserCommand == null)
                    _loginUserCommand = new ParamCommand(new Action<object>(loginUser));
                return _loginUserCommand;
            }
        }

        private async void loginUser(object obj)
        {
            var responseToken = await loginAppProvider.LoginUsuario(obj);
            if (responseToken != null)
            {
                TokenModel tokenModel = responseToken;
                Properties.Settings.Default.AccessToken = tokenModel.data.access_token;
                Properties.Settings.Default.Save();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                mainWindow.Activate();
            }
            else
            {
                MessageBox.Show("No se pudo loguear");
            }
        }
    }
}
