using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanApp.Core.Domain;

namespace CleanApp.Core.Data
{
    public class MoviesRepository
    {
        private IMoviesSource _movieSource;
        
        public MoviesRepository(IMoviesSource movieSource)
        {
            _movieSource = movieSource;
        }
        public async Task<IReadOnlyList<Movie>> GetMoviesForSearchAsync(string search)
        {
            return await _movieSource.GetMoviesFromSourceAsync(search);
        }
    }
}
