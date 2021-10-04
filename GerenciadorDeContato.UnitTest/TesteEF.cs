using GerenciadorDeContato.ClassLibrary.Dominio;
using GerenciadorDeContato.ClassLibrary.Infraestrutura;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GerenciadorDeContato.UnitTest
{
    [TestClass]
    public class TesteEF
    {
        [TestMethod]
        public void DeveInserirNoBanco()
        {
            Contato contato = new Contato("Nome", new List<Telefone>(), "Rua abc");

            Telefone telefone = new Telefone(contato, 123123123, 123123);

            contato.Telefones.Add(telefone);

            //DominioContext.Contatos.Add(contato);
            //DominioContext.Telefones.Add(telefone);
        }
    }
}
