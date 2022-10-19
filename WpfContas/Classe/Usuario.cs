using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfContas._Repo;
using WpfContas.Classe;

namespace WpfContas
{
    public class Usuario : UsuarioRepo
    {
        private int id;
        private string nome;
        private string valor;
        private string observacao;
        public Usuario()
        {

        }
        public Usuario(string nome, string valor, string observacao)
        {
            this.nome = nome;
            this.valor = valor;
            this.observacao = observacao;
        }

        public int Id { get { return id; } set { id = value;  } }
        public string Nome { get { return nome; } set { nome = value; Roberto.Notifica("Nome"); } }
        public string Valor { get { return valor; } set { valor = value; Roberto.Notifica("Valor"); } }
        public string Observacao { get { return observacao; } set { observacao = value; Roberto.Notifica("Observacao"); } }

        public void Add() => Create(this);
        public void Edit() => EditU(this);
        public void Delete() => DeleteU(this);

        public ObservableCollection<Usuario> Consulta1() => Consulta();

        public PropertyChange Roberto = new PropertyChange();

        public Usuario Clone()
        {
            return (Usuario)this.MemberwiseClone();
        }

        public void AtualizarLista(Usuario novoUsuario)
        {
            Usuario newUser = novoUsuario;
            Nome = newUser.Nome;
            Valor = newUser.Valor;
            Observacao = newUser.Observacao;
        }

    }
}
