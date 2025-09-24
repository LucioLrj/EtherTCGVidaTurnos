namespace EtherTCG;

public partial class PartidaPage : ContentPage
{
    int vidaJogador1 = 20;
    int vidaJogador2 = 20;

    public PartidaPage(string nome1, string personagem1, string nome2, string personagem2)
    {
        InitializeComponent();

        // Configura nomes e personagens
        lblJogador1Nome.Text = nome1;
        imgJogador1Personagem.Source = personagem1;

        lblJogador2Nome.Text = nome2;
        imgJogador2Personagem.Source = personagem2;

        // Inicializa turnos
        ResetTurnos();
    }

    // Jogador 1 Vida
    void OnJogador1MaisVida(object sender, EventArgs e)
    {
        if (vidaJogador1 < 99)
        {
            vidaJogador1++;
            lblJogador1Vida.Text = vidaJogador1.ToString("00");
        }
    }

    void OnJogador1MenosVida(object sender, EventArgs e)
    {
        if (vidaJogador1 > 0)
        {
            vidaJogador1--;
            lblJogador1Vida.Text = vidaJogador1.ToString("00");
        }
    }

    // Jogador 2 Vida
    void OnJogador2MaisVida(object sender, EventArgs e)
    {
        if (vidaJogador2 < 99)
        {
            vidaJogador2++;
            lblJogador2Vida.Text = vidaJogador2.ToString("00");
        }
    }

    void OnJogador2MenosVida(object sender, EventArgs e)
    {
        if (vidaJogador2 > 0)
        {
            vidaJogador2--;
            lblJogador2Vida.Text = vidaJogador2.ToString("00");
        }
    }

    // Reset inicial dos turnos
    void ResetTurnos()
    {
        lblJ1Contador1.Text = "0";
        lblJ1Contador2.Text = "0";
        lblJ1Contador3.Text = "0";
        lblJ1Contador4.Text = "0";

        lblJ2Contador1.Text = "0";
        lblJ2Contador2.Text = "0";
        lblJ2Contador3.Text = "0";
        lblJ2Contador4.Text = "0";
    }

    // Eventos de swipe
    void OnTurnoUp(object sender, SwipedEventArgs e)
    {
        if (sender is Label lbl && lbl.Text is string texto && int.TryParse(texto, out int valor))
        {
            if (valor < 9)
                lbl.Text = (valor + 1).ToString();
        }
    }

    void OnTurnoDown(object sender, SwipedEventArgs e)
    {
        if (sender is Label lbl && lbl.Text is string texto && int.TryParse(texto, out int valor))
        {
            if (valor > 0)
                lbl.Text = (valor - 1).ToString();
        }
    }
}
