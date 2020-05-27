using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParcialSAP.EE;

namespace ParcialSAP.DAL
{
    public class MovimientoDAL
    {

        public List<Movimientos> ListarMovimientos()
        {
            SqlConnection conString = new SqlConnection(@"Data Source=DESKTOP-6DRGPE6;Initial Catalog=ParcialSAP;Integrated Security=True");
            List<Movimientos> Movimiento = new List<Movimientos>();
            try
            {
                conString.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conString;
                command.CommandText = "select * from Movimientos";
                command.CommandType = System.Data.CommandType.Text;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Movimientos c = new Movimientos();
                    c.CuentaBancariaDestino = Int32.Parse(reader["CuentaBancariaDestino"].ToString());
                    c.CuentaBancariaOrigen = Int32.Parse(reader["CuentaBancariaOrigen"].ToString());
                    c.Saldo = float.Parse(reader["Saldo"].ToString());
                    c.Tipo = string.Format(reader["Tipo"].ToString());
                    Movimiento.Add(c);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conString.Close();
            }
            return Movimiento;
        }

        public void CrearMovimiento(Movimientos Movimiento)
        {
            SqlConnection conString = new SqlConnection(@"Data Source=DESKTOP-6DRGPE6;Initial Catalog=ParcialSAP;Integrated Security=True");
            try
            {
                conString.Open();
                SqlTransaction transaction;
                transaction = conString.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = conString;
                command.Parameters.AddWithValue("Saldo", Movimiento.Saldo);
                command.Parameters.AddWithValue("CuentaBancariaDestino", Movimiento.CuentaBancariaDestino);
                command.Parameters.AddWithValue("CuentaBancariaOrigen", Movimiento.CuentaBancariaOrigen);
                command.Parameters.AddWithValue("Tipo", Movimiento.Tipo);
                command.CommandText = "insert into Movimientos (Saldo, CuentaBancariaDestino, CuentaBancariaOrigen, Tipo) values (@Saldo, @CuentaBancariaDestino, @CuentaBancariaOrigen, @Tipo)";
                command.CommandType = System.Data.CommandType.Text;
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conString.Close();
            }
        }

    }
}
