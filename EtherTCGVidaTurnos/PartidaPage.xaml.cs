namespace EtherTCGVidaTurnos;

public partial class PartidaPage : ContentPage
{
    private int vida1 = 20;
    private int vida2 = 20;

    private int[] criaturasJ1 = new int[4];
    private int[] criaturasJ2 = new int[4];

    private readonly Dictionary<string, string> personagemParaImagem = new Dictionary<string, string>()
    {
        { "Elfo", "elfo.jpg" },
        { "Necromante", "necromante.jpg" },
        { "Ser Oceânico", "ser_oceanico.jpg" },
        { "Vampiro", "vampiro.jpg" }
    };

    public PartidaPage(string nome1, string personagem1, string nome2, string personagem2)
    {
        InitializeComponent();

        NomeJogador1.Text = nome1;
        NomeJogador2.Text = nome2;

        AtualizarVidaJogador1();
        AtualizarVidaJogador2();

        if (personagemParaImagem.ContainsKey(personagem1))
            PersonagemJogador1.Source = personagemParaImagem[personagem1];

        if (personagemParaImagem.ContainsKey(personagem2))
            PersonagemJogador2.Source = personagemParaImagem[personagem2];

        // Inicializa contadores em 0
        Criatura1_J1.Text = "00";
        Criatura2_J1.Text = "00";
        Criatura3_J1.Text = "00";
        Criatura4_J1.Text = "00";

        Criatura1_J2.Text = "00";
        Criatura2_J2.Text = "00";
        Criatura3_J2.Text = "00";
        Criatura4_J2.Text = "00";
    }

    // ===== Vidas =====
    private void OnAumentarVida1(object sender, EventArgs e)
    {
        if (vida1 < 99) vida1++;
        AtualizarVidaJogador1();
    }

    private void OnDiminuirVida1(object sender, EventArgs e)
    {
        if (vida1 > 0) vida1--;
        AtualizarVidaJogador1();
    }

    private void OnAumentarVida2(object sender, EventArgs e)
    {
        if (vida2 < 99) vida2++;
        AtualizarVidaJogador2();
    }

    private void OnDiminuirVida2(object sender, EventArgs e)
    {
        if (vida2 > 0) vida2--;
        AtualizarVidaJogador2();
    }

    // ===== Atualiza cores das vidas =====
    private void AtualizarVidaJogador1()
    {
        VidaJogador1.Text = vida1.ToString("D2");

        if (vida1 <= 5)
            VidaJogador1.TextColor = Colors.Red;
        else if (vida1 <= 10)
            VidaJogador1.TextColor = Colors.Yellow;
        else
            VidaJogador1.TextColor = Colors.White;
    }

    private void AtualizarVidaJogador2()
    {
        VidaJogador2.Text = vida2.ToString("D2");

        if (vida2 <= 5)
            VidaJogador2.TextColor = Colors.Red;
        else if (vida2 <= 10)
            VidaJogador2.TextColor = Colors.Yellow;
        else
            VidaJogador2.TextColor = Colors.White;
    }

    // ===== Swipe Gestures Independentes =====
    private void OnSwipeJ1Up(object sender, SwipedEventArgs e)
    {
        if (sender is StackLayout stack && stack.Children[0] is Label label)
        {
            int valor = int.Parse(label.Text);
            if (valor < 10) valor++;
            label.Text = valor.ToString("D2");
        }
    }

    private void OnSwipeJ1Down(object sender, SwipedEventArgs e)
    {
        if (sender is StackLayout stack && stack.Children[0] is Label label)
        {
            int valor = int.Parse(label.Text);
            if (valor > 0) valor--;
            label.Text = valor.ToString("D2");
        }
    }

    private void OnSwipeJ2Up(object sender, SwipedEventArgs e)
    {
        if (sender is StackLayout stack && stack.Children[0] is Label label)
        {
            int valor = int.Parse(label.Text);
            if (valor < 10) valor++;
            label.Text = valor.ToString("D2");
        }
    }

    private void OnSwipeJ2Down(object sender, SwipedEventArgs e)
    {
        if (sender is StackLayout stack && stack.Children[0] is Label label)
        {
            int valor = int.Parse(label.Text);
            if (valor > 0) valor--;
            label.Text = valor.ToString("D2");
        }
    }

    private void OnResetVidaClicked(object sender, EventArgs e)
    {
        vida1 = 20;
        vida2 = 20;
        AtualizarVidaJogador1();
        AtualizarVidaJogador2();
    }

    private void OnResetContadoresClicked(object sender, EventArgs e)
    {
        Criatura1_J1.Text = "00";
        Criatura2_J1.Text = "00";
        Criatura3_J1.Text = "00";
        Criatura4_J1.Text = "00";

        Criatura1_J2.Text = "00";
        Criatura2_J2.Text = "00";
        Criatura3_J2.Text = "00";
        Criatura4_J2.Text = "00";
    }


}
