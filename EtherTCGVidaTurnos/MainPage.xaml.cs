using EtherTCGVidaTurnos.Core;
namespace EtherTCGVidaTurnos;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnIniciarPartidaClicked(object sender, EventArgs e)
    {
         EstadoPartida.IniciarNovaPartida();
         await Navigation.PushAsync(new ConfiguracaoPartidaPage());
    }

    private async void OnRegrasClicked(object sender, EventArgs e)
    {
        string opcao = await DisplayActionSheet(
            "Como você deseja ver as regras?",
            "Cancelar",
            null,
            "Regras Escritas",
            "Manual Ilustrativo"
        );

        if (opcao == "Regras Escritas")
        {
            await Navigation.PushAsync(new Regras());
        }
        else if (opcao == "Manual Ilustrativo")
        {
            var url = "https://www.dropbox.com/scl/fi/otcewaebmis5m0b6cvu7m/Manual-como-jogar-ther.pdf?rlkey=ki7o8fjugydgqfb9erxqwej0x&e=1&st=b1uwo9s4&dl=0";
            await Launcher.OpenAsync(new Uri(url));
        }
    }
    private async void OnLinksClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LinksPage());
    }
    private async void OnSobreClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
    private async void OnSairClicked(object sender, EventArgs e)
    {
        bool sair = await DisplayAlert(
            "Sair da partida",
            "Deseja realmente fechar o aplicativo?",
            "Sair",
            "Cancelar"
        );

        if (sair)
        {
            Application.Current?.Quit();
        }
    }

}