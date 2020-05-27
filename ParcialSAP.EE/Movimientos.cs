using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialSAP.EE
{
    public class Movimientos : Entidad
    {
        

        private int _CuentaBancariaOrigen;

        public int CuentaBancariaOrigen
        {
            get { return _CuentaBancariaOrigen; }
            set { _CuentaBancariaOrigen = value; }
        }

        private int _CuentaBancariaDestino;

        public int CuentaBancariaDestino
        {
            get { return _CuentaBancariaDestino; }
            set { _CuentaBancariaDestino = value; }
        }

        private double _Saldo;

        public double Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }


        private string _Tipo;

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
    }
}
