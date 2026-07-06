using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AppTravel.MVVM.Command
{
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// 実行するコマンド
        /// </summary>
        private readonly Action _execute;

        /// <summary>
        /// コマンドを実行して良いか、判定するメソッド
        /// </summary>
        /// <remarks>
        /// true: 実行OK
        /// false: 実行NG
        /// </remarks>
        private readonly Func<bool>? _canExecute;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="execute">戻り値がないメソッド</param>
        /// <param name="canExecute">戻り値を返すメソッド</param>
        /// <remarks>
        /// Action型は、戻り値がないメソッドを変数として持った型
        /// Function<T>型は、戻り値<T>を返すメソッドを変数として持った型
        /// </remarks>
        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// 登録された判定メソッドを実行する
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <remarks>判定メソッドが登録されていない場合は、常にtrueを返す</remarks>
        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        /// <summary>
        /// 登録された処理を実行する
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            _execute();
        }

        /// <summary>
        /// CanExecuteをもう一度呼ぶための変更通知
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// 
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }   
    }
}
