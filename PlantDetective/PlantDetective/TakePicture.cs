namespace PlantDetective;

using Android.Bluetooth;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using System.Reflection;
using Xamarin.Essentials;
using PlantDetective;
using System.IO;


[Activity(Label = "TakePicture")]
public class TakePicture : Activity
{
    ImageView homeIcon, takePicture, selectGallary, picture;
    Button iden;
    Drawable testImg;
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        // Create your application here
        SetContentView(Resource.Layout.TakePicturePage);
        ActionBar!.Hide();
        homeIcon = (ImageView)FindViewById(Resource.Id.homeIcon)!;
        takePicture = (ImageView)FindViewById(Resource.Id.takePictureIcon)!;
        selectGallary = (ImageView)FindViewById(Resource.Id.galleryIcon)!;
        picture = (ImageView)FindViewById(Resource.Id.picture)!;
        iden = (Button)FindViewById(Resource.Id.identify)!;

        iden.Visibility = Android.Views.ViewStates.Invisible;

        iden.Click += Iden_Click;
        homeIcon.Click += ToMainPage;
        takePicture.Click += TakePicture_Click;
        selectGallary.Click += SelectGallary_Click;
    }

    private void Iden_Click(object? sender, EventArgs e)
    {
        BitmapDrawable bitmapDrawable = (BitmapDrawable)testImg!;
        Bitmap bitmap = bitmapDrawable.Bitmap!;
        byte[] data;

        using (MemoryStream memoryStream = new MemoryStream())
        {
            bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, memoryStream);
            data = memoryStream.ToArray();
        }
        //Load sample data
        MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
        {
            ImageSource = data,
        };

        //Load model and predict output
        var result = MLModel1.Predict(sampleData);
        Console.WriteLine(result.PredictedLabel);
        /*string zipFileName = "MLModel1.zip";
        string zipFilePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), zipFileName);
        Console.WriteLine(zipFilePath);*/
    }

    private async void SelectGallary_Click(object? sender, EventArgs e)
    {
        try
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Select an Image"
            });

            if (result != null)
            {
                // Handle the selected image
                string imagePath = result.FullPath;
                Drawable img = Drawable.CreateFromPath(imagePath)!;
                testImg = img;
                picture.SetImageDrawable(img);
                iden.Visibility = Android.Views.ViewStates.Visible;
                // ...
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            Console.WriteLine($"Error selecting image: {ex.Message}");
        }

    }


    private async void TakePicture_Click(object? sender, EventArgs e)
    {
        try
        {
            var photo = await MediaPicker.CapturePhotoAsync();

            // Get the path to the captured photo
            string photoPath = photo.FullPath;
            Drawable img = Drawable.CreateFromPath(photoPath)!;
            testImg = img;
            picture.SetImageDrawable(img);
            iden.Visibility = Android.Views.ViewStates.Visible;
            // Process or save the photo as needed
            // ...
        }
        catch (Exception ex) 
        {
            // Handle exception
            Console.WriteLine($"Error taking picture: {ex.Message}");
        }
    }

    private void ToMainPage(object? sender, EventArgs e)
    {
        StartActivity(typeof(HomePage));
    }
}