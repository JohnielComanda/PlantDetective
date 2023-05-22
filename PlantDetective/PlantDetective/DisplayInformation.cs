namespace PlantDetective;

[Activity(Label = "DisplayInformation")]
public class DisplayInformation : Activity
{
    ImageView homeIcon, takePicture, history;
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Create your application here
        SetContentView(Resource.Layout.DisplayInformation);
        ActionBar!.Hide();
        homeIcon = (ImageView)FindViewById(Resource.Id.homeIcon)!;
        takePicture = (ImageView)FindViewById(Resource.Id.cameraIcon)!;
        history = (ImageView)FindViewById(Resource.Id.heartIcon)!;

        homeIcon.Click += ToMainPage;
        takePicture.Click += TakePicture_Click;
        history.Click += History_Click;
    }

    private void History_Click(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void TakePicture_Click(object? sender, EventArgs e)
    {
        StartActivity(typeof(TakePicture));
    }

    private void ToMainPage(object? sender, EventArgs e)
    {
        StartActivity(typeof(HomePage));
    }
}