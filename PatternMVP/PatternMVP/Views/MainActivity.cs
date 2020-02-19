using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using PatternMVP.Adapters;
using PatternMVP.Presenters;
using System;
using Android.Views;
using Autofac;

namespace PatternMVP.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IMoviesView
    {
        private MoviePresenter _presenter;
        private SearchView searchView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //Set the presenter for the presentation and data interaction, since we don´t have a constructor we need to explicit resolve the dependency
            using (var scope = App.Container.BeginLifetimeScope())
            {
                _presenter = scope.Resolve<MoviePresenter>();
            }
            //Set adapter for list view
            var movieList = FindViewById<ListView>(Resource.Id.movieList);
            var adapter = new MovieAdapter();
            movieList.Adapter = adapter;

            //Bind the Action trigger from the presenter to the SetData Method in the adapter
            _presenter.FilterApplied += adapter.SetData;

            //Support for searching
            searchView = FindViewById<SearchView>(Resource.Id.searchView);
            searchView.QueryTextChange += OnSearch;

        }

        private async void OnSearch(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            await _presenter.FilterMoviesAsync(e.NewText);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
        public void ShowMessage()
        {
            var toast = Toast.MakeText(Application.Context, "May the force be with you!", ToastLength.Short);
            toast.SetGravity(GravityFlags.Center, 0, 0);
            toast.View.Background.SetColorFilter(Android.Graphics.Color.Red, Android.Graphics.PorterDuff.Mode.Lighten);
            toast.Show();
        }
    }
}