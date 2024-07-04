using APIPersonCreate.Domain.ValueObjects.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPersonCreate.Domain.Commands.v1
{
    public class CreatePersonCommand : IRequest<CreatePersonCommandResponse>
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
    }
}
