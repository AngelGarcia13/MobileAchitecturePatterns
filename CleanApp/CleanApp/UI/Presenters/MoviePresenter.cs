using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanApp.Core.Domain;
using CleanApp.Core.UseCases;

namespace CleanApp.UI.Presenters
{
    public interface IMoviesView
    {
        //Here we should add the View's functionalities (UI Logic like show or hide elements) we want to interact from the Presenter
        void ShowMessage();
    }

    public class MoviePresenter
    {
        private IMoviesView _view;

        private CancellationTokenSource cts;
        private MoviesByTitle _getMoviesByTitle;
        public event Action<IReadOnlyList<Movie>> FilterApplied;

        public MoviePresenter(IMoviesView view, MoviesByTitle getMoviesByTitle)
        {
            _view = view;
            _getMoviesByTitle = getMoviesByTitle;
        }

        public async Task FilterMoviesAsync(string search)
        {
            cts?.Cancel();

            if (!string.IsNullOrEmpty(search))
            {
                var innerToken = cts = new CancellationTokenSource();

                var movies = await _getMoviesByTitle.Invoke(search);

                if (!innerToken.IsCancellationRequested)
                {
                    if (search.Equals("Star Wars", StringComparison.CurrentCultureIgnoreCase))
                    {
                        _view.ShowMessage();
                    }

                    FilterApplied?.Invoke(movies);
                }
            }
            else
            {
                FilterApplied?.Invoke(null);
            }
        }
    }
}
