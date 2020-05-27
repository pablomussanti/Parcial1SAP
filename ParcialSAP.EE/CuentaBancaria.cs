using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialSAP.EE
{
    public class CuentaBancaria : Entidad
    {
         [Key]
            private int _NumeroCuenta;

            public int NumeroCuenta
            {
                get { return _NumeroCuenta; }
                set { _NumeroCuenta = value; }
            }

        private string _Propietario;

        public string Propietario
        {
            get { return _Propietario; }
            set { _Propietario = value; }
        }
        private double _Saldo;

            public double Saldo
            {
                get { return _Saldo; }
                set { _Saldo = value; }
            }

            private TipoCuentaBancaria _TipoCuentaBancaria;

            public TipoCuentaBancaria TipoCuentaBancaria
            {
                get { return _TipoCuentaBancaria; }
                set { _TipoCuentaBancaria = value; }
            }

         private int _Tipo;

        public int Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }




    }
}
