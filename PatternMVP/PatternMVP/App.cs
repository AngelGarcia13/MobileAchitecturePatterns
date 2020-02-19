using System;
using Android.App;
using Autofac;
using PatternMVP.Model;
using PatternMVP.Presenters;
using PatternMVP.Views;

namespace PatternMVP
{
    [Application]
    public class App : Application
    {
        public static IContainer Container { get; set; }

        public App(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            var builder = new ContainerBuilder();
            
            builder.RegisterType<MainActivity>()
                   .As<IMoviesView>();

            builder.RegisterType<MovieService>()
                   .As<IMovieService>();

            builder.RegisterType<MoviePresenter>()
                   .AsSelf();

            Container = builder.Build();
        }

    }
}
