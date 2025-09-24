namespace EtherTCGVidaTurnos;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnIniciarPartidaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new JogadorConfigPage(1));
    }
}
