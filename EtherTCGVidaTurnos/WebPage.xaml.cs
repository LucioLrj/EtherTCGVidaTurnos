namespace EtherTCGVidaTurnos;

public partial class WebPage : ContentPage
{
    public WebPage(string url)
    {
        InitializeComponent();
        Browser.Source = url;
    }

    private void OnNavigating(object sender, WebNavigatingEventArgs e)
    {
        Loader.IsVisible = true;
        Loader.IsRunning = true;
    }

    private void OnNavigated(object sender, WebNavigatedEventArgs e)
    {
        Loader.IsRunning = false;
        Loader.IsVisible = false;
    }
}
