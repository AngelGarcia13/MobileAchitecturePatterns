using System;
using Android.App;
using Autofac;
using CleanApp.Core.Data;
using CleanApp.Core.UseCases;
using CleanApp.Framework;
using CleanApp.UI.Presenters;
using CleanApp.Views;

namespace CleanApp
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
            
            builder.RegisterType<MoviesFromiTunesSource>()
                   .As<IMoviesSource>();

            builder.RegisterType<MoviesRepository>()
                   .AsSelf();

            builder.RegisterType<MoviesByTitle>()
                   .AsSelf();

            builder.RegisterType<MoviePresenter>()
                   .AsSelf();

            Container = builder.Build();
        }

    }
}
