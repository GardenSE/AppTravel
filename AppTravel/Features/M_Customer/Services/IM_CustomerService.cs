using System;
using System.Collections.Generic;
using System.Text;
using AppTravel.Features.M_Customer.Dtos;

namespace AppTravel.Features.M_Customer.Services
{
    public interface IM_CustomerService
    {
        Task SaveAsync(CustomerRegister customerRegister);
    }
}
