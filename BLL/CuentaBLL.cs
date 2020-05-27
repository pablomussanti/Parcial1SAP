using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParcialSAP.EE;
using ParcialSAP.DAL;


namespace ParcialSAP.BLL
{
    public class CuentaBLL
    {
        public List<CuentaBancaria> ListarCuentas()
        {
            List<CuentaBancaria> Cuentas = new List<CuentaBancaria>();
            try
            {
                CuentaDAL cuentaDAL = new CuentaDAL();
                Cuentas = cuentaDAL.ListarCuentas();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Cuentas;
        }
        public CuentaBancaria ListarCuentas(int nro_cuenta)
        {
            CuentaBancaria c = new CuentaBancaria();
            try
            {
                CuentaDAL cuentaDAL = new CuentaDAL();
                c = cuentaDAL.ListarCuentas(nro_cuenta);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return c;
        }
        public void ModificarCuenta(CuentaBancaria c)
        {
            try
            {
                CuentaDAL cuentaDAL = new CuentaDAL();
                cuentaDAL.ModificarCuenta(c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public TipoCuentaBancaria buscarTipoCuenta(int nro_tipo)
        {
            TipoCuentaBancaria tc = new TipoCuentaBancaria();
            try
            {
                CuentaDAL cuentaDAL = new CuentaDAL();
                tc = cuentaDAL.buscarTipoCuenta(nro_tipo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tc;
        }
        public void CrearCuenta(CuentaBancaria c)
        {
            try
            {
                CuentaDAL cuentaDAL = new CuentaDAL();
                cuentaDAL.CrearCuenta(c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public List<TipoCuentaBancaria> buscarTipos()
        {
            List<TipoCuentaBancaria> tc = new List<TipoCuentaBancaria>();
            try
            {
                CuentaDAL cuentaDAL = new CuentaDAL();
                tc = cuentaDAL.buscarTipos();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tc;
        }

        public Boolean Deposito(CuentaBancaria a,double Monto)
        {
            Boolean estado = new Boolean();
            try
            {
               
                a.Saldo = a.Saldo + Monto;
                CuentaDAL cuentaDAL = new CuentaDAL();
                cuentaDAL.ModificarCuenta(a);
                estado = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return estado;
        }

        public Boolean Retiro(CuentaBancaria a, double Monto)
        {
            Boolean estado = new Boolean();
            try
            {
                a.Saldo = a.Saldo - Monto;
                CuentaDAL cuentaDAL = new CuentaDAL();
                cuentaDAL.ModificarCuenta(a);
                estado = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return estado;
        }

        public Boolean Transferencia(CuentaBancaria desde, CuentaBancaria hacia, double Monto)
        {
            Boolean estado = new Boolean();
            try
            {
                hacia.Saldo = hacia.Saldo + Monto;
                desde.Saldo = desde.Saldo - Monto;

                CuentaDAL cuentaDAL = new CuentaDAL();
                cuentaDAL.ModificarCuenta(hacia);
                cuentaDAL.ModificarCuenta(desde);
                estado = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return estado;
        }

        public Boolean ValidarCuenta(CuentaBancaria c)
        {
            Boolean Existencia = new Boolean();
            Existencia = false;
            try
            {
                
                List<CuentaBancaria> Cuentas = new List<CuentaBancaria>();
                CuentaDAL cuentaDAL = new CuentaDAL();
                Cuentas = cuentaDAL.ListarCuentas();
                foreach (var item in Cuentas)
                {
                    if (c.NumeroCuenta == item.NumeroCuenta)
                    {
                        Existencia = true;
                    }
                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Existencia;
        }

        public Boolean ValidarSaldo(CuentaBancaria c)
        {
            Boolean Valor = new Boolean();
            Valor = false;
            try
            {
                if (c.Saldo >= 0)
                {
                    Valor = true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Valor;
        }

        public Boolean ValidarSaldo(CuentaBancaria c, double monto)
        {
            Boolean Valor = new Boolean();
            Valor = false;
            c.Saldo = c.Saldo - monto;
            try
            {
                if (c.Saldo >= 0)
                {
                    Valor = true;
                }
                c.Saldo = c.Saldo + monto;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Valor;
        }


        public void EliminarCuenta(CuentaBancaria c)
        {
            try
            {
                CuentaDAL cuentaDAL = new CuentaDAL();
                cuentaDAL.EliminarCuenta(c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
