namespace PlantDetective;
using Xamarin.Essentials;

[Activity(Label = "TakePicture")]
public class TakePicture : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        ImageView homeIcon, takePicture, selectGallary;
        base.OnCreate(savedInstanceState);

        // Create your application here
        SetContentView(Resource.Layout.TakePicturePage);
        ActionBar!.Hide();
        homeIcon = (ImageView)FindViewById(Resource.Id.homeIcon)!;
        takePicture = (ImageView)FindViewById(Resource.Id.takePictureIcon)!;
        selectGallary = (ImageView)FindViewById(Resource.Id.galleryIcon)!;

        homeIcon.Click += ToMainPage;
        takePicture.Click += TakePicture_Click;
        selectGallary.Click += SelectGallary_Click;
    }

    private async void SelectGallary_Click(object? sender, EventArgs e)
    {
        Console.WriteLine("haha");
        try
        {
            FileResult file = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Select Picture"
            });

            if(file != null)
            {
                // Use the selected file here
                string filePath = file.FullPath;
                // Do something with the file path
                Console.WriteLine(filePath);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void TakePicture_Click(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void ToMainPage(object? sender, EventArgs e)
    {
        StartActivity(typeof(MainActivity));
    }
}