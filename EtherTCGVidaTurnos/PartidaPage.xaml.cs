namespace EtherTCGVidaTurnos;

public partial class PartidaPage : ContentPage
{
    // ========================= CONSTRUTORES =========================

    public PartidaPage()
    {
        InitializeComponent();
    }

    public PartidaPage(string nome1, string personagem1, string nome2, string personagem2)
        : this()
    {
        NomeJogador1.Text = nome1;
        NomeJogador2.Text = nome2;

        AtualizarVidaJogador1();
        AtualizarVidaJogador2();

        if (personagemParaImagem.ContainsKey(personagem1))
            PersonagemJogador1.Source = personagemParaImagem[personagem1];

        if (personagemParaImagem.ContainsKey(personagem2))
            PersonagemJogador2.Source = personagemParaImagem[personagem2];
    }

    private int deltaVida1 = 0;
    private int deltaVida2 = 0;

    private int direcaoDelta1 = 0; // -1 dano | +1 cura | 0 neutro
    private int direcaoDelta2 = 0;

    private bool efeitoAtivoDelta1 = false;
    private bool efeitoAtivoDelta2 = false;

    private CancellationTokenSource ctsDelta1;
    private CancellationTokenSource ctsDelta2;

    private int vida1 = 20;
    private int vida2 = 20;

    private const int VIDA_MAXIMA = 40;
    private const int TEMPO_DELTA_MS = 2500;

    // ========================= PERSONAGENS =========================
    private readonly Dictionary<string, string> personagemParaImagem =
        new Dictionary<string, string>
    {
        { "Fada", "fada.jpg" },
        { "Necromante", "necromante.jpg" },
        { "Ser Oceânico", "ser_oceanico.jpg" },
        { "Vampiro", "vampiro.jpg" }
    };

    // ========================= EFEITOS =========================

    private async Task ShakeTela()
    {
        const int distancia = 8;
        const int duracao = 40;

        for (int i = 0; i < 4; i++)
        {
            await this.TranslateTo(-distancia, 0, duracao);
            await this.TranslateTo(distancia, 0, duracao);
        }

        await this.TranslateTo(0, 0, duracao);
    }

    private async Task FlashDeCura()
    {
        FlashCura.Opacity = 0;
        FlashCura.IsVisible = true;

        await FlashCura.FadeTo(1, 120);
        await FlashCura.FadeTo(0, 250);

        FlashCura.IsVisible = false;
    }

    private void VibrarDano()
    {
        try
        {
            Vibration.Vibrate(TimeSpan.FromMilliseconds(60));
        }
        catch { }
    }

    // ========================= DELTA VIDA =========================

    private async Task MostrarDeltaVida(
        Label labelPrincipal,
        Label[] bordas,
        Func<int> getDelta,
        Func<int> getDirecao,
        Action resetar,
        CancellationTokenSource cts)
    {
        try
        {
            int delta = getDelta();
            if (delta == 0)
                return;

            int direcao = getDirecao();

            string texto = direcao == 1
                ? $"+{Math.Abs(delta)}"
                : $"-{Math.Abs(delta)}";

            Color cor = direcao == 1
                ? Colors.DarkGreen
                : Colors.DarkRed;

            labelPrincipal.Text = texto;
            labelPrincipal.TextColor = cor;
            labelPrincipal.Opacity = 0;
            labelPrincipal.TranslationY = 10;
            labelPrincipal.IsVisible = true;

            foreach (var b in bordas)
            {
                b.Text = texto;
                b.Opacity = 0;
                b.TranslationY = 10;
                b.IsVisible = true;
            }

            await Task.WhenAll(
                labelPrincipal.FadeTo(1, 180),
                labelPrincipal.TranslateTo(0, 0, 180, Easing.CubicOut),
                Task.WhenAll(bordas.Select(b => b.FadeTo(1, 180))),
                Task.WhenAll(bordas.Select(b => b.TranslateTo(0, 0, 180, Easing.CubicOut)))
            );

            await Task.Delay(TEMPO_DELTA_MS, cts.Token);

            await Task.WhenAll(
                labelPrincipal.FadeTo(0, 200),
                Task.WhenAll(bordas.Select(b => b.FadeTo(0, 200)))
            );

            labelPrincipal.IsVisible = false;
            foreach (var b in bordas)
                b.IsVisible = false;

            resetar();
        }
        catch (TaskCanceledException) { }
    }

    // ========================= DELTA J1 =========================

    private void AtualizarDeltaVidaJogador1()
    {
        ctsDelta1?.Cancel();
        ctsDelta1 = new CancellationTokenSource();

        _ = MostrarDeltaVida(
            DeltaVidaJogador1,
            new[]
            {
                DeltaVidaJogador1_Outline1,
                DeltaVidaJogador1_Outline2,
                DeltaVidaJogador1_Outline3,
                DeltaVidaJogador1_Outline4
            },
            () => deltaVida1,
            () => direcaoDelta1,
            () =>
            {
                deltaVida1 = 0;
                direcaoDelta1 = 0;
                efeitoAtivoDelta1 = false;
            },
            ctsDelta1
        );
    }

    private void AtualizarDeltaVidaJogador2()
    {
        ctsDelta2?.Cancel();
        ctsDelta2 = new CancellationTokenSource();

        _ = MostrarDeltaVida(
            DeltaVidaJogador2,
            new[]
            {
                DeltaVidaJogador2_Outline1,
                DeltaVidaJogador2_Outline2,
                DeltaVidaJogador2_Outline3,
                DeltaVidaJogador2_Outline4
            },
            () => deltaVida2,
            () => direcaoDelta2,
            () =>
            {
                deltaVida2 = 0;
                direcaoDelta2 = 0;
                efeitoAtivoDelta2 = false;
            },
            ctsDelta2
        );
    }

    // ========================= VIDA =========================

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

    // ========================= BOTÕES J1 =========================

    private void OnAumentarVida1(object sender, EventArgs e)
    {
        if (vida1 >= VIDA_MAXIMA)
            return;

        vida1++;

        if (direcaoDelta1 != 1)
        {
            deltaVida1 = 0;
            direcaoDelta1 = 1;
            efeitoAtivoDelta1 = false;

            _ = FlashDeCura();
        }

        deltaVida1++;

        AtualizarVidaJogador1();
        AtualizarDeltaVidaJogador1();
    }

    private void OnDiminuirVida1(object sender, EventArgs e)
    {
        if (vida1 <= 0)
            return;

        vida1--;

        if (direcaoDelta1 != -1)
        {
            deltaVida1 = 0;
            direcaoDelta1 = -1;
            efeitoAtivoDelta1 = false;

            _ = ShakeTela();
            VibrarDano();
        }

        deltaVida1++;

        AtualizarVidaJogador1();
        AtualizarDeltaVidaJogador1();
    }

    // ========================= BOTÕES J2 =========================

    private void OnAumentarVida2(object sender, EventArgs e)
    {
        if (vida2 >= VIDA_MAXIMA)
            return;

        vida2++;

        if (direcaoDelta2 != 1)
        {
            deltaVida2 = 0;
            direcaoDelta2 = 1;
            efeitoAtivoDelta2 = false;

            _ = FlashDeCura();
        }

        deltaVida2++;

        AtualizarVidaJogador2();
        AtualizarDeltaVidaJogador2();
    }

    private void OnDiminuirVida2(object sender, EventArgs e)
    {
        if (vida2 <= 0)
            return;

        vida2--;

        if (direcaoDelta2 != -1)
        {
            deltaVida2 = 0;
            direcaoDelta2 = -1;
            efeitoAtivoDelta2 = false;

            _ = ShakeTela();
            VibrarDano();
        }

        deltaVida2++;

        AtualizarVidaJogador2();
        AtualizarDeltaVidaJogador2();
    }

    // ========================= OUTROS =========================

    private void OnResetVidaClicked(object sender, EventArgs e)
    {
        vida1 = 20;
        vida2 = 20;

        deltaVida1 = 0;
        deltaVida2 = 0;

        direcaoDelta1 = 0;
        direcaoDelta2 = 0;

        AtualizarVidaJogador1();
        AtualizarVidaJogador2();
    }

    private async void OnRegrasClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Regras());
    }
}
