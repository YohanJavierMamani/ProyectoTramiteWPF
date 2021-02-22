using ProyectoTramite.Connect;
using ProyectoTramite.Core;
using ProyectoTramite.Core.Commands;
using ProyectoTramite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProyectoTramite.ViewModels
{
    public class EstudianteViewModel : Generic
    {
        private Estudiantecollection _listaEstudiantes = new Estudiantecollection();

        private DBConector _connector = new DBConector();

        public Estudiantecollection ListaEstudiante { 
            get { return _listaEstudiantes; }
            set { _listaEstudiantes = value;
                OnPropertyChanged("ListaEstudiante");
            }
        }

        private Estudiante _currentEstudiante;

        public Estudiante CurrentEstudiante
        {
            get { return _currentEstudiante; }
            set { _currentEstudiante = value;
                OnPropertyChanged("CurrentEstudiante");
                OnPropertyChanged("CanShowInfo");
            }
        }

        private ICommand _listarEstudiantesCommand;
        public ICommand ListarEstudiantesCommand
        {
            get
            {
                if (_listarEstudiantesCommand == null)
                    _listarEstudiantesCommand = new RelayCommand(new Action(ListarEstudiantes));
                return _listarEstudiantesCommand;
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
            MessageBox.Show(CurrentEstudiante.Nombre);
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
                CurrentEstudiante = (Estudiante )obj;
                MessageBox.Show(CurrentEstudiante.Nombre);
            }
        }

        private ICommand _eliminarPersonaCommand;
        public ICommand EliminarPersonaCommand
        {
            get
            {
                if (_eliminarPersonaCommand == null)
                    _eliminarPersonaCommand = new ParamCommand(new Action<object>(EliminarPersona));
                return _eliminarPersonaCommand;
            }
        }

        private void EliminarPersona(object obj)
        {
            if (obj != null)
            {
                CurrentEstudiante = (Estudiante)obj;
                if (_connector.eliminarPersona(CurrentEstudiante))
                {
                    if (MessageBox.Show("Eliminado " + CurrentEstudiante.Nombre + "!") == MessageBoxResult.OK)
                    {
                        ListaEstudiante.Remove(((Estudiante)obj));
                    }
                }
            }
        }

        private bool CanShowInfo
        {
            get
            {
                return CurrentEstudiante != null;
            }
        }




        internal DBConector Connector { get => _connector; set => _connector = value; }

        private void ListarEstudiantes()
        {
            ListaEstudiante = Connector.listarPersonas();
        }


        public EstudianteViewModel()
        {

        }
    }
}
