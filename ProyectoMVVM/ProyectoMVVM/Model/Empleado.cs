﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProyectoMVVM.Model
{
    public class Empleado : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] String nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        private bool isBusy = false;

        public bool Isbusy
        {
            get { return isBusy = false; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NombreCompleto));
            }
        }

        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set
            {
                apellido = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(NombreCompleto));
            }
        }

        private int edad;

        public int Edad
        {
            get { return edad; }
            set
            {
                edad = value;
                OnPropertyChanged();
            }
        }

        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set
            {
                direccion = value;
                OnPropertyChanged();
            }
        }

        private string puesto;

        public string Puesto
        {
            get { return puesto; }
            set
            {
                puesto = value;
                OnPropertyChanged();
            }
        }

        private string nombreCompleto;

        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; }
            set
            {
                nombreCompleto = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Mensaje));
            }
        }


        private string mensaje;

        public string Mensaje
        {
            get
            {

                return $"Tu nombre es:{NombreCompleto}";
            }
        }
    }
}
