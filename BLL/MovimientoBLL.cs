using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParcialSAP.EE;
using ParcialSAP.DAL;

namespace ParcialSAP.BLL
{
    public class MovimientoBLL
    {
        public List<Movimientos> ListarMovimientos()
        {
            List<Movimientos> Movimiento = new List<Movimientos>();
            try
            {
                MovimientoDAL MovimientoDAL = new MovimientoDAL();
                Movimiento = MovimientoDAL.ListarMovimientos();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Movimiento;
        }

        public void CrearMovimiento(Movimientos c)
        {
            try
            {
                MovimientoDAL MovimientoDAL = new MovimientoDAL();
                MovimientoDAL.CrearMovimiento(c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
