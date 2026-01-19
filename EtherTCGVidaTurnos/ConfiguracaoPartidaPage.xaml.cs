using EtherTCGVidaTurnos.Core;
namespace EtherTCGVidaTurnos;

public partial class ConfiguracaoPartidaPage : ContentPage
{
    public ConfiguracaoPartidaPage()
    {
        InitializeComponent();
        BindingContext = EstadoPartida.Configuracao;
    }

    private async void OnAvancarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new JogadorConfigPage(1));
    }
    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        // Navega de volta para a MainPage
        await Navigation.PopAsync();
    }
}
