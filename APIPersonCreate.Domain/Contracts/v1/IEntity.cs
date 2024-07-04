using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPersonCreate.Domain.Contracts.v1
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
