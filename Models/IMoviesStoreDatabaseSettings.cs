using System;
namespace MFlixApi.Models
{
	public interface IMoviesStoreDatabaseSettings
    {
		string MoviesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
	}
}

