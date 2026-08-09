using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppTravel.MVVM.Base
{
    public abstract class ViewModelBase : ObservableObject
    {
        private string _title = string.Empty;

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

        public string Title
        {
            get => _title;
            set => _title = value;
        }
    }
}
