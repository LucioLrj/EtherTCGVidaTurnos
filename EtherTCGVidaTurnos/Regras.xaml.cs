namespace EtherTCGVidaTurnos;

public partial class Regras : ContentPage
{
    public Regras()
    {
        InitializeComponent();
    }
    private async void Voltar_Clicked(object sender, EventArgs e)
    {
        // Navega de volta para a MainPage
        await Navigation.PopAsync();
    }
}
