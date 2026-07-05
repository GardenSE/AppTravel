using System;
using System.Collections.Generic;
using System.Text;
using AppTravel.Features.M_Customer.Dtos;
using AppTravel.Features.M_Customer.ViewModels;

namespace AppTravel.Features.M_Customer.Services
{
    public class M_CustomerService : IM_CustomerService
    {
        /* 外から注入したい依存は、ここでprivate変数として宣言する */


        /// <summary>
        /// コンストラクタ：つかうものを受け取る（依存性の注入）
        /// </summary>
        public M_CustomerService()
        {
            /* 依存の注入 = private変数にコンストラクタの引数をセットする */
        }
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
