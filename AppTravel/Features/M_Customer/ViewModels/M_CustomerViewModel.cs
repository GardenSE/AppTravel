using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using AppTravel.Features.M_Customer.Dtos;
using AppTravel.Features.M_Customer.Services;

namespace AppTravel.Features.M_Customer.ViewModels
{
    public class M_CustomerViewModel
    {
        private readonly IM_CustomerService _service;

        /// <summary>
        /// 顧客コード
        /// </summary>
        public string CustomerCode { get; set; } = string.Empty;

        /// <summary>
        /// 顧客名
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// メールアドレス
        /// </summary>
        public string MailAddress { get; set; } = string.Empty;

        /// <summary>
        /// 登録ボタン使用可否
        /// </summary>
        /// <remarks>true=使用可/false=使用不可</remarks>
        public bool RegisterButtonEnabled { get; set; } = false;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="service"></param>
        public M_CustomerViewModel(IM_CustomerService service) 
        {
            _service = service;

        }


        /// <summary>
        /// 登録
        /// </summary>
        /// <returns></returns>
        public bool CanSave() =>
            !string.IsNullOrEmpty(CustomerCode)
            && !string.IsNullOrEmpty(CustomerName)
            && !string.IsNullOrEmpty(MailAddress);
    }
}
