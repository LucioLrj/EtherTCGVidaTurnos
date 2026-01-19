namespace EtherTCGVidaTurnos;

public partial class LinksPage : ContentPage
{
	public LinksPage()
	{
		InitializeComponent();
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
    private async void OnSimuladorClicked(object sender, EventArgs e)
    {
        var url = "https://unofficial-ethertgconline.vercel.app/";
        await Launcher.OpenAsync(new Uri(url));
    }
    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        // Navega de volta para a MainPage
        await Navigation.PopAsync();
    }

    private async void OnWhatsappClicked(object sender, EventArgs e)
    {
        var appUri = new Uri("whatsapp://chat?code=HeYH6tyqfZJK7mcwNxG3yS");
        var webUri = new Uri("https://chat.whatsapp.com/HeYH6tyqfZJK7mcwNxG3yS");

        try
        {
            await Launcher.OpenAsync(appUri);
        }
        catch
        {
            await Launcher.OpenAsync(webUri);
        }
    }

    private async void OnDiscordClicked(object sender, EventArgs e)
    {
        var appUri = new Uri("discord://invite/WBM8eUahJA");
        var webUri = new Uri("https://discord.com/invite/WBM8eUahJA");

        try
        {
            await Launcher.OpenAsync(appUri);
        }
        catch
        {
            await Launcher.OpenAsync(webUri);
        }
    }

    private async void OnInstagramClicked(object sender, EventArgs e)
    {
        var appUri = new Uri("instagram://user?username=ethertcg");
        var webUri = new Uri("https://www.instagram.com/ethertcg");

        try
        {
            await Launcher.OpenAsync(appUri);
        }
        catch
        {
            await Launcher.OpenAsync(webUri);
        }
    }

    private async void OnYoutubeClicked(object sender, EventArgs e)
    {
        var appUri = new Uri("vnd.youtube://@ethertcg");
        var webUri = new Uri("https://www.youtube.com/@ethertcg");

        try
        {
            await Launcher.OpenAsync(appUri);
        }
        catch
        {
            await Launcher.OpenAsync(webUri);
        }
    }

}

//Links Úteis:
/* Site oficial https://ethertcgoficial.vercel.app/ */
/* Manual Ilustrado https://www.dropbox.com/scl/fi/otcewaebmis5m0b6cvu7m/Manual-como-jogar-ther.pdf?rlkey=ki7o8fjugydgqfb9erxqwej0x&e=1&st=b1uwo9s4&dl=0 */
/* Compendium https://ethercompendium.base44.app/ */
/* Simulador Online https://unofficial-ethertgconline.vercel.app/ */
/* Whatsapp https://chat.whatsapp.com/HeYH6tyqfZJK7mcwNxG3yS */
/* Youtube https://youtube.com/@ethertcg */
/* Discord https://discord.com/invite/WBM8eUahJA */
/* Instagram https://www.instagram.com/ethertcg */