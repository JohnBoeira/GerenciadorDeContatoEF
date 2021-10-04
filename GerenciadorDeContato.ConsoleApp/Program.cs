using GerenciadorDeContato.ClassLibrary.Dominio;
using GerenciadorDeContato.ClassLibrary.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeContato.ConsoleApp
{
    class Program
    {
        static DominioContext dominioContext;
        static void Main(string[] args)
        {
            dominioContext = new DominioContext();

            Contato contato = new Contato("Nome", new List<Telefone>(), "Rua sei la");
            InserirContato();

            dominioContext.SaveChanges();
        }

        public static void InserirContato()
        {
            Contato contato = new Contato("Nome", new List<Telefone>(), "Rua abc");

            Telefone telefone = new Telefone(contato, 123123123, 123123);

            contato.Telefones.Add(telefone);

            dominioContext.Contatos.Add(contato);
            dominioContext.Telefones.Add(telefone);

        }
        public static List<Contato> SelecionarContatos()
        {
            return dominioContext.Contatos.ToList();

        }
        public static Contato SelecionarContatoPorID(int id)
        {
            return dominioContext.Contatos.ToList().Find(x => x.Id == id);

        }
        public static void EditarContato(Contato contatoNovo, int id)
        {
            Contato contatoVeio = SelecionarContatoPorID(id);
            contatoNovo.Id = id;

            dominioContext.Entry(contatoVeio).CurrentValues.SetValues(contatoNovo);

        }
        public static void ExcluirContato(int id)
        {
            Contato contato = SelecionarContatoPorID(id);

            dominioContext.Contatos.Remove(contato);

        }
    }
}
