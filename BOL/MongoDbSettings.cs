
namespace BOL
{
    public class MongoDbSettings
   {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; } = null;
        public string? ProductCollection { get; set; }
    }
}