using System;
using System.Collections.Generic;
using System.Text;
using AppTravel.Features.M_Customer.Dtos;

namespace AppTravel.Features.M_Customer.Repositories
{
    public interface IM_CustomerRepository
    {
        Task SaveAsync(CustomerRegister customerRegister);
    }
}
