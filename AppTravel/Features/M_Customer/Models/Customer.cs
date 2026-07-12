using System;
using System.Collections.Generic;
using System.Text;

namespace AppTravel.Features.M_Customer.Models
{
    /// <summary>
    /// 顧客情報
    /// </summary>
    /// <param name="Code">コード</param>
    /// <param name="Name">氏名</param>
    /// <param name="MaillAddress">メールアドレス</param>
    public record Customer(
        string Code,
        string Name,
        string MaillAddress
    );
}
