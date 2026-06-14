using System;
using System.Collections.Generic;
using System.Text;
using AppTravel.Features.M_Customer.Dtos;
using AppTravel.Features.M_Customer.ViewModels;

namespace AppTravel.Features.M_Customer.Services
{
    public class M_CustomerService
    {
        /// <summary>
        /// 画面を初期化する
        /// </summary>
        /// <returns></returns>
        public M_CustomerDto Init()
        {
            M_CustomerDto m_CustomerDto = new();

            return m_CustomerDto;
        }
    }
}
