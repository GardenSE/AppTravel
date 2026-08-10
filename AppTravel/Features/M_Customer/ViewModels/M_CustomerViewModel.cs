using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using AppTravel.Features.M_Customer.Dtos;
using AppTravel.Features.M_Customer.Models;
using AppTravel.Features.M_Customer.Services;
using AppTravel.MVVM.Base;
using AppTravel.MVVM.Command;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppTravel.Features.M_Customer.ViewModels
{
    public partial class M_CustomerViewModel : ViewModelBase
    {
        private readonly IM_CustomerService _service;

        #region <画面に表示する値/画面から変更される値/画面操作に対応する状態> 
        /// <summary>
        /// 顧客コード
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyCanExecuteChangedFor(nameof(ClearCommand))]
        private string _customerCode = string.Empty;

        /// <summary>
        /// 顧客氏名（姓）
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyCanExecuteChangedFor(nameof(ClearCommand))]
        private string _customerLastName = string.Empty;

        /// <summary>
        /// 顧客氏名（名）
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyCanExecuteChangedFor(nameof(ClearCommand))]
        private string _customerFirstName = string.Empty;

        /// <summary>
        /// 顧客氏名（姓・フリガナ）
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyCanExecuteChangedFor(nameof(ClearCommand))]
        private string _customerLastNameKana = string.Empty;

        /// <summary>
        /// 顧客氏名（名・フリガナ）
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyCanExecuteChangedFor(nameof(ClearCommand))]
        private string _customerFirstNameKana = string.Empty;

        /// <summary>
        /// メールアドレス
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyCanExecuteChangedFor(nameof(ClearCommand))]
        private string _mailAddress = string.Empty;

        /// <summary>
        /// 入力ガイダンスメッセージ
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ClearCommand))]
        private string _message = string.Empty;
        #endregion


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="service"></param>
        public M_CustomerViewModel(IM_CustomerService service)
        {
            _service = service;
            Title = "顧客マスタ登録";
        }

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
            bool isCanSave = !string.IsNullOrEmpty(CustomerCode)
                                && !string.IsNullOrEmpty(CustomerLastName)
                                && !string.IsNullOrEmpty(CustomerFirstName)
                                && !string.IsNullOrEmpty(CustomerLastNameKana)
                                && !string.IsNullOrEmpty(CustomerFirstNameKana)
                                && !string.IsNullOrEmpty(MailAddress);

            return isCanSave;
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
            bool isCanClear =  !(string.IsNullOrEmpty(CustomerCode)
                                    && string.IsNullOrEmpty(CustomerLastName)
                                    && string.IsNullOrEmpty(CustomerFirstName)
                                    && string.IsNullOrEmpty(CustomerFirstNameKana)
                                    && string.IsNullOrEmpty(CustomerLastNameKana)
                                    && string.IsNullOrEmpty(MailAddress)
                                    && string.IsNullOrEmpty(Message)
                                );
            
            return isCanClear;
        }
           
        /// <summary>
        /// 画面初期化
        /// </summary>
        [RelayCommand(CanExecute = nameof(CanClear))]
        public async Task ClearAsync()
        {
            await ExecuteAsync(async () =>
            {
                CustomerCode = string.Empty;
                CustomerLastName = string.Empty;
                CustomerFirstName = string.Empty;
                CustomerLastNameKana = string.Empty;
                CustomerFirstNameKana = string.Empty;
                MailAddress = string.Empty;
                Message = string.Empty;
            });
        }

        /// <summary>
        /// 登録処理
        /// </summary>
        /// <returns></returns>
        [RelayCommand(CanExecute =nameof(CanSave))]
        public async Task SaveAsync()
        {
            await ExecuteAsync(async () =>
            {
                CustomerRegister customerRegister = new CustomerRegister(
                CustomerCode,
                CustomerLastName,
                CustomerFirstName,
                CustomerLastNameKana,
                CustomerFirstNameKana,
                MailAddress
            );
                await _service.SaveAsync(customerRegister);
                Message = $"顧客コード: {CustomerCode} 顧客名: {CustomerLastName} {CustomerFirstName} を登録しました。";
            });
        }
        #endregion
    }
}
