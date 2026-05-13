using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Text.Json;

namespace EtherTCGVidaTurnos;

public partial class ComunidadePage : ContentPage
{
    private const string ApiKey = "AIzaSyD9XRh1Fr9R1WLvBihLOUKdfHInHsOLIic";

    private readonly List<(string Nome, string ChannelId)> _criadores = new()
    {
        ("LuneGames", "UCtqAzUyU56tCsl-zufpVpfA"),
        ("Zubat's Cave", "UCItmLj6-Fa0iQ6NGah9cUoA"),
        ("Ponce TCG", "UC-vvzm965n-Ok_ldx4VJZXA"),
    };

    public ComunidadePage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ListaCriadores.Children.Clear();
        foreach (var (nome, channelId) in _criadores)
        {
            var card = CriarCardCarregando(nome);
            ListaCriadores.Children.Add(card);
            _ = CarregarUltimoVideo(card, nome, channelId);
        }
    }

    private Frame CriarCardCarregando(string nome)
    {
        var frame = new Frame
        {
            BackgroundColor = Color.FromArgb("#FFFDE7"),
            CornerRadius = 12,
            Padding = new Thickness(12),
            HasShadow = false,
            BorderColor = Color.FromArgb("#FFDC91")
        };

        var layout = new VerticalStackLayout { Spacing = 6 };

        var lblNome = new Label
        {
            Text = nome,
            FontSize = 16,
            FontAttributes = FontAttributes.Bold,
            TextColor = Colors.Black
        };

        var lblStatus = new Label
        {
            Text = "Carregando...",
            FontSize = 13,
            TextColor = Colors.Gray
        };

        layout.Children.Add(lblNome);
        layout.Children.Add(lblStatus);
        frame.Content = layout;
        return frame;
    }

    private async Task CarregarUltimoVideo(Frame card, string nome, string channelId)
    {
        try
        {
            using var http = new HttpClient();
            var url = $"https://www.googleapis.com/youtube/v3/search?key={ApiKey}&channelId={channelId}&part=snippet&order=date&maxResults=1&type=video";
            var response = await http.GetStringAsync(url);
            using var doc = JsonDocument.Parse(response);
            var items = doc.RootElement.GetProperty("items");

            if (items.GetArrayLength() == 0)
            {
                AtualizarCardErro(card, nome, "Nenhum vídeo encontrado.");
                return;
            }

            var item = items[0];
            var snippet = item.GetProperty("snippet");
            var videoId = item.GetProperty("id").GetProperty("videoId").GetString();
            var titulo = snippet.GetProperty("title").GetString();
            var thumbnail = snippet.GetProperty("thumbnails").GetProperty("medium").GetProperty("url").GetString();

            AtualizarCard(card, nome, titulo, thumbnail, videoId);
        }
        catch (Exception ex)
        {
            AtualizarCardErro(card, nome, $"Erro ao carregar: {ex.Message}");
        }
    }

    private void AtualizarCard(Frame card, string nome, string titulo, string thumbnail, string videoId)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            var layout = new VerticalStackLayout { Spacing = 8 };

            var lblNome = new Label
            {
                Text = nome,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black
            };

            var img = new Image
            {
                Source = ImageSource.FromUri(new Uri(thumbnail)),
                Aspect = Aspect.AspectFill,
                HeightRequest = 160
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                FontSize = 13,
                TextColor = Colors.Black,
                FontAttributes = FontAttributes.Bold,
                MaxLines = 2,
                LineBreakMode = LineBreakMode.TailTruncation
            };

            var btnAssistir = new Button
            {
                Text = "Assistir no YouTube",
                FontSize = 14,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.FromArgb("#FFDC91"),
                TextColor = Colors.Black,
                CornerRadius = 20
            };

            btnAssistir.Clicked += (s, e) => AbrirYoutube(videoId);

            layout.Children.Add(lblNome);
            layout.Children.Add(img);
            layout.Children.Add(lblTitulo);
            layout.Children.Add(btnAssistir);
            card.Content = layout;
        });
    }

    private void AtualizarCardErro(Frame card, string nome, string mensagem)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            var layout = new VerticalStackLayout { Spacing = 6 };

            var lblNome = new Label
            {
                Text = nome,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black
            };

            var lblErro = new Label
            {
                Text = mensagem,
                FontSize = 13,
                TextColor = Colors.Red
            };

            layout.Children.Add(lblNome);
            layout.Children.Add(lblErro);
            card.Content = layout;
        });
    }

    private async void AbrirYoutube(string videoId)
    {
        var uri = new Uri($"https://www.youtube.com/watch?v={videoId}");
        await Launcher.OpenAsync(uri);
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}