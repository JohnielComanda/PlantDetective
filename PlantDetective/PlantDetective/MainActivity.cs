namespace PlantDetective
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ImageView upDesign;
        Button start;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            ActionBar!.Hide();
            upDesign = (ImageView)FindViewById(Resource.Id.upperDesign)!;
            upDesign.Rotation = 2000;
            start = (Button)FindViewById(Resource.Id.start)!;
            start.Click += ToMainPage; // Call ToMainPage when start button is click
        }

        //Navigate to HomaPage
        private void ToMainPage(object? sender, EventArgs e)
        {
            StartActivity(typeof(HomePage));
        }
    }
}