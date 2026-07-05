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

        #region <画面に表示する値/画面から変更される値/画面操作に対応する状態> 
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
        #endregion


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="service"></param>
        public M_CustomerViewModel(IM_CustomerService service) 
        {
            _service = service;

        }

        #region <画面操作に対応する処理>
        /// <summary>
        /// 登録
        /// </summary>
        /// <returns>true=保存可能/false=保存不可</returns>
        /// <remarks>顧客コード、顧客名、メールアドレスが全て入力されている時、保存可能</remarks>
        public bool CanSave() =>
            !string.IsNullOrEmpty(CustomerCode)
            && !string.IsNullOrEmpty(CustomerName)
            && !string.IsNullOrEmpty(MailAddress);
        #endregion
    }
}
