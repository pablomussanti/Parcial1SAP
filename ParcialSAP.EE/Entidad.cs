using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialSAP.EE
{
    public abstract class Entidad
    {
        private int _Codigo;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
    }
}
