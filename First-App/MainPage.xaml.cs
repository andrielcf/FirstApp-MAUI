using Newtonsoft.Json;

namespace First_App;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private async void consultPerson(object sender, EventArgs e)
    {
        string url = "https://randomuser.me/api/";
        try
        {
            var result = await FetchDataFromApi(url);

            if (result != null)
            {
                NameLabel.Text = $"Name: {result.name.first} {result.name.last}";
                EmailLabel.Text = $"Email: {result.email}";
                PhoneLabel.Text = $"Phone: {result.phone}";
                LocationLabel.Text = $"Location: {result.location.city}, {result.location.country}";
            }
            else
            {
                await DisplayAlert("Error", "No data found.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async Task<randomPersonDTO.Result> FetchDataFromApi(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<randomPersonDTO.Root>(response);

            if (data.results != null && data.results.Count > 0)
            {
                return data.results[0];
            }
            else{
                return null;
            }
        }
    }
}