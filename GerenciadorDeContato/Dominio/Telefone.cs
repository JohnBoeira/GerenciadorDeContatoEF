using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeContato.ClassLibrary.Dominio
{
    public class Telefone
    {
        public Telefone(Contato contato, int numero, int ddd)
        {
            this.contato = contato;
            this.numero = numero;
            this.ddd = ddd;
        }

        public Telefone()
        {
        }

        public Contato contato { get; set; }

        public int Id { get; set; }

        public int numero { get; set; }

        public int ddd { get; set; }
    }
}
