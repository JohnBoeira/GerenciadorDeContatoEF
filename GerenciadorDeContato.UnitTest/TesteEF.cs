using GerenciadorDeContato.ClassLibrary.Dominio;
using GerenciadorDeContato.ClassLibrary.Infraestrutura;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeContato.UnitTest
{
    [TestClass]
    public class TesteEF
    {
        DominioContext dominioContext;
        public TesteEF()
        {
            dominioContext = new DominioContext();

        }

        [TestMethod]
        public void DeveInserirContatoNoBanco()
        {
            Contato contato = new Contato("Nome", new List<Telefone>(), "Rua abc");

            Telefone telefone = new Telefone(contato, 123123123, 123123);

            contato.Telefones.Add(telefone);

            dominioContext.Contatos.Add(contato);
            dominioContext.Telefones.Add(telefone);

            dominioContext.SaveChanges();

            Assert.AreEqual(contato, dominioContext.Contatos.ToList().Find(x => x.Id == contato.Id));
            dominioContext.Contatos.Remove(contato);
        }
        [TestMethod]
        public void DeveEditarContatoNoBanco()
        {
            Contato contato = new Contato("Nome", new List<Telefone>(), "Rua abc");

            Telefone telefone = new Telefone(contato, 123123123, 123123);

            contato.Telefones.Add(telefone);

            dominioContext.Contatos.Add(contato);
            dominioContext.Telefones.Add(telefone);
            dominioContext.SaveChanges();
            //editando
            contato.Nome = "Novo nome";
            
            var status = dominioContext.ChangeTracker.Entries().ToList()[0];
            Assert.AreEqual("Modified", status.State.ToString());
            dominioContext.SaveChanges();
            Assert.AreEqual(contato, dominioContext.Contatos.ToList().Find(x => x.Id == contato.Id));
        }

        [TestMethod]
        public void DeveRemoverContatoNoBanco()
        {
            Contato contato = new Contato("Nome", new List<Telefone>(), "Rua abc");

            Telefone telefone = new Telefone(contato, 123123123, 123123);

            contato.Telefones.Add(telefone);

            dominioContext.Contatos.Add(contato);
            dominioContext.Telefones.Add(telefone);
            dominioContext.SaveChanges();
            //exclui
            int id = contato.Id;
            dominioContext.Contatos.Remove(contato);

            dominioContext.SaveChanges();

            Assert.AreEqual(null, dominioContext.Contatos.ToList().Find(x => x.Id == id));

        }
    }
}
