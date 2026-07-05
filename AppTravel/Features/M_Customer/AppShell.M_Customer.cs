using System;
using System.Collections.Generic;
using System.Text;
using AppTravel.Features.M_Customer.Views;

namespace AppTravel
{
   public partial class AppShell
    {
        /// <summary>
        /// 顧客登録画面をルートに登録する
        /// </summary>
        private static void RegisterRoutesM_Customer()
        {
            Routing.RegisterRoute(nameof(M_CustomerPage), typeof(M_CustomerPage));
        }
    }
}
