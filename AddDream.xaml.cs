using DreamScapeMAUI.Models;

namespace DreamScapeMAUI;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class AddDream : ContentPage
{
    public string ItemId
    {
        set
        {
            LoadNote(value);
        }
    }

    public AddDream()
	{
        InitializeComponent();
	}

    public AddDream(string Id)
    {
        LoadNote(Id);
    }


    async void LoadNote(string itemId)
    {
        try
        {
            int id = Convert.ToInt32(itemId);
            // Retrieve the note and set it as the BindingContext of the page.
            Note note = await App.Database.GetNoteAsync(id);
            BindingContext = note;
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to load note.");
        }
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var note = (Note)BindingContext;
        if (note == null)
        {
            note = new Note
            {
                NoteText = noteText.Text,
                CreatedDate = DateTime.Now
            };
            if (!string.IsNullOrWhiteSpace(note.NoteText))
            {
                await App.Database.SaveNoteAsync(note);
            }
        }
        else
        {
            note.CreatedDate = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(note.NoteText))
            {
                await App.Database.SaveNoteAsync(note);
            }
        }
       

        // Navigate backwards
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var note = (Note)BindingContext;
        await App.Database.DeleteNoteAsync(note);

        // Navigate backwards
        await Shell.Current.GoToAsync("..");
    }

    async void OnBack(object sender, EventArgs e)
    {
        // Navigate backwards
        await Shell.Current.GoToAsync("..");
    }

}