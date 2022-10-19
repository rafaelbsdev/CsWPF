using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfContas._Repo
{
    public interface IUsuario
    {
        void Create(Usuario usuario);
        void EditU(Usuario usuario);
        void DeleteU(Usuario usuario);
        ObservableCollection<Usuario> Consulta();
    }
}
