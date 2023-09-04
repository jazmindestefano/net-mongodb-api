using MFlixApi.Models;
namespace MFlixApi.Services
{
	public interface IMovieService
	{
		List<Movie> Get();
		Movie Get(string id);
		Movie Create(Movie movie);
		void Update(string id, Movie movie);
		void Remove(string id);
	}
}

