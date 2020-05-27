using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParcialSAP.BLL;
using ParcialSAP.EE;

namespace ParcialSAP.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult Index()
        {
            CuentaBLL cuentaBLL = new CuentaBLL();
            return View(cuentaBLL.ListarCuentas());
        }

        // GET: Cuenta/Details/5
        public ActionResult Details(int id)
        {
            CuentaBLL cuentaBLL = new CuentaBLL();
            return View(cuentaBLL.ListarCuentas(id));
        }

        // GET: Cuenta/Create
        public ActionResult Create()
        {
            CuentaBLL cuentaBLL = new CuentaBLL();
            ViewBag.Tipo = new SelectList(cuentaBLL.buscarTipos(), "Codigo", "Nombre");
            return View();
        }

        // POST: Cuenta/Create
        [HttpPost]
        public ActionResult Create(CuentaBancaria c)
        {
            CuentaBLL cuentaBLL = new CuentaBLL();
            ViewBag.Tipo = new SelectList(cuentaBLL.buscarTipos(), "Codigo", "Nombre");
            try
            {
                if (cuentaBLL.ValidarSaldo(c) == false)
                {
                    throw new Exception();
                }
               
                if (cuentaBLL.ValidarCuenta(c) == true)
                {
                    throw new Exception();
                }

                c.TipoCuentaBancaria = cuentaBLL.buscarTipoCuenta(c.Tipo);
                cuentaBLL.CrearCuenta(c);
                return RedirectToAction("Index");
            }
            catch
            {
                
                ViewBag.Advertencia = "Ya existe el numero de cuenta o saldo invalido";
                return View();
            }
        }

        // GET: Cuenta/Edit/5
        public ActionResult Edit(int id)
        {

            CuentaBLL cuentaBLL = new CuentaBLL();
            return View(cuentaBLL.ListarCuentas(id));
            
        }

        // POST: Cuenta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CuentaBancaria c)
        {
            try
            {
                CuentaBLL cuentaBLL = new CuentaBLL();
                c.NumeroCuenta = id;
                cuentaBLL.ModificarCuenta(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Deposito(int id)
        {
            
            return View();
        }

        // POST: Cuenta/Deposito/5
        [HttpPost]
        public ActionResult Deposito(CuentaBancaria c, int id)
        {
            try
            {
                double Deposito;
                Deposito = c.Saldo;
                MovimientoBLL movimientobll = new MovimientoBLL();
                CuentaBLL cuentaBLL = new CuentaBLL();
                if (cuentaBLL.ValidarSaldo(c) == false)
                {
                    throw new Exception();
                }
            
                c = cuentaBLL.ListarCuentas(id);
                cuentaBLL.Deposito(c, Deposito);

                Movimientos Mnuevo = new Movimientos();
                Mnuevo.CuentaBancariaDestino = c.NumeroCuenta;
                Mnuevo.CuentaBancariaOrigen = c.NumeroCuenta;
                Mnuevo.Saldo = Deposito;
                Mnuevo.Tipo = "Deposito";
                movimientobll.CrearMovimiento(Mnuevo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuenta/Extraccion/5
        public ActionResult Retiro(int id)
        {

            return View();
        }

        // POST: Cuenta/Extraccion/5
        [HttpPost]
        public ActionResult Retiro(CuentaBancaria c, int id)
        {
            try
            {
                double retiro;
                retiro = c.Saldo;
                CuentaBLL cuentaBLL = new CuentaBLL();

                if (cuentaBLL.ValidarSaldo(c) == false)
                {
                    throw new Exception();
                }
                c = cuentaBLL.ListarCuentas(id);

                if (cuentaBLL.ValidarSaldo(c,retiro) == false)
                {
                    throw new Exception();
                }

                cuentaBLL.Retiro(c,retiro);

                MovimientoBLL movimientobll = new MovimientoBLL();
                Movimientos Mnuevo = new Movimientos();
                Mnuevo.CuentaBancariaDestino = c.NumeroCuenta;
                Mnuevo.CuentaBancariaOrigen = c.NumeroCuenta;
                Mnuevo.Saldo = retiro;
                Mnuevo.Tipo = "Retiro";
                movimientobll.CrearMovimiento(Mnuevo);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }

        // GET: Cuenta/Transferencia/5
        public ActionResult Transferencia()
        {
            
            return View();
        }

        // POST: Cuenta/Edit/5
        [HttpPost]
        public ActionResult Transferencia(Movimientos t)
        {
            try
            {
                
                CuentaBLL cuentaBLL = new CuentaBLL();
                if (cuentaBLL.ValidarCuenta(cuentaBLL.ListarCuentas(t.CuentaBancariaOrigen)) == false)
                {
                    throw new Exception();
                }

                if (cuentaBLL.ValidarCuenta(cuentaBLL.ListarCuentas(t.CuentaBancariaDestino)) == false)
                {
                    throw new Exception();
                }

                if (t.CuentaBancariaDestino == t.CuentaBancariaOrigen)
                {
                    throw new Exception();
                }

                if (cuentaBLL.ValidarSaldo(cuentaBLL.ListarCuentas(t.CuentaBancariaOrigen),t.Saldo) == false)
                {
                    throw new Exception();
                }


                if (t.Saldo <= 0)
                {
                    throw new Exception();
                }


                cuentaBLL.Transferencia(cuentaBLL.ListarCuentas(t.CuentaBancariaOrigen), cuentaBLL.ListarCuentas(t.CuentaBancariaDestino), t.Saldo);
               
                MovimientoBLL movimientobll = new MovimientoBLL();
                Movimientos Mnuevo = new Movimientos();
                Mnuevo.CuentaBancariaDestino = t.CuentaBancariaDestino;
                Mnuevo.CuentaBancariaOrigen = t.CuentaBancariaOrigen;
                Mnuevo.Saldo = t.Saldo;
                Mnuevo.Tipo = "Transferencia";
                movimientobll.CrearMovimiento(Mnuevo);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Advertencia = "Alguna de las cuentas es invalida o el monto no se puede debitar de la cuenta porque sobrepasa el limite";
                return View();
            }
        }



        // GET: Cuenta/Delete/5
        public ActionResult Delete(int id)
        {
            CuentaBLL cuentaBLL = new CuentaBLL();
            return View(cuentaBLL.ListarCuentas(id));
        }

        // POST: Cuenta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CuentaBancaria c)
        {
            try
            {
                CuentaBLL cuentaBLL = new CuentaBLL();
                cuentaBLL.EliminarCuenta(cuentaBLL.ListarCuentas(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
