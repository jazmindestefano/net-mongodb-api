using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MFlixApi.Models
{
	public class Movie
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string id { get; set; } = null!;

		[BsonElement("title")]
		public string title { get; set; } = String.Empty;

	}
}

