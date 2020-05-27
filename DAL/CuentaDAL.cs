using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParcialSAP.EE;

namespace ParcialSAP.DAL
{
    public class CuentaDAL
    {
        public List<CuentaBancaria> ListarCuentas()
        {
            SqlConnection conString = new SqlConnection(@"Data Source=DESKTOP-6DRGPE6;Initial Catalog=ParcialSAP;Integrated Security=True");
            List<CuentaBancaria> cuentas = new List<CuentaBancaria>();
            try
            {
                conString.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conString;
                command.CommandText = "select * from CuentaBancaria";
                command.CommandType = System.Data.CommandType.Text;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CuentaBancaria c = new CuentaBancaria();
                    c.NumeroCuenta = Int32.Parse(reader["NumeroCuenta"].ToString());
                    c.Saldo = float.Parse(reader["Saldo"].ToString());
                    c.Propietario = string.Format(reader["Propietario"].ToString());
                    c.TipoCuentaBancaria = buscarTipoCuenta(Int32.Parse(reader["TipoCuentaBancaria"].ToString()));
                    cuentas.Add(c);
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
            return cuentas;
        }
        public CuentaBancaria ListarCuentas(int NumeroCuenta)
        {
            SqlConnection conString = new SqlConnection(@"Data Source=DESKTOP-6DRGPE6;Initial Catalog=ParcialSAP;Integrated Security=True");
            CuentaBancaria c = new CuentaBancaria();
            try
            {
                conString.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conString;
                command.Parameters.AddWithValue("NumeroCuenta", NumeroCuenta);
                command.CommandText = "select * from CuentaBancaria where NumeroCuenta = @NumeroCuenta";
                command.CommandType = System.Data.CommandType.Text;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    c.NumeroCuenta = Int32.Parse(reader["NumeroCuenta"].ToString());
                    c.Saldo = float.Parse(reader["Saldo"].ToString());
                    c.TipoCuentaBancaria = buscarTipoCuenta(Int32.Parse(reader["TipoCuentaBancaria"].ToString()));
                    c.Propietario = string.Format(reader["Propietario"].ToString());
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
            return c;
        }
        public TipoCuentaBancaria buscarTipoCuenta(int Codigo)
        {
            SqlConnection conString = new SqlConnection(@"Data Source=DESKTOP-6DRGPE6;Initial Catalog=ParcialSAP;Integrated Security=True");
            TipoCuentaBancaria tc = new TipoCuentaBancaria();
            try
            {
                conString.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conString;
                command.Parameters.AddWithValue("Codigo", Codigo);
                command.CommandText = "select nombre from TipoCuentaBancaria where Codigo = @Codigo";
                command.CommandType = System.Data.CommandType.Text;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tc.Codigo = Codigo;
                    tc.Nombre = reader["Nombre"].ToString();
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
            return tc;
        }
        public void CrearCuenta(CuentaBancaria CuentaBancaria)
        {
            SqlConnection conString = new SqlConnection(@"Data Source=DESKTOP-6DRGPE6;Initial Catalog=ParcialSAP;Integrated Security=True");
            try
            {
                conString.Open();
                SqlTransaction transaction;
                transaction = conString.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = conString;
                command.Parameters.AddWithValue("Saldo", CuentaBancaria.Saldo);
                command.Parameters.AddWithValue("TipoCuentaBancaria", CuentaBancaria.TipoCuentaBancaria.Codigo);
                command.Parameters.AddWithValue("Propietario", CuentaBancaria.Propietario);
                command.Parameters.AddWithValue("NumeroCuenta", CuentaBancaria.NumeroCuenta);
                command.CommandText = "insert into CuentaBancaria (Saldo, TipoCuentaBancaria, Propietario, NumeroCuenta) values (@Saldo, @TipoCuentaBancaria, @Propietario, @NumeroCuenta)";
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
        public void ModificarCuenta(CuentaBancaria CuentaBancaria)
        {
            SqlConnection conString = new SqlConnection(@"Data Source=DESKTOP-6DRGPE6;Initial Catalog=ParcialSAP;Integrated Security=True");
            try
            {
                conString.Open();
                SqlTransaction transaction;
                transaction = conString.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = conString;
                command.Parameters.AddWithValue("NumeroCuenta", CuentaBancaria.NumeroCuenta);
                command.Parameters.AddWithValue("Saldo", CuentaBancaria.Saldo);
                command.Parameters.AddWithValue("Propietario", CuentaBancaria.Propietario);
                command.CommandText = "update CuentaBancaria set Saldo = @Saldo, Propietario = @Propietario where NumeroCuenta = @NumeroCuenta";
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

        public void EliminarCuenta(CuentaBancaria CuentaBancaria)
        {
            SqlConnection conString = new SqlConnection(@"Data Source=DESKTOP-6DRGPE6;Initial Catalog=ParcialSAP;Integrated Security=True");
            try
            {
                conString.Open();
                SqlTransaction transaction;
                transaction = conString.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = conString;
                command.Parameters.AddWithValue("NumeroCuenta", CuentaBancaria.NumeroCuenta);
                command.CommandText = "delete CuentaBancaria where NumeroCuenta = @NumeroCuenta";
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
        //public void registrarDeposito(CuentaBancaria c)
        //{
        //    SqlConnection conString = new SqlConnection(@"Data Source=DESKTOP-6DRGPE6;Initial Catalog=ParcialSAP;Integrated Security=True");
        //    try
        //    {
        //        CuentaBancaria c_original = new CuentaBancaria();
        //        c_original = traerCuenta(c.NumeroCuenta);
        //        c.Saldo = c_original.saldo + c.saldo;
        //        conString.Open();
        //        SqlTransaction transaction;
        //        transaction = conString.BeginTransaction();
        //        SqlCommand command = new SqlCommand();
        //        command.Connection = conString;
        //        command.Parameters.AddWithValue("nro_cuenta", c.nro_cuenta);
        //        command.Parameters.AddWithValue("saldo", c.saldo);
        //        command.CommandText = "update Cuenta set saldo = @saldo where nro_cuenta = @nro_cuenta";
        //        command.CommandType = System.Data.CommandType.Text;
        //        command.Transaction = transaction;
        //        command.ExecuteNonQuery();
        //        transaction.Commit();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    finally
        //    {
        //        conString.Close();
        //    }
        //}
        //public void registrarExtraccion(CuentaBancaria c)
        //{
        //    SqlConnection conString = new SqlConnection(@"Data Source=DESKTOP-6DRGPE6;Initial Catalog=ParcialSAP;Integrated Security=True");
        //    try
        //    {
        //        CuentaBancaria c_original = new CuentaBancaria();
        //        c_original = traerCuenta(c.nro_cuenta);

        //        if (c.tipo.nro_tipo == 1)
        //        {
        //            if (c_original.saldo - c.saldo >= 0)
        //            {
        //                c.saldo = c_original.saldo - c.saldo;
        //            }
        //            else
        //            {
        //                c.saldo = c_original.saldo;
        //            }
        //        }
        //        else
        //        {
        //            c.saldo = c_original.saldo - c.saldo;
        //        }
        //        conString.Open();
        //        SqlTransaction transaction;
        //        transaction = conString.BeginTransaction();
        //        SqlCommand command = new SqlCommand();
        //        command.Connection = conString;
        //        command.Parameters.AddWithValue("nro_cuenta", c.nro_cuenta);
        //        command.Parameters.AddWithValue("saldo", c.saldo);
        //        command.CommandText = "update Cuenta set saldo = @saldo where nro_cuenta = @nro_cuenta";
        //        command.CommandType = System.Data.CommandType.Text;
        //        command.Transaction = transaction;
        //        command.ExecuteNonQuery();
        //        transaction.Commit();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    finally
        //    {
        //        conString.Close();
        //    }
        //}
        public List<TipoCuentaBancaria> buscarTipos()
        {
            SqlConnection conString = new SqlConnection(@"Data Source=DESKTOP-6DRGPE6;Initial Catalog=ParcialSAP;Integrated Security=True");
            List<TipoCuentaBancaria> tc = new List<TipoCuentaBancaria>();
            try
            {
                conString.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conString;
                command.CommandText = "select * from TipoCuentaBancaria";
                command.CommandType = System.Data.CommandType.Text;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TipoCuentaBancaria t = new TipoCuentaBancaria();
                    t.Codigo = Int32.Parse(reader["Codigo"].ToString());
                    t.Nombre = reader["Nombre"].ToString();
                    tc.Add(t);
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
            return tc;
        }
    }
}
