using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfContas.Classe;

namespace WpfContas._Repo
{
    public class UsuarioRepo : BdConfig, IUsuario
    {
        public UsuarioRepo()
        {
        }

        public void Create(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentException("ERRO!");
            }
            using (DbConnection connection = conectar())
            using (DbCommand command = comando())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"INSERT INTO contasdb(Contas_Nome, Contas_Valor, Contas_Desc) " +
                    $"VALUES ('{usuario.Nome}', '{usuario.Valor}', '{usuario.Observacao}')";

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("ERRO");
                }
            }
        }

        public ObservableCollection<Usuario> Consulta()
        {
            using (DbConnection connection = conectar())
            using (DbCommand command = comando())

            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * From contasdb order by contas_id";

                var reader = command.ExecuteReader();

                ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = reader.GetInt32(0);
                    usuario.Nome = reader.GetString(1);
                    usuario.Valor = reader.GetString(2);
                    usuario.Observacao = reader.GetString(3);

                    usuarios.Add(usuario);
                }
                return usuarios;
            }
        }

        public void EditU(Usuario usuario)
        {
            if (usuario == null) {
                throw new ArgumentException("ERRO!");
            }
            using (DbConnection connection = conectar())
            using (DbCommand command = comando())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"Update contasdb set " +
                    $"Contas_Nome = '{usuario.Nome}', Contas_Valor = '{usuario.Valor}', Contas_Desc = '{usuario.Observacao}' Where Contas_Id = '{usuario.Id}'";

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("ERRO");
                }
            }
        }

        public void DeleteU(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentException("ERRO!");
            }
            using (DbConnection connection = conectar())
            using (DbCommand command = comando())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"Delete from contasdb Where Contas_Id = '{usuario.Id}'";

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("ERRO");
                }
            }
        }
    }
}
