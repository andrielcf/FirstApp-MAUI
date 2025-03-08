namespace First_App;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnSimpleAlertClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Aviso", "Este é um alerta simples!", "OK");
    }

    private async void OnConfirmationAlertClicked(object sender, EventArgs e)
    {
        bool resposta = await DisplayAlert("Confirmação", "Você deseja continuar?", "Sim", "Não");
        if (resposta)
        {
            await DisplayAlert("Escolha", "Você escolheu SIM!", "OK");
        }
        else
        {
            await DisplayAlert("Escolha", "Você escolheu NÃO!", "OK");
        }
    }

    private async void OnPromptClicked(object sender, EventArgs e)
    {
        string nome = await DisplayPromptAsync("Seu Nome", "Digite seu nome:");
        if (!string.IsNullOrEmpty(nome))
        {
            await DisplayAlert("Olá!", $"Bem-vindo, {nome}!", "OK");
        }
    }

    private async void OnNavigateClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SecondPage());
    }
}

