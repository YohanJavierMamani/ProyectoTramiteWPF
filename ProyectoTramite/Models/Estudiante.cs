using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoTramite.Models
{

    public class Estudiantecollection : ObservableCollection<Estudiante>
    {

    }

    public class Estudiante
    {
        private int _id;

        public int Id { get => _id; set => _id = value; }


        private string _nombre;

        public string Nombre { get => _nombre; set => _nombre = value; }

        private DateTime _fecha;

        public DateTime Fecha { get => _fecha; set => _fecha = value; }


        public Estudiante()
        {

        }

        public Estudiante(int id, String nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public override string ToString()
        {
            return this.Nombre;
        }

    }
}
