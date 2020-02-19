using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatternMVP.Model
{
    public interface IMovieService
    {
        Task<IReadOnlyList<Movie>> GetMoviesForSearchAsync(string search, int pageNo = 1);
    }
}
