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

    private async void OnSiteClicked(object sender, EventArgs e)
    {
        var url = "https://ethertcgoficial.vercel.app/";
        await Launcher.OpenAsync(new Uri(url));
    }

    private async void OnLojaClicked(object sender, EventArgs e)
    {
        var url = "https://ethertcg.lojavirtualnuvem.com.br/";
        await Launcher.OpenAsync(new Uri(url));
    }

    private async void OnCompendiumClicked(object sender, EventArgs e)
    {
        var url = "https://ethercompendium.base44.app/";
        await Launcher.OpenAsync(new Uri(url));
    }

}

//Links Úteis:
/* Site oficial https://ethertcgoficial.vercel.app/ */
/* App PWA https://ethertcgapp.vercel.app/ */
/* Manual Ilustrado https://www.dropbox.com/scl/fi/otcewaebmis5m0b6cvu7m/Manual-como-jogar-ther.pdf?rlkey=ki7o8fjugydgqfb9erxqwej0x&e=1&st=b1uwo9s4&dl=0 */
/* Compendium https://ethercompendium.base44.app/ */