namespace PlantDetective;

[Activity(Label = "HomePage")]
public class HomePage : Activity
{
    ImageView homeIcon, cameraIcon, heartIcon;
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Create your application here
        SetContentView(Resource.Layout.HomePage); // Connect to your HomePage.xml file
        ActionBar!.Hide();
        homeIcon = (ImageView)FindViewById(Resource.Id.homeIcon)!;
        cameraIcon = (ImageView)FindViewById(Resource.Id.cameraIcon)!;
        heartIcon = (ImageView)FindViewById(Resource.Id.heartIcon)!;

        heartIcon.Click += ToHistoryPage;
        homeIcon.Click += ToHomaPage;
        cameraIcon.Click += ToSelectPicturePage;
    }

    private void ToSelectPicturePage(object? sender, EventArgs e)
    {
        StartActivity(typeof(TakePicture));
    }

    private void ToHomaPage(object? sender, EventArgs e)
    {
        StartActivity(typeof(HomePage));
    }

    private void ToHistoryPage(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}