using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace WpfContas
{
    public class MainWindowVM
    {
        public ObservableCollection<Usuario> listaUsuarios { get; set; }

        //ICommand é a abstração.
        public ICommand Add { get; private set; }
        public ICommand Remove { get; private set; }
        public ICommand Editar { get; private set; }
        public ICommand show { get; private set; }

        public Usuario UsuarioSelecionado { get; set; }
        public MainWindowVM()
        {
            listaUsuarios = new ObservableCollection<Usuario>()
            {
            };
            IniciaComandos();
        }
        public void IniciaComandos()
        {
            Usuario kleber = new Usuario();
            listaUsuarios = kleber.Consulta1();

            Add = new RelayCommand((object _) =>
            {
                Usuario userCadastro = new Usuario();

                EditAddUsuario tela = new EditAddUsuario();
                tela.DataContext = userCadastro;
                tela.ShowDialog();
                userCadastro.Add();
                listaUsuarios.Add(userCadastro);
            });

            Remove = new RelayCommand((object _) =>
            {
                UsuarioSelecionado.Delete();
                listaUsuarios.Remove(UsuarioSelecionado);
                MessageBox.Show("Deletado com Sucesso!");
            });

            Editar = new RelayCommand((object _) =>
            {
                Usuario novoUsu = new Usuario();
                if (UsuarioSelecionado != null)
                {
                    EditAddUsuario novaTela = new EditAddUsuario();
                    novoUsu = UsuarioSelecionado.Clone();
                    novaTela.DataContext = novoUsu;
                    bool? verifica = novaTela.ShowDialog();
                    if(verifica.HasValue && verifica.Value)
                    {
                        UsuarioSelecionado.AtualizarLista(novoUsu);
                        UsuarioSelecionado.Edit();

                        MessageBox.Show("Salvo com Sucesso!");
                    }
                }
            });
        }
    }
}
