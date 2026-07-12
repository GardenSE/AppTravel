using System;
using System.Collections.Generic;
using System.Text;
using AppTravel.Features.M_Customer.Models;

namespace AppTravel.Features.M_Customer.Repositories
{
    public interface IM_CustomerRepository
    {
        Task SaveAsync(Customer customer);
    }
}
