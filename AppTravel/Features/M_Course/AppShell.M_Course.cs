using System;
using System.Collections.Generic;
using System.Text;
using AppTravel.Features.M_Course.Views;

namespace AppTravel
{
    /// <summary>
    /// M_Curse：コース登録画面をルート登録するためのクラス
    /// </summary>
    /// <remarks>
    /// AppShell.xaml.csで呼び出す
    /// </remarks>
    public partial class AppShell
    {
        /// <summary>
        /// コース登録画面をルートに登録する
        /// </summary>
        private static void RegisterRoutesM_Course()
        {
            Routing.RegisterRoute(nameof(M_Course), typeof(M_Course));
        }
    }
}
