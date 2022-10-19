using Autofac.Extras.Moq;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using System.Collections.ObjectModel;
using WpfContas;
using WpfContas._Repo;
using WpfContas.Classe;


namespace TestProject
{
    public class UsuarioIntegracao
    {

        private ObservableCollection<Usuario> MockContas()
        {
            ObservableCollection<Usuario> output = new ObservableCollection<Usuario>
            {
                new Usuario
                {
                    Nome = "Robson Kleber",
                    Valor = "R$150,00",
                    Observacao = "Gasolina - 18/10/22",
                },
                new Usuario
                {
                    Nome = "Rafa Belo",
                    Valor = "R$50,00",
                    Observacao = "Sushi IFood - 18/10/22",
                },
            };
            return output;
        }

        [Fact]
        public void TestBusca()
        {
            Mock<IUsuario> MockDb = new Mock<IUsuario>();
            MockDb.Setup(x => x.Consulta()).Returns(MockContas());

            ObservableCollection<Usuario> kleber = new ObservableCollection<Usuario>();

            kleber = MockDb.Object.Consulta();

            ObservableCollection<Usuario> ResultadoEsperado = MockContas();

            ObservableCollection<Usuario> ResultadoAtual = kleber;

            Assert.NotNull(ResultadoAtual);

            Assert.Equal(ResultadoAtual.Count, ResultadoEsperado.Count);

            for (int i = 0; i < ResultadoEsperado.Count; i++)
            {
                Assert.Equal(ResultadoEsperado[i].Nome, ResultadoAtual[i].Nome);
                Assert.Equal(ResultadoEsperado[i].Valor, ResultadoAtual[i].Valor);
                Assert.Equal(ResultadoEsperado[i].Observacao, ResultadoAtual[i].Observacao);
            }
        }

        [Fact]
        public void TestInsertFoul()
        {
            Mock<UsuarioRepo> mockDb = new Mock<UsuarioRepo>();

            Usuario usu = null;

            ArgumentException err = Assert.Throws<ArgumentException>(() => mockDb.Object.Create(usu));

            Assert.Equal("ERRO!", err.Message);
        }

        [Fact]
        public void TestInsert()
        {
            Mock<IUsuario> MockDb = new Mock<IUsuario>();

            var usuario = MockContas()[0];

            MockDb.Setup(x => x.Create(usuario));

            MockDb.Object.Create(usuario);

            MockDb.Verify(x => x.Create(usuario), Times.Exactly(1));
        }

        [Fact]
        public void TestUpdate()
        {
            Mock<IUsuario> MockDb = new Mock<IUsuario>();

            var usuario = MockContas()[0];

            MockDb.Setup(x => x.EditU(usuario));

            MockDb.Object.EditU(usuario);

            MockDb.Verify(x => x.EditU(usuario), Times.Exactly(1));
        }

        [Fact]
        public void TestUpdateFoul()
        {
            Mock<UsuarioRepo> mockDb = new Mock<UsuarioRepo>();

            Usuario usu = null;

            ArgumentException err = Assert.Throws<ArgumentException>(() => mockDb.Object.EditU(usu));

            Assert.Equal("ERRO!", err.Message);
        }

        [Fact]
        public void TestDelete()
        {
            Mock<IUsuario> MockDb = new Mock<IUsuario>();

            var usuario = MockContas()[0];

            MockDb.Setup(x => x.DeleteU(usuario));

            MockDb.Object.DeleteU(usuario);

            MockDb.Verify(x => x.DeleteU(usuario), Times.Exactly(1));
        }

        [Fact]
        public void TestDeleteFoul()
        {
            Mock<UsuarioRepo> mockDb = new Mock<UsuarioRepo>();

            Usuario usu = null;

            ArgumentException err = Assert.Throws<ArgumentException>(() => mockDb.Object.DeleteU(usu));

            Assert.Equal("ERRO!", err.Message);
        }
    }
}