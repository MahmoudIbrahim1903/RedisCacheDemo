using RedisCache.Models;
using System.Collections.Generic;

namespace RedisCache.Services
{
    public interface IBooksService
    {
        List<Book> LoadBooks();
    }
}
