using System;
using System.Collections.Generic;
using System.Text;

namespace AppTravel.MVVM.Base
{
    public abstract class ViewModelBase : BindableBase
    {
        private string _title = string.Empty;

        public ViewModelBase() { }

        public string Title
        {
            get => _title;
            set => _title = value;
        }
    }
}
