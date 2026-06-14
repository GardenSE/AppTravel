using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppTravel.Features.M_Customer.Dtos
{
    public class M_CustomerDto
    {
        /// <summary>
        /// 顧客コード
        /// </summary>
        [JsonPropertyName("customerCode")]
        public string CustomerCode {  get; set; } = string.Empty;

        /// <summary>
        /// 顧客名
        /// </summary>
        [JsonPropertyName("customerName")]
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// メールアドレス
        /// </summary>
        [JsonPropertyName("mailAddress")]
        public string MailAddress { get; set; } = string.Empty;

        /// <summary>
        /// 登録ボタン使用可否
        /// </summary>
        /// <remarks>true=使用可/false=使用不可</remarks>
        [JsonPropertyName("registerButtonEnabled")]
        public bool RegisterButtonEnabled { get; set; } = false;
        
    }
}
