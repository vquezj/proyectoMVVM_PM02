using System;
using System.Collections.Generic;
using System.Text;
using ProyectoMVVM.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProyectoMVVM.Servicio;
using Xamarin.Forms;

namespace ProyectoMVVM.ViewModel
{
    public class EmpleadoVM : Empleado
    {
        public ObservableCollection<Empleado> Empleados { get; set; }
        EmpleadosServ servicio = new EmpleadosServ();
        Empleado modelo;

        public EmpleadoVM()
        {
            Empleados = servicio.Consultar();
            GuardarCommand = new Command(async () => await Guardar(), () => !Isbusy);
            ModificarCommand = new Command(async () => await Modificar(), () => !Isbusy);
            EliminarCommand = new Command(async () => await Eliminar(), () => !Isbusy);
            LimpiarCommand = new Command(Limpiar, () => !Isbusy);
        }

        public Command GuardarCommand { get; set; }

        public Command ModificarCommand { get; set; }

        public Command EliminarCommand { get; set; }

        public Command LimpiarCommand { get; set; }

        private async Task Guardar()
        {
            Isbusy = true;
            Guid IdEmpleado = Guid.NewGuid();
            modelo = new Empleado()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Direccion = Direccion,
                Puesto = Puesto,
                Id = IdEmpleado.ToString()
            };
            servicio.Guardar(modelo);
            await Task.Delay(2000);
            Isbusy = false;
        }

        private async Task Modificar()
        {
            Isbusy = true;

            modelo = new Empleado()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Direccion = Direccion,
                Puesto = Puesto,
                Id = Id
            };
            servicio.Modificar(modelo);
            await Task.Delay(2000);
            Isbusy = false;
        }

        private async Task Eliminar()
        {
            Isbusy = true;
            servicio.Eliminar(Id);
            await Task.Delay(2000);
            Isbusy = false;
        }

        private void Limpiar()
        {
            Nombre = "";
            Apellido = "";
            Edad = 0;
            Direccion = "";
            Puesto = "";
            Id = "";

        }
    }
}
