using APIPersonCreate.Domain.Contracts.v1;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPersonCreate.Domain.Entities.v1;

namespace APIPersonCreate.Domain.Commands.v1
{
    public class CreatePersonCommandHandler(ICustomerRepository repository, IMapper mapper, IDomainNotificationService notificationService)
    : IRequestHandler<CreatePersonCommand, CreatePersonCommandResponse>
    {
        
        public async Task<CreatePersonCommandResponse> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var customer = mapper.Map<Customer>(request);
            await repository.AddAsync(customer, cancellationToken);
            

            return mapper.Map<CreatePersonCommandResponse>(customer);
        }
    }
}
