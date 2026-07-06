using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppTravel.MVVM.Base
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// 変更通知を外部に送るためのイベント
        /// </summary>
        /// <remarks>MAUIのBindingは、このイベントを監視している</remarks>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// PropertyChangedイベントを発火させる
        /// </summary>
        /// <param name="propertyName">呼び出したメソッド名</param>
        /// <remarks>[CallerMemberName]は、呼び出したメソッド名を自動で入れる</remarks>
        protected void OnPropertyChanged([CallerMemberName]string? propertyName = null)
        {
            // PropertyChangedがnull出ない場合のみ、PropertyChangedEventArgsイベントを呼び出す
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 現在の値と新しい値を比較し、値が異なる場合はフィールドを更新して
        /// プロパティ変更通知を行う
        /// </summary>
        /// <typeparam name="T">フィールドおよびプロパティの型</typeparam>
        /// <param name="field">更新対象のフィールド</param>
        /// <param name="value">設定する値</param>
        /// <param name="propertyName">変更通知を行うプロパティ名</param>
        /// <returns>
        /// true: ViewModelのプロパティ値が変更された
        /// false: ViewModelのプロパティ値が変更されていない
        /// </returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName]string? propertyName = null)
        {
            // == は、同じ型同士を比較する演算子
            // ジェネリック型の場合、型に応じて適切に比較してくれるEqualityComparerを用いる
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;

            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
