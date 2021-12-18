using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProyectoMVVM.Model;
using System.Collections.ObjectModel;

namespace ProyectoMVVM.Servicio
{
    public class EmpleadosServ
    {
        public ObservableCollection<Empleado> empleados { get; set; }

        public EmpleadosServ()
        {
            if (empleados == null)
            {
                empleados = new ObservableCollection<Empleado>();
            }
        }


        public ObservableCollection<Empleado> Consultar()
        {
            return empleados;
        }

        public void Guardar(Empleado modelo)
        {
            empleados.Add(modelo);
        }

        public void Modificar(Empleado modelo)
        {
            for (int i = 0; i < empleados.Count; i++)
            {
                if (empleados[i].Id == modelo.Id)
                {
                    empleados[i] = modelo;
                }

            }
        }

        public void Eliminar(String idEmpleado)
        {
            Empleado modelo = empleados.FirstOrDefault(p => p.Id == idEmpleado);
            empleados.Remove(modelo);
        }
    }
}
