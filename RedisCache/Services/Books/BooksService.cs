using RedisCache.Models;
using System;
using System.Collections.Generic;

namespace RedisCache.Services
{
    public class BooksService : IBooksService
    {
        private readonly IRedisCacheService _redisCacheService;

        public BooksService(IRedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
        }

        public List<Book> LoadBooks()
        {
            var result = _redisCacheService.GetCachedData<List<Book>>("books");

            if (result == null)
            {
                result =  new List<Book>
                {
                    new() { Id = 1, Name = "Book 1", Author = "From Cache", Description = "Description 1", Rate = 1 },
                    new() { Id = 2, Name = "Book 2", Author = "From Cache", Description = "Description 2", Rate = 2 },
                    new() { Id = 3, Name = "Book 3", Author = "From Cache", Description = "Description 3", Rate = 3 },
                    new() { Id = 4, Name = "Book 4", Author = "From Cache", Description = "Description 4", Rate = 4 },
                    new() { Id = 5, Name = "Book 5", Author = "From Cache", Description = "Description 5", Rate = 5 }
                };

                _redisCacheService.SetCachedData<List<Book>>("books", result, TimeSpan.FromSeconds(30));

                result.ForEach(b => {
                    b.Author = "From Database";
                });
            }
            return result;
        }
    }
}
