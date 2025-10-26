using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace EtherTCGVidaTurnos
{
    [Activity(Theme = "@style/Maui.SplashTheme",
              MainLauncher = true,
              LaunchMode = LaunchMode.SingleTop,
              ConfigurationChanges = ConfigChanges.ScreenSize
                                   | ConfigChanges.Orientation
                                   | ConfigChanges.UiMode
                                   | ConfigChanges.ScreenLayout
                                   | ConfigChanges.SmallestScreenSize
                                   | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                // Define cor da barra de status (caso apareça brevemente)
                Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#000000"));
            }

            // Ativa modo tela cheia (oculta status bar e navegação)
            SetImmersiveMode();
        }

        protected override void OnResume()
        {
            base.OnResume();
            SetImmersiveMode();
        }

        private void SetImmersiveMode()
        {
            // Impede que a tela escureça ou bloqueie
            Window.AddFlags(WindowManagerFlags.KeepScreenOn);

            // Ativa o modo imersivo (fullscreen real)
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(
                SystemUiFlags.HideNavigation
                | SystemUiFlags.ImmersiveSticky
                | SystemUiFlags.Fullscreen
            );
        }
    }
}
