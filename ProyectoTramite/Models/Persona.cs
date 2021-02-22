using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoTramite.Models
{
    public class PersonaCollection : ObservableCollection<Persona>
    {

    }

    public class Persona
    {
        private int _id;
        public int Id { get => _id; set => _id = value; }

        private String nombre;

        private DateTime _fechaNac;



        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaNac { get => _fechaNac; set => _fechaNac = value; }

        public Persona()
        {

        }

        public Persona(int id, String nombre, DateTime fechaNac)
        {
            this.Id = id;
            this.nombre = nombre;
            this._fechaNac = fechaNac;
        }


        public override string ToString()
        {
            return Nombre;
        }
    }
}
