using AppTravel.Features.M_Customer.ViewModels;

namespace AppTravel.Features.M_Customer.Views;

public partial class M_Customer : ContentPage
{
	public M_Customer()
	{
		InitializeComponent();
		BindingContext = new M_CustomerViewModel();
	}
}