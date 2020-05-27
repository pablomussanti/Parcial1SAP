using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialSAP.EE
{
    public class TipoCuentaBancaria : Entidad
    {

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
    }
}

