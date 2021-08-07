﻿using Movie.DataLayer.Data;
using Movie.DataLayer.Repositories;
using Movie.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.DataLayer.Servicess
{
    public class MovieList : IMovieList
    {
        private MovieContext_DBEntities1 _db;
        public MovieList(MovieContext_DBEntities1 context)
        {
            _db = context;
        }

        public bool DeleteMovie(MovieModel movieModel)
        {
            try
            {
                _db.Entry(movieModel).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMovie(int movieId)
        {
            try
            {
                
                var movie = FindById(movieId);
                DeleteMovie(movie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public MovieModel FindById(int movieId)
        {
            return _db.MovieModels.Find(movieId);

        }

        public CommentModel FindByIdComment(int movieId)
        {
            return _db.CommentModels.Find(movieId);
        }

        public string FindNameById(int movieId)
        {
            return _db.MovieModels.Find(movieId).MovieName;
        }

        public List<CommentView> GetAllComment(int movieId)
        {
            return _db.CommentModels.Where(sa => sa.MovieId == movieId).Select(sc => new CommentView
            {
                CommentUser = sc.CommentDescription,
                UserName = sc.CommentName,
                CommentRat=sc.CommentRat
            }).ToList();
        }

        public List<MovieModel> GetAllMoveWithEndDate(DateTime parametr)
        {
            return _db.MovieModels.Where(dt => dt.DateProduction <= parametr).ToList();
        }

        public List<MovieModel> GetAllMoveWithStarttDate(DateTime parametr)
        {
            return _db.MovieModels.Where(td => td.DateProduction >= parametr).ToList();
        }

        public IEnumerable<MovieModel> GetAllMovie()
        {
            return _db.MovieModels.ToList();
        }

        public IEnumerable<MovieModel> GetAllWithLowRat(int parametr)
        {
            return _db.MovieModels.Where(ra => ra.AverageRat <= parametr).ToList();
        }

        public IEnumerable<MovieModel> GetAllWithUpRat(int parametr)
        {
            return _db.MovieModels.Where(ra => ra.AverageRat >= parametr).ToList();
        }

        public IEnumerable<MovieModel> GetMovieByGenresName(string parametr)
        {
            return _db.MovieModels.Where(am => am.Generes == parametr).ToList();
        }

        public IEnumerable<MovieModel> GetMovieByName(string parametr)
        {
            return _db.MovieModels.Where(mv => mv.MovieName == parametr).ToList();
        }

        public List<double> GetRat()
        {
            return _db.MovieModels.Select(sa => sa.AverageRat).ToList();
        }

        public bool InsertComment(CommentModel comment)
        {
            try
            {
                _db.CommentModels.Add(comment);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertMovie(MovieModel movieModel)
        {
            try
            {
                _db.MovieModels.Add(movieModel);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<MovieModel> SortedByAverageRat()
        {
            return _db.MovieModels.OrderBy(sa => sa.AverageRat).ToList();
        }

        public IEnumerable<MovieModel> SortedByProductionDate()
        {
            return _db.MovieModels.OrderBy(sa => sa.DateProduction).ToList();
        }

        public bool UpDateMovie(MovieModel movie)
        {
            try
            {
                _db.Entry(movie).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
