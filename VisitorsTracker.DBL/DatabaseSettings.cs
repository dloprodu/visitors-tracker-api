namespace VisitorsTracker.DBL
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
        public string MongoConnectionString { get; set; }
    }

    public interface IDatabaseSettings
    {
        string DatabaseName { get; set; }
        string CollectionName { get; set; }
        string MongoConnectionString { get; set; }
    }
}
