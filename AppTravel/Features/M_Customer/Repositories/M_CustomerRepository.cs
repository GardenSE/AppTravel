using System;
using System.Collections.Generic;
using System.Text;
using AppTravel.Features.M_Customer.Dtos;
using AppTravel.Features.M_Customer.Models;

namespace AppTravel.Features.M_Customer.Repositories
{
    public class M_CustomerRepository : IM_CustomerRepository
    {
        public Task SaveAsync(CustomerRegister customerRegister)
        {
            // ToDo: DBアクセス
            return Task.CompletedTask;
        }
    }
}
