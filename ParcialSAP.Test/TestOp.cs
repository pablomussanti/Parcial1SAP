using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParcialSAP.BLL;
using ParcialSAP.EE;

namespace ParcialSAP.Test
{
    [TestClass]
    public class TestOp
    {
        [TestMethod]
        public void Deposito()
        {
            Boolean resultado = true;
            double monto;
            CuentaBancaria cuentabancariatest = new CuentaBancaria();
            CuentaBLL cuentabll = new CuentaBLL();
            TipoCuentaBancaria tipo = new TipoCuentaBancaria();



            tipo.Codigo = 1;
            monto = 100;
            cuentabancariatest.NumeroCuenta = 100;
            cuentabancariatest.TipoCuentaBancaria = tipo;
            cuentabancariatest.Saldo = 100;
            cuentabancariatest.Propietario = "Test";


            Assert.AreEqual(cuentabll.Deposito(cuentabancariatest,cuentabancariatest.Saldo), resultado);
        }

        [TestMethod]
        public void Retiro()
        {
            Boolean resultado = true;
            double monto;
            CuentaBancaria cuentabancariatest = new CuentaBancaria();
            CuentaBLL cuentabll = new CuentaBLL();
            TipoCuentaBancaria tipo = new TipoCuentaBancaria();



            tipo.Codigo = 1;
            monto = 100;
            cuentabancariatest.NumeroCuenta = 100;
            cuentabancariatest.TipoCuentaBancaria = tipo;
            cuentabancariatest.Saldo = 100;
            cuentabancariatest.Propietario = "Test";


            Assert.AreEqual(cuentabll.Retiro(cuentabancariatest, cuentabancariatest.Saldo), resultado);
        }

        [TestMethod]
        public void Transferencia()
        {
            Boolean resultado = true;
            double monto;
            CuentaBancaria cuentabancariatest2 = new CuentaBancaria();
            CuentaBancaria cuentabancariatest1 = new CuentaBancaria();
            CuentaBLL cuentabll = new CuentaBLL();
            TipoCuentaBancaria tipo = new TipoCuentaBancaria();



            tipo.Codigo = 1;
            monto = 100;
            cuentabancariatest1.NumeroCuenta = 1;
            cuentabancariatest1.TipoCuentaBancaria = tipo;
            cuentabancariatest1.Saldo = 100;
            cuentabancariatest1.Propietario = "Test1";
            cuentabancariatest2.NumeroCuenta = 2;
            cuentabancariatest2.TipoCuentaBancaria = tipo;
            cuentabancariatest2.Saldo = 100;
            cuentabancariatest2.Propietario = "Test2";


            Assert.AreEqual(cuentabll.Transferencia(cuentabancariatest1, cuentabancariatest2,monto), resultado);
        }




    }


}
