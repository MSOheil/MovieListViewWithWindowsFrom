﻿using Movie.DataLayer.Data;
using Movie.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.DataLayer.Methods
{
    public static class DataGridViewPages
    {
        public static List<int> PagesNumber()
        {
            List<int> pages = new List<int>();
            using (UnitOfWork db = new UnitOfWork())
            {
                var movies = db.MovieList.GetAllMovie();
                double pageForResults = (double)db.MovieList.GetAllMovie() / 5;
                var numberpages = Convert.ToInt32(Math.Ceiling(pageForResults));
                var numpage = Enumerable.Range(1, numberpages);
                foreach (var item in numpage)
                {
                    pages.Add(item);
                }
            }

            return pages;
        }
        public static List<int> PageResult()
        {
            List<int> pagesResult = new List<int>();

            using (UnitOfWork db = new UnitOfWork())
            {
                var countMovie = db.MovieList.GetAllMovie();
                var resPage = Enumerable.Range(1, countMovie);
                foreach (var item in resPage)
                {
                    pagesResult.Add(item);
                }
            }
            return pagesResult;
        }
        public static int PageNumberController(int pageNumber)
        {
            if (pageNumber == 0)
            {
                pageNumber += 2;
            }
           
            if (pageNumber == 1)
            {
                pageNumber += 1;
            }
            return pageNumber;
        }
        public static int ResultController(int sizePage)
        {
            if (sizePage == 0)
            {
                sizePage += 5;
            }
            if (sizePage > 5)
            {
                sizePage = 5;
            }
            return sizePage;
        }
        //public static List<RateMovieViewModel> ShowResultInPages(int pageNumber = 0, int ResultPerPage = 5)
        //{
        //    using (UnitOfWork db = new UnitOfWork())
        //    {
        //        var result = db.MovieList.GetAllMovie().Skip(ResultPerPage * (pageNumber - 1)).Take(ResultPerPage);
        //        return result.ToList();
        //    }
        //}
    }
}