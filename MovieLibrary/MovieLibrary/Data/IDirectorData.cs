using MovieLibrary.Models;
using System;
using System.Collections.Generic;

namespace MovieLibrary.Data
{
    public interface IDirectorData
    {
        List<Director> GetDirectors();

        Director GetDirectorById(Guid id);

        Director GetDirectorByNameAndSurname(string name, string surname);

        Director AddDirector(Director director);

        void DeleteDirector(Director director);

        Director EditDirector(Director director);
    }
}
