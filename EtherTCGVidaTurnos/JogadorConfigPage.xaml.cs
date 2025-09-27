namespace EtherTCGVidaTurnos;

public partial class JogadorConfigPage : ContentPage
{
    private int jogadorNumero;
    private static string? nomeJogador1, personagemJogador1;
    private static string? nomeJogador2, personagemJogador2;

    // Mapeamento personagem -> arquivo de imagem
    private readonly Dictionary<string, string> personagemParaImagem = new Dictionary<string, string>()
    {
        { "Elfo", "elfo.jpg" },
        { "Necromante", "necromante.jpg" },
        { "Ser Oceânico", "ser_oceanico.jpg" },
        { "Vampiro", "vampiro.jpg" }
    };

    public JogadorConfigPage(int numero)
    {
        InitializeComponent();
        jogadorNumero = numero;
        TituloJogador.Text = $"Jogador {jogadorNumero}";
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

    // Atualiza preview quando o jogador muda a seleção
    private void OnPersonagemChanged(object sender, EventArgs e)
    {
        if (PersonagemPicker.SelectedItem == null)
            return;

        string personagemSelecionado = PersonagemPicker.SelectedItem.ToString()!;
        if (personagemParaImagem.ContainsKey(personagemSelecionado))
            PreviewPersonagem.Source = personagemParaImagem[personagemSelecionado];
    }
}
