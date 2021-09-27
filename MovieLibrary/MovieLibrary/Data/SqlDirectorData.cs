using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models;
using MovieLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Data
{
    public class SqlDirectorData : IDirectorData
    {
        private ProjectContext _context;

        public SqlDirectorData(ProjectContext context)
        {
            _context = context;
        }

        public Director AddDirector(Director director)
        {
            director.DirectorId = Guid.NewGuid();
            _context.Directors.Add(director);
            _context.SaveChanges();
            return director;
        }

        public void DeleteDirector(Director director)
        {
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }

        public Director EditDirector(Director director)
        {
            var existingDirector = GetDirectorById(director.DirectorId);

            if (existingDirector != null)
            {
                _context.Directors.Update(director);
                _context.SaveChanges();
            }

            return director;
        }

        public Director GetDirectorById(Guid id)
        {
            return _context.Directors
                .Include(d => d.Movies)
                .ThenInclude(m => m.Category)
                .FirstOrDefault(d => d.DirectorId == id);
        }

        public Director GetDirectorByNameAndSurname(string name, string surname)
        {
            return _context.Directors
                .Where(d => (d.Name == name) && (d.Surname == surname))
                .FirstOrDefault();
        }

        public List<Director> GetDirectors()
        {
            return _context.Directors
                .Include(d => d.Movies)
                .ThenInclude(m => m.Category)
                .ToList();
        }
    }
}
