namespace EtherTCGVidaTurnos;

public partial class Sobre : ContentPage
{
	public Sobre()
	{
		InitializeComponent();
	}
    private async void Voltar_Clicked(object sender, EventArgs e)
    {
        // Navega de volta para a MainPage
        await Navigation.PopAsync();
    }
}