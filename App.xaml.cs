using DreamScapeMAUI.Data;

namespace DreamScapeMAUI;

public partial class App : Application
{
    static DreamsDb database;

    // Create the database connection as a singleton.
    public static DreamsDb Database
    {
        get
        {
            if (database == null)
            {
                database = new DreamsDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db33"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

        MainPage = new AppShell();
    }
}

