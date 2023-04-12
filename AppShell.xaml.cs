using System.Windows.Input;

namespace DreamScapeMAUI;

public partial class AppShell : Shell
{
    public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
    public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public AppShell()
	{
		InitializeComponent();
        RegisterRoutes();
	}

    void RegisterRoutes()
    {
        Routes.Add("AddDream", typeof(AddDream));
        Routes.Add("MainPage", typeof(MainPage));

        foreach (var item in Routes)
        {
            Routing.RegisterRoute(item.Key, item.Value);
        }
    }
}

