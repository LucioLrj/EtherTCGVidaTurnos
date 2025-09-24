namespace EtherTCGVidaTurnos;

public partial class JogadorConfigPage : ContentPage
{
    private int jogadorNumero;
    private static string? nomeJogador1, personagemJogador1;
    private static string? nomeJogador2, personagemJogador2;

    public JogadorConfigPage(int numero)
    {
        InitializeComponent();
        jogadorNumero = numero;
        TituloJogador.Text = $"Configurar Jogador {jogadorNumero}";
    }

    private async void OnConfirmarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NomeEntry.Text) || PersonagemPicker.SelectedItem == null)
        {
            await DisplayAlert("Aviso", "Preencha o nome e escolha um personagem.", "OK");
            return;
        }

        if (jogadorNumero == 1)
        {
            nomeJogador1 = NomeEntry.Text;
            personagemJogador1 = PersonagemPicker.SelectedItem.ToString();
            await Navigation.PushAsync(new JogadorConfigPage(2));
        }
        else
        {
            nomeJogador2 = NomeEntry.Text;
            personagemJogador2 = PersonagemPicker.SelectedItem.ToString();
            await Navigation.PushAsync(new PartidaPage(nomeJogador1!, personagemJogador1!, nomeJogador2!, personagemJogador2!));
        }
    }
}
