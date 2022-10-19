using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfContas.Classe;

namespace WpfContas._Repo
{
    public class BdConfig
    {
        private string db = "postgres";
        private string _connectionString;
        public BdConfig()
        {
        }

        protected DbConnection conectar()
        {
            if(db == "postgres"){
                _connectionString = "Host=127.0.0.1; Username=postgres; Password=admin;";

                return new NpgsqlConnection(_connectionString);
            }
            else
            {
                _connectionString = "Server=(local); Database=ContasDb; Integrated Security=true;";

                return new SqlConnection(_connectionString);
            }
        }

        protected DbCommand comando()
        {
            if(db == "postgres")
            {
                MessageBox.Show("Conectado ao Postgres!");
                return new NpgsqlCommand();
            }
            else
            {
                MessageBox.Show("Conectado ao SQL Server!");
                return new SqlCommand();
            }
        }
    }
}
