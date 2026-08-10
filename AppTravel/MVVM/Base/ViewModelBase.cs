using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppTravel.MVVM.Base
{
    public abstract partial class ViewModelBase : ObservableObject, IQueryAttributable
    {
        #region <画面に表示する値/画面から変更される値/画面操作に対応する状態>
        /// <summary>
        /// 実行中フラグ
        /// </summary>
        /// <remarks>true:実行中/false:実行中ではない</remarks>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool _isBusy;

        /// <summary>
        /// 画面タイトル
        /// </summary>
        [ObservableProperty]
        private string _title = string.Empty;


        #endregion

        #region <フィールド>
        /// <summary>
        /// 実行中ではないフラグ
        /// </summary>
        public bool IsNotBusy => !IsBusy;

        /// <summary>
        /// ダブルタップ防止フラグ
        /// </summary>
        private bool _isExecuting;
        #endregion

        #region <コンストラクタ>
        public ViewModelBase() 
        { 
            try
            {

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        
        }
        #endregion

        #region <ApplyQueryAttributes : ナビゲーションパラメータを受け取る>
        /// <summary>
        /// 派生クラスでオーバーライドしてナビゲーションパラメータを受け取る
        /// </summary>
        /// <param name="query"></param>
        public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
        {

        }
        #endregion

        #region <ExecuteAsync : 多重タップを防止しながら非同期処理を時刻する>
        /// <summary>
        /// 多重タップを防止しながら非同期処理を実行する
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        protected async Task ExecuteAsync(Func<Task> operation)
        {
            if (_isExecuting || IsBusy) return;

            IsBusy = true;
            try
            {
                await operation();
            }
            catch(Exception ex)
            {
                await OnUnhandledExceptionAsync(ex);
            }
            finally
            {
                IsBusy = false;
                _isExecuting = false;
            }
        }
        #endregion

        #region <OnUnhandledExceptionAsync : 例外が発生したとき、非同期処理をデタッチする>
        /// <summary>
        /// 例外が発生したとき、非同期処理をデタッチする
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected virtual Task OnUnhandledExceptionAsync(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[{GetType().Name}] Unhandled: {ex}");
            return Task.CompletedTask;
        }
        #endregion

        #region <NavigateToAsync : パラメータが渡された場合、パラメータ付で画面遷移する>
        /// <summary>
        /// パラメータが渡された場合、パラメータ付で画面遷移する
        /// </summary>
        /// <param name="route">遷移先</param>
        /// <param name="parameters">パラメータ</param>
        /// <returns></returns>
        protected static Task NavigateToAsync(string route, Dictionary<string, object>? parameters = null)
        {
            return parameters is null
                    ? Shell.Current.GoToAsync(route)
                    : Shell.Current.GoToAsync(route, parameters);
        }
        #endregion

        #region <NavigateBackAsync : 前画面に戻る>
        /// <summary>
        /// 前画面に戻る
        /// </summary>
        /// <returns></returns>
        protected static Task NavigateBackAsync()
        {
            return Shell.Current.GoToAsync("..");
        }
        #endregion

        #region <DisplayAlertAsync : アラートダイアログを表示する>
        /// <summary>
        /// アラートダイアログを表示する
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        protected static Task DisplayAlertAsync(string title, string message, string cancel = "OK")
        {
            return Shell.Current.DisplayAlertAsync(title, message, cancel);
        }
        #endregion

        #region <DisplayConfirmAsync : 確認ダイアログを表示する>
        /// <summary>
        /// 確認ダイアログを表示する
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="accept"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        protected static Task<bool> DisplayConfirmAsync(string title, string message, string accept = "はい", string cancel = "いいえ")
        {
            return Shell.Current.DisplayAlertAsync(title, message, accept, cancel);
        }
        #endregion
    }
}
