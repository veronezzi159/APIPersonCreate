using APIPersonCreate.Domain.Entities.v1;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPersonCreate.Domain.Commands.v1
{
    public class CreateCustomerCommandProfile : Profile
    {
        public CreateCustomerCommandProfile()
        {
            CreateMap<CreatePersonCommand, Customer>()
                .ForMember(fieldOutput => fieldOutput.CPF, option => option
                    .MapFrom(input => GetOnlyNumbers(input.CPF)));

            CreateMap<Customer, CreatePersonCommandResponse>();
        }

        public static string GetOnlyNumbers(string text)
        {
            var stringNumber = new String((text ?? string.Empty).Where(Char.IsDigit).ToArray());
            return stringNumber;
        }
    }
}
