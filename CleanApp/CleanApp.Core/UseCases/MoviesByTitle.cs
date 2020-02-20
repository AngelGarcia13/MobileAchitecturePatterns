using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanApp.Core.Data;
using CleanApp.Core.Domain;

namespace CleanApp.Core.UseCases
{
    public class MoviesByTitle
    {
        private MoviesRepository _moviesRepository;

        public MoviesByTitle(MoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public Task<IReadOnlyList<Movie>> Invoke(string titleForSearching)
        {
            return _moviesRepository.GetMoviesForSearchAsync(titleForSearching);
        }
    }
}
