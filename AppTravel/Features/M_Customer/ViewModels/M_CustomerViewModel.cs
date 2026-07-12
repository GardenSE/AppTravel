using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using AppTravel.Features.M_Customer.Models;
using AppTravel.Features.M_Customer.Services;
using AppTravel.MVVM.Base;
using AppTravel.MVVM.Command;

namespace AppTravel.Features.M_Customer.ViewModels
{
    public class M_CustomerViewModel : ViewModelBase
    {
        private readonly IM_CustomerService _service;

        #region <画面に表示する値/画面から変更される値/画面操作に対応する状態> 
        /// <summary>
        /// 顧客コード
        /// </summary>
        private string _customerCode = string.Empty;

        /// <summary>
        /// 顧客名
        /// </summary>
        private string _customerName = string.Empty;

        /// <summary>
        /// メールアドレス
        /// </summary>
        private string _mailAddress = string.Empty;

        /// <summary>
        /// 入力ガイダンスメッセージ
        /// </summary>
        private string _message = string.Empty;

        /// <summary>
        /// 登録処理
        /// </summary>
        public RelayCommand SaveCommand { get; }

        /// <summary>
        /// クリア処理
        /// </summary>
        public RelayCommand ClearCommand { get; }
        #endregion


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="service"></param>
        public M_CustomerViewModel(IM_CustomerService service)
        {
            _service = service;
            Title = "顧客マスタ登録";

            SaveCommand = new RelayCommand(Save, CanSave);
            ClearCommand = new RelayCommand(Clear, CanClear);
        }

        #region <プロパティ（CommunityToolkit.Mvvmを導入すると、不要になるかも）>

        /// <summary>
        /// 顧客コードプロパティ
        /// </summary>
        public string CustomerCode
        {
            get => _customerCode;
            set
            {
                if (SetProperty(ref _customerCode, value))
                {
                    SaveCommand.RaiseCanExecuteChanged();
                    ClearCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// 顧客名プロパティ
        /// </summary>
        public string CustomerName
        {
            get => _customerName;
            set
            {
                if (SetProperty(ref _customerName, value))
                {
                    SaveCommand.RaiseCanExecuteChanged();
                    ClearCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// メールアドレスプロパティ
        /// </summary>
        public string MailAddress
        {
            get => _mailAddress;
            set
            {
                if (SetProperty(ref _mailAddress, value))
                {
                    SaveCommand.RaiseCanExecuteChanged();
                    ClearCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// 入力ガイダンスメッセージプロパティ
        /// </summary>
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        #endregion

        #region <画面操作に対応する処理>
        /// <summary>
        /// 登録ボタンの使用可否状態を判定する
        /// </summary>
        /// <returns>
        /// true: 保存可能
        /// false: 保存不可
        /// </returns>
        /// <remarks>顧客コード、顧客名、メールアドレスが全て入力されている時、保存可能</remarks>
        public bool CanSave()
        {
            return !string.IsNullOrEmpty(CustomerCode)
                   && !string.IsNullOrEmpty(CustomerName)
                   && !string.IsNullOrEmpty(MailAddress);
        }

        /// <summary>
        /// クリアボタンの使用可否を判定する
        /// </summary>
        /// <returns>
        /// true: クリアボタン使用可能
        /// false: クリアボタン使用不可
        /// </returns>
        public bool CanClear()
        {
            return !(string.IsNullOrEmpty(CustomerCode)
                        && string.IsNullOrEmpty(CustomerName)
                        && string.IsNullOrEmpty(MailAddress)
                        && string.IsNullOrEmpty(Message));
        }
           

        public void Save()
        {
            //if (!CanSave())
            //{
            //    Message = "入力内容を確認してください。";
            //    return;
            //}

            //try
            //{
            //    Customer customer = new Customer(
            //        CustomerCode,
            //        CustomerName,
            //        MailAddress
            //    );
            //    await _service.SaveAsync(customer);
            //    Message = $"{customer.Code} : {CustomerName} を保存しました。";
            //}
            //catch (Exception)
            //{

            //}
            //finally
            //{
            //}

            _ = SaveAsync();
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        public void Clear()
        {
            CustomerCode = string.Empty;
            CustomerName = string.Empty;
            MailAddress = string.Empty;
            Message = string.Empty;
            ClearCommand.RaiseCanExecuteChanged();
        }

        private async Task SaveAsync()
        {
            // ToDo
        }
        #endregion
    }
}
