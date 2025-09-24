namespace EtherTCGVidaTurnos;

public partial class PartidaPage : ContentPage
{
    private int vida1 = 20;
    private int vida2 = 20;
    private int turnos = 0;

    public PartidaPage(string nome1, string personagem1, string nome2, string personagem2)
    {
        InitializeComponent();

        //NomeJogador1.Text = $"{nome1} ({personagem1})";
        //NomeJogador2.Text = $"{nome2} ({personagem2})";

        VidaJogador1.Text = vida1.ToString("D2");
        VidaJogador2.Text = vida2.ToString("D2");
        //TurnosLabel.Text = turnos.ToString();
    }

    private void OnAumentarVida1(object sender, EventArgs e)
    {
        if (vida1 < 99) vida1++;
        VidaJogador1.Text = vida1.ToString("D2");
    }

    private void OnDiminuirVida1(object sender, EventArgs e)
    {
        if (vida1 > 0) vida1--;
        VidaJogador1.Text = vida1.ToString("D2");
    }

    private void OnAumentarVida2(object sender, EventArgs e)
    {
        if (vida2 < 99) vida2++;
        VidaJogador2.Text = vida2.ToString("D2");
    }

    private void OnDiminuirVida2(object sender, EventArgs e)
    {
        if (vida2 > 0) vida2--;
        VidaJogador2.Text = vida2.ToString("D2");
    }

    //private void OnAumentarTurno(object sender, EventArgs e)
    //{
    //    if (turnos < 9) turnos++;
    //    TurnosLabel.Text = turnos.ToString();
    //}

    //private void OnDiminuirTurno(object sender, EventArgs e)
    //{
    //    if (turnos > 0) turnos--;
    //    TurnosLabel.Text = turnos.ToString();
    //}
}
