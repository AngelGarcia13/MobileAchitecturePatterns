using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanApp.Core.Domain;

namespace CleanApp.Core.Data
{
    public interface IMoviesSource
    {
        Task<IReadOnlyList<Movie>> GetMoviesFromSourceAsync(string search, int pageNo = 1);
    }
}
