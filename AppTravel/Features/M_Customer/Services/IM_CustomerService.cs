using System;
using System.Collections.Generic;
using System.Text;
using AppTravel.Features.M_Customer.Dtos;

namespace AppTravel.Features.M_Customer.Services
{
    public interface IM_CustomerService
    {
        /// <summary>
        /// 画面を初期化する
        /// </summary>
        /// <returns></returns>
        M_CustomerDto Init();

    }
}
