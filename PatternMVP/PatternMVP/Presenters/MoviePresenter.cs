using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PatternMVP.Model;

namespace PatternMVP.Presenters
{
    public interface IMoviesView {
        //Here we should add the View's functionalities (UI Logic like show or hide elements) we want to interact from the Presenter
        void ShowMessage();
    }

    public class MoviePresenter
    {
        private IMoviesView _view;

        private CancellationTokenSource cts;
        private IMovieService _movieService;
        public event Action<IReadOnlyList<Movie>> FilterApplied;

        public MoviePresenter(IMoviesView view, IMovieService movieService) {
            _view = view;
            _movieService = movieService;
        }

        public async Task FilterMoviesAsync(string search)
        {
            cts?.Cancel();

            if (!string.IsNullOrEmpty(search))
            {
                var innerToken = cts = new CancellationTokenSource();
                
                var movies = await _movieService.GetMoviesForSearchAsync(search);

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
