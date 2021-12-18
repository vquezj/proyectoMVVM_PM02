using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoMVVM.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoMVVM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detalle : ContentPage
    {
        public Detalle(Empleado modelo)
        {
            InitializeComponent();
            BindingContext = modelo;
        }
    }
}