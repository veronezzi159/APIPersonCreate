using APIPersonCreate.Domain.Contracts.v1;
using APIPersonCreate.Domain.ValueObjects.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPersonCreate.Domain.Entities.v1
{
    public class Customer : IEntity<Guid>
    {
        //Nome, CPF, Data de Nascimento, Endereço, Telefone e Emai
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }

        public Customer()
        {
            Id = Guid.NewGuid();
        }
    }
}
