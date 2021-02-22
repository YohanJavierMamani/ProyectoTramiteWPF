using ProyectoTramite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTramite.Connect
{
    class DBConector
    {
        public Estudiantecollection listarPersonas()
        {
            Estudiantecollection lista = new Estudiantecollection();
            lista.Add(new Estudiante(1, "Pedro"));
            lista.Add(new Estudiante(2, "Juan"));
            lista.Add(new Estudiante(3, "Diego"));
            lista.Add(new Estudiante(4, "Luis"));
            return lista;
        }

        public bool eliminarPersona(Estudiante p)
        {
            return true;
        }
    }
}
