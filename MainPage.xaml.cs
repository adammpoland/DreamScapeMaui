using DreamScapeMAUI.Models;
using Microsoft.Maui.Controls;
using SQLite;

namespace DreamScapeMAUI;

public partial class MainPage : ContentPage
{
    public List<Note> dreams = new List<Note>();

	public MainPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Retrieve all the notes from the database, and set them as the
        // data source for the CollectionView.
        try
        {
            DreamList.ItemsSource = await App.Database.GetNotesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        
    }

    async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null)
        {
            // Navigate to the NoteEntryPage, passing the ID as a query parameter.
            Note note = (Note)e.CurrentSelection.FirstOrDefault();
            await Shell.Current.GoToAsync($"{nameof(AddDream)}?{nameof(AddDream.ItemId)}={note.Id.ToString()}");
        }
    }

    private async void NavigateToAddDream(object sender, EventArgs e)
	{
        await Navigation.PushModalAsync(new AddDream());
    }
}


