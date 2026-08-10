using System;
using System.Collections.Generic;
using System.Text;

namespace AppTravel.Features.M_Customer.Dtos
{
    /// <summary>
    /// 顧客登録情報
    /// </summary>
    /// <param name="Code">顧客コード</param>
    /// <param name="LastName">顧客氏名（姓）</param>
    /// <param name="FirstName">顧客氏名（名）</param>
    /// <param name="LastNameKana">顧客氏名（姓・カナ）</param>
    /// <param name="FirstNameKana">顧客氏名（名・カナ）</param>
    /// <param name="MaillAddress">メールアドレス</param>
    public record CustomerRegister(
        string Code,
        string LastName,
        string FirstName,
        string LastNameKana, 
        string FirstNameKana,
        string MaillAddress
    );
}
