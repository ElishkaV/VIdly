using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2018.DTOs;
using Vidly2018.Models;

namespace Vidly2018.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<MovieDto> GetMovies ()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        public MovieDto GetMovie (int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map(movie, new MovieDto());
        }

        [HttpPost]
        public MovieDto CreateMovie (MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = _context.Movies.Add(Mapper.Map<MovieDto,Movie>(movieDto));
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return movieDto;
        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //movieInDb.Name = movie.Name;
            //movieInDb.NumbersInStock = movie.NumbersInStock;
            //movieInDb.ReleaseDate = movie.ReleaseDate;
            //movieInDb.GenreId = movie.GenreId;

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteMovie (int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
