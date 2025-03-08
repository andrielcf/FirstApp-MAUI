namespace First_App;

public partial class SecondPage : ContentPage
{
	int count = 0;

	public SecondPage()
	{
		InitializeComponent();
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }


}

