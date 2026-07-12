using System;
using System.Collections.Generic;
using System.Text;
using AppTravel.Features.M_Customer.Repositories;
using AppTravel.Features.M_Customer.ViewModels;
using AppTravel.Features.M_Customer.Models;

namespace AppTravel.Features.M_Customer.Services
{
    public class M_CustomerService : IM_CustomerService
    {
        /* 外から注入したい依存は、ここでprivate変数として宣言する */
        private readonly IM_CustomerRepository _repository;

        /// <summary>
        /// コンストラクタ：つかうものを受け取る（依存性の注入）
        /// </summary>
        public M_CustomerService(IM_CustomerRepository repository)
        {
            /* 依存の注入 = private変数にコンストラクタの引数をセットする */
            _repository = repository;
        }
        
        /// <summary>
        /// 登録処理
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync(Customer customoer)
        {

            // TodDo: DBアクセス

        }

    }
}
