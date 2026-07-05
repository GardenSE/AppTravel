using AppTravel.Features.M_Customer.ViewModels;
using AppTravel.Infrastructure;

namespace AppTravel.Features.M_Customer.Views;

public partial class M_CustomerPage : ContentPage
{
    private readonly M_CustomerViewModel _vm;

    public M_CustomerPage() { }

    public M_CustomerPage(M_CustomerViewModel vm)
    {
		InitializeComponent();
		BindingContext = _vm = vm;
	}
}