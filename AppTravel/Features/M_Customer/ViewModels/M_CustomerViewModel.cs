using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using AppTravel.Features.M_Customer.Dtos;
using AppTravel.Features.M_Customer.Services;
using AppTravel.MVVM.Base;

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
        #endregion


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="service"></param>
        public M_CustomerViewModel(IM_CustomerService service)
        {
            _service = service;

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
                    OnPropertyChanged(nameof(CanSave));
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
                    OnPropertyChanged(nameof(CanSave));
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
                    OnPropertyChanged(nameof(CanSave));
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
        public bool CanSave =>
            !string.IsNullOrEmpty(CustomerCode)
            && !string.IsNullOrEmpty(CustomerName)
            && !string.IsNullOrEmpty(MailAddress);

        public void Save()
        {
            if (!CanSave)
            {
                Message = "入力内容を確認してください。";
                return;
            }

            try
            {
                Message = $"{CustomerCode} : {CustomerName} を保存しました。";
            }
            catch (Exception)
            {

            }
            finally
            {
            }
        }
        #endregion
    }
}
